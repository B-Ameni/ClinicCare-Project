using System;
using System.Windows.Forms;
using ClassLibrary1.Services;
using Modeles.Classes;


namespace ClinicProject.ResponsablePat
{
    public partial class DossierMedicalForm : Form
    {
        private readonly int patientId;
        private readonly DossierMedicalService dossierService;
        private Modeles.Classes.Patient patient;
        private DossierMedical currentDossier;

        public DossierMedicalForm(int patientId)
        {
            InitializeComponent();
            this.patientId = patientId;
            dossierService = new DossierMedicalService();

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

         //   textBoxDossier.Text = currentDossier.Id.ToString();
        }

        private void LoadPatientInfo()
        {
            // Ici tu devrais récupérer le patient depuis PatientService
            var patientService = new PatientService();
            patient = patientService.GetAll().Find(p => p.Id == patientId);

            if (patient != null)
            {
                labelNom.Text = patient.Nom;
                labelPrenom.Text = patient.Prenom;
                labelDateNaissance.Text = patient.DateNaissance.ToShortDateString();
                labelTel.Text = patient.Telephone;
            }
        }

        // Bouton Ajouter fichier
        private void buttonAjouterFichier_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Ici on peut ajouter le chemin du fichier dans currentDossier.Fichiers
                currentDossier.Fichiers = openFile.FileName;
                dossierService.Update(currentDossier);
                MessageBox.Show("Fichier ajouté !");
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

        private void DossierMedicalForm_Load(object sender, EventArgs e)
        {

        }
    }
}
