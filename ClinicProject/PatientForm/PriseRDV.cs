using ClassLibrary1.Services;
using ClinicProject.MedecinForm;
using Modeles.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicProject.PatientForm
{
    public partial class PriseRDV : Form
    {
        private readonly Patient patient; // Médecin connecté
        private RendezVousService rdvService;
        private List<RendezVous> rdvsDuJour;

        private MonthCalendar calendar;
        private DataGridView dgv;
        private Panel panelLeft;
        private Panel panelRight;
        private Panel panelBottom;

        public PriseRDV(Patient p)
        {
            patient = p ?? throw new ArgumentNullException(nameof(p));
            rdvService = new RendezVousService();

            InitializeDataGridView();
            InitializeLayout();
        }

        // ==========================
        // LAYOUT
        // ==========================
        private void InitializeLayout()
        {
            this.Text = $"Calendrier du patient {patient.Nom} {patient.Prenom}";
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



            // Ajouter tous les boutons au flow
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
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Heure", DataPropertyName = "Heure" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Patient", DataPropertyName = "Patient" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Statut", DataPropertyName = "Statut" });
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
                .Where(r => r.MedecinId == patient.Id)
                .ToList();

            dgv.DataSource = rdvsDuJour.Select(r => new
            {
                Heure = r.DateHeure.ToString("HH:mm"),
                Patient = rdvService.GetPatientName(r.PatientId),
                Statut = r.Statut
            }).ToList();
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            AjoutRDVPatientt dialog = new AjoutRDVPatientt(patient.Id);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                rdvService.Add(dialog.RDV);
                LoadRendezVous(calendar.SelectionStart);
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            int index = dgv.SelectedRows[0].Index;
            RendezVous rdv = rdvsDuJour[index];

            // Utiliser AjoutRDV pour modifier
            AjoutRDV dialog = new AjoutRDV(patient.Id, rdv); // passe le rdv existant
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                rdvService.Update(dialog.RDV); // prend la date+heure modifiée
                LoadRendezVous(calendar.SelectionStart);
            }
        }


        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int index = dgv.SelectedRows[0].Index;
            RendezVous rdv = rdvsDuJour[index];

            rdvService.Delete(rdv.Id);
            LoadRendezVous(calendar.SelectionStart);
        }


        private void CalendrierMedecin_Load(object sender, EventArgs e)
        {

        }

        private void PriseRDV_Load(object sender, EventArgs e)
        {


        }
    }
}
