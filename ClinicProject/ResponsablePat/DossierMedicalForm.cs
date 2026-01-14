using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary1.Services;
using Modeles.Classes;

namespace ClinicProject.ResponsablePat
{
    public partial class DossierMedicalForm : Form
    {
        private readonly int patientId;
        private readonly DossierMedicalService dossierService;
        private readonly PatientService patientService;
        private Patient patient;
        private DossierMedical currentDossier;

        public DossierMedicalForm(int patientId)
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
        // Initialiser comboBox1
        // ==========================
        private void InitializeComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("IRM");
            comboBox1.Items.Add("Analyse");
            comboBox1.Items.Add("Ordonnance");
            comboBox1.Items.Add("Scanner");
            comboBox1.Items.Add("Autre");
            comboBox1.SelectedIndex = 0; // sélection par défaut
        }

        // ==========================
        // Charger le dossier
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
        // Charger infos patient
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
                    AjouterFichierAuDossier(typeFichier, fichierSelectionne);

                    MessageBox.Show($"{typeFichier} ajouté !\nChemin : {fichierSelectionne}");
                }
            }
        }

        // ==========================
        // Ajouter le fichier au dossier
        // ==========================
        private void AjouterFichierAuDossier(string typeFichier, string cheminFichier)
        {
            string nouveau = $"{typeFichier}:{cheminFichier};";

            if (string.IsNullOrEmpty(currentDossier.Fichiers))
                currentDossier.Fichiers = nouveau;
            else
                currentDossier.Fichiers += nouveau;

            dossierService.Update(currentDossier);
        }

        // ==========================
        // Récupérer fichiers par type
        // ==========================
        private List<string> GetFichiersParType(string typeFichier)
        {
            var fichiers = new List<string>();

            if (string.IsNullOrEmpty(currentDossier.Fichiers))
                return fichiers;

            var items = currentDossier.Fichiers.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                var parts = item.Split(new char[] { ':' }, 2);
                if (parts.Length == 2 && parts[0].Equals(typeFichier, StringComparison.OrdinalIgnoreCase))
                {
                    fichiers.Add(parts[1]);
                }
            }

            return fichiers;
        }

        // ==========================
        // Afficher fichiers par type
        // ==========================
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

        // ==========================
        // Boutons pour chaque type
        // ==========================
        private void buttonIRM_Click(object sender, EventArgs e)
        {
            AfficherFichiers("IRM");
        }

        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
            AfficherFichiers("Analyse");
        }

        private void buttonOrdonnance_Click(object sender, EventArgs e)
        {
            AfficherFichiers("Ordonnance");
        }

        private void buttonScanner_Click(object sender, EventArgs e)
        {
            AfficherFichiers("Scanner");
        }

        private void buttonAutreFichier_Click(object sender, EventArgs e)
        {
            AfficherFichiers("Autre");
        }
    }
}
