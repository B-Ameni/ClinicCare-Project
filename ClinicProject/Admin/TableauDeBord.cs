using ClassLibrary1.Modeles;
using ClassLibrary1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicProject
{
    public partial class TableauDeBord : Form
    {

        private RendezVousService rdvService;
        private List<RendezVous> rdvsDuJour;

        private MonthCalendar calendar;
        private DataGridView dgv;

        private Panel panelLeft;
        private Panel panelRight;
        private Panel panelBottom;

        public TableauDeBord()
        {
            InitializeComponent();
            rdvService = new RendezVousService();

            InitializeDataGridView();
            InitializeLayout();
        }

        // ==========================
        // LAYOUT GENERAL
        // ==========================
        private void InitializeLayout()
        {
            // ----- PANEL GAUCHE (CALENDRIER)
            panelLeft = new Panel();
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Width = 250;
            panelLeft.BackColor = Color.WhiteSmoke;

            calendar = new MonthCalendar();
            calendar.Dock = DockStyle.Fill;
            calendar.MaxSelectionCount = 1;
            calendar.DateSelected += Calendar_DateSelected;

            panelLeft.Controls.Add(calendar);

            // ----- PANEL DROIT (DATAGRID)
            panelRight = new Panel();
            panelRight.Dock = DockStyle.Fill;
            panelRight.BackColor = Color.White;

            panelRight.Controls.Add(dgv);

            // ----- PANEL BAS (BOUTONS)
            panelBottom = new Panel();
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Height = 55;
            panelBottom.BackColor = Color.Gainsboro;

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.FlowDirection = FlowDirection.RightToLeft;
            flow.Padding = new Padding(10);

            Button btnAjouter = new Button()
            {
                Text = "Ajouter RDV",
                Width = 120,
                Height = 35,
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAjouter.Click += BtnAjouter_Click;

            Button btnModifier = new Button()
            {
                Text = "Modifier RDV",
                Width = 120,
                Height = 35,
                BackColor = Color.DarkOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnModifier.Click += BtnModifier_Click;

            Button btnAnnuler = new Button()
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

            // ----- AJOUT AU FORM (ORDRE IMPORTANT)
            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);
            this.Controls.Add(panelBottom);

            // ----- PROPRIETES FORM
            this.Text = "Calendrier des rendez-vous";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }

        // ==========================
        // DATAGRID
        // ==========================
        private void InitializeDataGridView()
        {
            dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.AutoGenerateColumns = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Heure",
                DataPropertyName = "Heure"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Patient",
                DataPropertyName = "Patient"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Médecin",
                DataPropertyName = "Medecin"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Statut",
                DataPropertyName = "Statut"
            });
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
            rdvsDuJour = rdvService.GetByDate(date);

            dgv.DataSource = rdvsDuJour.Select(r => new
            {
                Heure = r.DateHeure.ToString("HH:mm"),
                Patient = rdvService.GetPatientName(r.PatientId),
                Medecin = rdvService.GetMedecinName(r.MedecinId),
                Statut = r.Statut
            }).ToList();
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            RDVDialog dialog = new RDVDialog();
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

            RDVDialog dialog = new RDVDialog(rdv);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                rdvService.Update(dialog.RDV);
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
    }
}
