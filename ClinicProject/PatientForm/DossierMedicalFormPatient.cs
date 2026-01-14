using System;
using System.Windows.Forms;
using ClassLibrary1.Services;
using Modeles.Classes;

namespace ClinicProject.PatientForm
{
    public partial class DossierMedicalFormPatient : Form
    {
        private readonly int patientId;
        private readonly DossierMedicalService dossierService;
        private readonly PatientService patientService;
        private Modeles.Classes.Patient patient;
        private DossierMedical currentDossier;

        public DossierMedicalFormPatient(int patientId)
        {
            InitializeComponent();
            this.patientId = patientId;
            dossierService = new DossierMedicalService();
            patientService = new PatientService();

            LoadDossier();
            LoadPatientInfo();
        }
        private void LoadDossier()
        {
            // Chercher le dossier médical du patient
            currentDossier = dossierService.GetAll().Find(d => d.PatientId == patientId);

            if (currentDossier == null)
            {
                currentDossier = new DossierMedical
                {
                    PatientId = patientId,
                    DateCreation = DateTime.Now
                };
                dossierService.Add(currentDossier);
            }
        }

        private void LoadPatientInfo()
        {
            patient = patientService.GetAll().Find(p => p.Id == patientId);

            if (patient != null)
            {
                labelNom.Text = patient.Nom;
                labelPrenom.Text = patient.Prenom;
                labelDateNaissance.Text = patient.DateNaissance.ToShortDateString();
                labelTel.Text = patient.Telephone;
            }
        }

        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Analyse du patient...");
        }

        private void buttonConsultation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Consultation du patient...");
        }

        private void buttonTraitement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Traitement du patient...");
        }

        private void DossierMedicalFormMedecin_Load(object sender, EventArgs e)
        {

        }

        private void DossierMedicalFormPatient_Load(object sender, EventArgs e)
        {

        }

        private void buttonAnalyse_Click_1(object sender, EventArgs e)
        {

        }
    }
}
