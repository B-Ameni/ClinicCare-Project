using ClassLibrary1.Modeles;
using ClassLibrary1.Services;
using Modeles.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClinicProject.MedecinForm
{
    public partial class AjoutRDV : Form
    {
        // RDV créé ou modifié
        public RendezVous RDV { get; private set; }

        // Médecin connecté
        private readonly int medecinId;

        // Services
        private readonly PatientService patientService = new PatientService();

        // ===================== CONSTRUCTEUR AJOUT =====================
        public AjoutRDV(int medecinId)
        {
            InitializeComponent();
            this.medecinId = medecinId;

            ConfigurerDateTimePicker();
        }

        // ===================== CONSTRUCTEUR MODIFICATION =====================
        public AjoutRDV(int medecinId, RendezVous rdv) : this(medecinId)
        {
            if (rdv != null)
            {
                RDV = rdv;
                dtpDateHeure.Value = rdv.DateHeure;
            }
        }

        // ===================== LOAD =====================
        private void AjoutRDV_Load(object sender, EventArgs e)
        {
            ChargerPatients();

            // Mode modification
            if (RDV != null)
            {
                cmbPatients.SelectedValue = RDV.PatientId;
            }
        }

        // ===================== CONFIG DATE + HEURE =====================
        private void ConfigurerDateTimePicker()
        {
            dtpDateHeure.Format = DateTimePickerFormat.Custom;
            dtpDateHeure.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDateHeure.ShowUpDown = true;
        }

        // ===================== CHARGER PATIENTS =====================
        private void ChargerPatients()
        {
            var patients = patientService.GetAll();

            // Transformation pour affichage
            var data = patients
                .Select(p => new PatientItem
                {
                    Id = p.Id,
                    Display = p.Nom + " " + p.Prenom
                })
                .ToList();

            cmbPatients.DataSource = data;
            cmbPatients.DisplayMember = "Display";
            cmbPatients.ValueMember = "Id";
            cmbPatients.SelectedIndex = -1;
        }

        // ===================== CONFIRMER =====================
        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbPatients.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (dtpDateHeure.Value < DateTime.Now)
            {
                MessageBox.Show("La date du rendez-vous ne peut pas être dans le passé.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int patientId = (int)cmbPatients.SelectedValue;

            if (RDV == null)
                RDV = new RendezVous();

            RDV.MedecinId = medecinId;
            RDV.PatientId = patientId;
            RDV.DateHeure = dtpDateHeure.Value;
            RDV.Statut = "Planifié";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ===================== ANNULER =====================
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }

    // ===================== CLASSE INTERMÉDIAIRE =====================
    public class PatientItem
    {
        public int Id { get; set; }
        public string Display { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}
