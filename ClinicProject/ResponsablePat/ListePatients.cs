using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Modeles;
using ClassLibrary1.Services;
using System.Linq;
using ClinicProject.MedecinForm;

namespace ClinicProject.ResponsablePat
{
    public partial class ListePatients : Form
    {
        private readonly PatientService patientService;

        public ListePatients()
        {
            InitializeComponent();
            patientService = new PatientService();
        }

        private void ListePatients_Load(object sender, EventArgs e)
        {
            // Charger tous les patients dans la ListBox
            var patients = patientService.GetAll();

            // Créer un objet anonyme avec Nom + Prenom pour l'affichage
            listBoxPatients.DisplayMember = "NomPrenom"; // Nom + Prénom
            listBoxPatients.ValueMember = "Id";
            listBoxPatients.DataSource = patients
                .Select(p => new { NomPrenom = p.Nom + " " + p.Prenom, p.Id, PatientObj = p })
                .ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxPatients.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupérer le patient sélectionné
            var selected = listBoxPatients.SelectedItem;
            Modeles.Classes.Patient selectedPatient = (Modeles.Classes.Patient)selected.GetType().GetProperty("PatientObj").GetValue(selected);

            // Ouvrir le DossierMedicalForm pour ce patient
            DossierMedicalFormMedecin dossierForm = new DossierMedicalFormMedecin(selectedPatient.Id);
            dossierForm.Show();
        }

        private void listBoxPatients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
