using ClassLibrary1.Services;
using ClinicProject.MedecinForm;
using Modeles.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicProject
{
    public partial class CalendrierMedecin : Form
    {
        private readonly Medecin medecin; // Médecin connecté
        private RendezVousService rdvService;
        private List<RendezVous> rdvsDuJour;

        private MonthCalendar calendar;
        private DataGridView dgv;
        private Panel panelLeft;
        private Panel panelRight;
        private Panel panelBottom;

        public CalendrierMedecin(Medecin m)
        {
            medecin = m ?? throw new ArgumentNullException(nameof(m));
            rdvService = new RendezVousService();

            InitializeDataGridView();
            InitializeLayout();
        }

        // ==========================
        // LAYOUT
        // ==========================
        private void InitializeLayout()
        {
            this.Text = $"Calendrier Dr. {medecin.Nom} {medecin.Prenom}";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // ---- PANEL GAUCHE ----
            panelLeft = new Panel { Dock = DockStyle.Left, Width = 250, BackColor = Color.WhiteSmoke };
            calendar = new MonthCalendar { Dock = DockStyle.Fill, MaxSelectionCount = 1 };
            calendar.DateSelected += Calendar_DateSelected;
            panelLeft.Controls.Add(calendar);

            // ---- PANEL DROIT ----
            panelRight = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            panelRight.Controls.Add(dgv);

            // ---- PANEL BAS ----
            panelBottom = new Panel { Dock = DockStyle.Bottom, Height = 55, BackColor = Color.Gainsboro };
            FlowLayoutPanel flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10)
            };

            // Bouton Ajouter RDV
            Button btnAjouter = new Button
            {
                Text = "Ajouter RDV",
                Width = 120,
                Height = 35,
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAjouter.Click += BtnAjouter_Click;

            // Bouton Modifier RDV
            Button btnModifier = new Button
            {
                Text = "Modifier RDV",
                Width = 120,
                Height = 35,
                BackColor = Color.DarkOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnModifier.Click += BtnModifier_Click;

            // Bouton Annuler RDV
            Button btnAnnuler = new Button
            {
                Text = "Annuler RDV",
                Width = 120,
                Height = 35,
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAnnuler.Click += BtnAnnuler_Click;

            flow.Controls.Add(btnAjouter);
            flow.Controls.Add(btnModifier);
            flow.Controls.Add(btnAnnuler);
            panelBottom.Controls.Add(flow);

            // ---- AJOUT AU FORM ----
            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);
            this.Controls.Add(panelBottom);
        }

        // ==========================
        // DATAGRID
        // ==========================
        private void InitializeDataGridView()
        {
            dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = false, // Pour pouvoir éditer le statut
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Heure", DataPropertyName = "Heure", ReadOnly = true });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Patient", DataPropertyName = "Patient", ReadOnly = true });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Statut", DataPropertyName = "Statut", ReadOnly = true });

            // Colonne pour changer le statut
            var statutCol = new DataGridViewComboBoxColumn
            {
                HeaderText = "Changer statut",
                Name = "StatutCombo",
                FlatStyle = FlatStyle.Flat
            };
            statutCol.Items.Add("Terminé");
            statutCol.Items.Add("Patient absent");
            dgv.Columns.Add(statutCol);

            // Événements pour la ComboBox
            dgv.CellValueChanged += Dgv_CellValueChanged;
            dgv.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgv.IsCurrentCellDirty)
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }

        // ==========================
        // EVENEMENTS
        // ==========================
        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            LoadRendezVous(e.Start);
        }

        private void LoadRendezVous(DateTime date)
        {
            rdvsDuJour = rdvService.GetByDate(date)
                .Where(r => r.MedecinId == medecin.Id)
                .ToList();

            dgv.Rows.Clear();

            foreach (var r in rdvsDuJour)
            {
                int rowIndex = dgv.Rows.Add(
                    r.DateHeure.ToString("HH:mm"),
                    rdvService.GetPatientName(r.PatientId),
                    r.Statut,
                    null
                );

                bool datePassee = r.DateHeure < DateTime.Now;
                dgv.Rows[rowIndex].Cells["StatutCombo"].ReadOnly = !datePassee;

                if (!datePassee)
                    dgv.Rows[rowIndex].Cells["StatutCombo"].Style.BackColor = Color.LightGray;
            }
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            AjoutRDV dialog = new AjoutRDV(medecin.Id);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rdvService.Add(dialog.RDV);
                    LoadRendezVous(calendar.SelectionStart);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Conflit de rendez-vous",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            int index = dgv.SelectedRows[0].Index;
            RendezVous rdv = rdvsDuJour[index];

            AjoutRDV dialog = new AjoutRDV(medecin.Id, rdv);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rdvService.Update(dialog.RDV);
                    LoadRendezVous(calendar.SelectionStart);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Erreur",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            int index = dgv.SelectedRows[0].Index;
            RendezVous rdv = rdvsDuJour[index];

            // Confirmation avant suppression
            var result = MessageBox.Show(
                $"Voulez-vous vraiment annuler le rendez-vous avec {rdvService.GetPatientName(rdv.PatientId)} à {rdv.DateHeure:HH:mm} ?",
                "Confirmer l'annulation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                rdvService.Delete(rdv.Id);
                LoadRendezVous(calendar.SelectionStart);
            }
        }

        private void Dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgv.Columns[e.ColumnIndex].Name != "StatutCombo") return;

            var rdv = rdvsDuJour[e.RowIndex];
            var newStatut = dgv.Rows[e.RowIndex].Cells["StatutCombo"].Value?.ToString();

            if (string.IsNullOrEmpty(newStatut)) return;

            if (rdv.DateHeure >= DateTime.Now)
            {
                MessageBox.Show("Impossible de modifier le statut avant la date du rendez-vous.");
                LoadRendezVous(calendar.SelectionStart);
                return;
            }

            rdv.Statut = newStatut;
            rdvService.UpdateStatut(rdv.Id, newStatut);

            LoadRendezVous(calendar.SelectionStart);
        }
    }
}
