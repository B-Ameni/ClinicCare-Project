using System;
using System.Collections.Generic;
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
        private Patient patient;
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

        // ==========================
        // Initialisation du ComboBox
        // ==========================
        private void InitializeComboBox()
        {
            comboBox1.Items.Add("IRM");
            comboBox1.Items.Add("Analyse");
            comboBox1.Items.Add("Ordonnance");
            comboBox1.Items.Add("Scanner");
            comboBox1.Items.Add("Autre");
            comboBox1.SelectedIndex = 0;
        }

        // ==========================
        // Charger le dossier médical
        // ==========================
        private void LoadDossier()
        {
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

        // ==========================
        // Charger les infos patient
        // ==========================
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
        private void buttonAjouterFichier_Click_1(object sender, EventArgs e)
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

                    AjouterFichierAuDossier(typeFichier, fichierSelectionne);

                    MessageBox.Show($"{typeFichier} ajouté !\nChemin : {fichierSelectionne}");
                }
            }
        }

        // ==========================
        // Ajouter fichier au dossier
        // ==========================
        private void AjouterFichierAuDossier(string typeFichier, string cheminFichier)
        {
            string nouveau = $"{typeFichier}:{cheminFichier};";

            if (string.IsNullOrEmpty(currentDossier.Fichiers))
                currentDossier.Fichiers = nouveau;
            else
                currentDossier.Fichiers += nouveau;

            dossierService.Update(currentDossier);

            // Recharger le dossier depuis la base
            currentDossier = dossierService.GetAll().Find(d => d.PatientId == patientId);
        }


        // ==========================
        // Récupérer fichiers par type
        // ==========================
        // ==========================
        // Récupérer fichiers par type
        // ==========================
        private List<string> GetFichiersParType(string typeFichier)
        {
            var fichiers = new List<string>();

            // Recharger le dossier depuis la base pour être sûr
            currentDossier = dossierService.GetAll().Find(d => d.PatientId == patientId);
            if (currentDossier == null || string.IsNullOrEmpty(currentDossier.Fichiers))
                return fichiers;

            // Split sur ';' pour chaque fichier
            var items = currentDossier.Fichiers.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in items)
            {
                // Split simple sur ':'
                var parts = item.Split(':');
                if (parts.Length == 2 && parts[0].Equals(typeFichier, StringComparison.OrdinalIgnoreCase))
                {
                    fichiers.Add(parts[1]);
                }
            }

            return fichiers;
        }


        // ==========================
        // Boutons pour afficher fichiers
        // ==========================
        private void buttonIRM_Click(object sender, EventArgs e)
        {
            AfficherFichiers("IRM");
        }

        private void buttonAnalyse_Click_1(object sender, EventArgs e)
        {
            AfficherFichiers("Analyse");
        }

        private void buttonScanner_Click(object sender, EventArgs e)
        {
            AfficherFichiers("Scanner");
        }

        private void buttonAutreFichier_Click(object sender, EventArgs e)
        {
            AfficherFichiers("Autre");
        }
        private void buttonTraitement_Click(object sender, EventArgs e)
        {
            AfficherFichiers("Autre");
        }

            private void AfficherFichiers(string typeFichier)
        {
            var fichiers = GetFichiersParType(typeFichier);

            if (fichiers.Count == 0)
            {
                MessageBox.Show($"Aucun fichier de type {typeFichier} enregistré.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = string.Join("\n", fichiers);
            MessageBox.Show(message, $"Fichiers {typeFichier}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DossierMedicalFormMedecin_Load(object sender, EventArgs e)
        {

        }

        
        }
    }
