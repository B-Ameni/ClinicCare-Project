using System;
using System.Windows.Forms;
using ClassLibrary1.Services;
using Modeles.Classes;

namespace ClinicProject.MedecinForm
{
    public partial class DossierMedicalFormMedecin : Form
    {
        private readonly int patientId;
        private readonly DossierMedicalService dossierService;
        private readonly PatientService patientService;
        private Modeles.Classes.Patient patient;
        private DossierMedical currentDossier;

        public DossierMedicalFormMedecin(int patientId)
        {
            InitializeComponent();
            this.patientId = patientId;
            dossierService = new DossierMedicalService();
            patientService = new PatientService();

            InitializeComboBox();
            LoadDossier();
            LoadPatientInfo();
        }

        private void InitializeComboBox()
        {
            // Remplir le combobox avec les types de fichiers possibles
            comboBox1.Items.Add("IRM");
            comboBox1.Items.Add("Analyse");
            comboBox1.Items.Add("Ordonnance");
            comboBox1.Items.Add("Scanner");
            comboBox1.Items.Add("Autre");
            comboBox1.SelectedIndex = 0; // Sélection par défaut
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

        // ==========================
        // Ajouter un fichier
        // ==========================
        private void buttonAjouterFichier_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un type de fichier.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string typeFichier = comboBox1.SelectedItem.ToString();

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Title = $"Sélectionner un fichier pour {typeFichier}";
                openFile.Filter = "Tous les fichiers (*.*)|*.*";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string fichierSelectionne = openFile.FileName;

                    // Enregistrer le chemin dans le dossier médical
                    currentDossier.Fichiers = $"{typeFichier}: {fichierSelectionne}";
                    dossierService.Update(currentDossier);

                    MessageBox.Show($"{typeFichier} ajouté !\nChemin : {fichierSelectionne}");

                    // Ouvrir automatiquement le fichier sélectionné (optionnel)
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = fichierSelectionne,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Impossible d'ouvrir le fichier.\n" + ex.Message);
                    }
                }
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
    }
}
