using ClinicProject.PatientForm;
using ClassLibrary1.Modeles;
using ClassLibrary1.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using ClinicProject.ResponsablePat;
using ClinicProject.MedecinForm;

namespace ClinicProject.Auth
{
    public partial class Authentification : Form
    {
        private readonly PatientService patientService;
        private readonly MedecinService medecinService;
        private readonly ResponsableService responsableService;
        private readonly AdministrateurService adminService;

        public Authentification()
        {
            InitializeComponent();
            patientService = new PatientService();
            medecinService = new MedecinService();
            responsableService = new ResponsableService();
            adminService = new AdministrateurService();
        }

        private void buttonConnexion_Click_1(object sender, EventArgs e)
        {
            string email = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez saisir un email et un mot de passe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Vérifier Administrateur
            var admin = adminService.GetAll().FirstOrDefault(a => a.Email == email && a.MotDePasse == password);
            if (admin != null)
            {
                MessageBox.Show("Connexion Administrateur réussie !");
                // Ouvrir interface Administrateur
                 new Form1().Show();
                return;
            }

            // Vérifier Médecin
            var medecin = medecinService.GetAll().FirstOrDefault(m => m.Email == email && m.MotDePasse == password);
            if (medecin != null)
            {
                MessageBox.Show("Connexion Médecin réussie !");
                // Ouvrir interface Médecin
                new AccueilMedecin(medecin).Show();
                return;
            }

            // Vérifier ResponsablePatient
            var responsable = responsableService.GetAll().FirstOrDefault(r => r.Email == email && r.MotDePasse == password);
            if (responsable != null)
            {
                MessageBox.Show("Connexion Responsable Patient réussie !");
                // Ouvrir interface Responsable
                 new AccueilResponsable(responsable).Show();
                return;
            }

            // Vérifier Patient
            var patient = patientService.GetAll().FirstOrDefault(p => p.Email == email && p.MotDePasse == password);
            if (patient != null)
            {
                MessageBox.Show("Connexion Patient réussie !");
                // Ouvrir interface Patient
                new AccueilPatient(patient).Show();
                return;
            }

            MessageBox.Show("Email ou mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonCreerCompte_Click_1(object sender, EventArgs e)
        {
            CreationCompte creationCompte = new CreationCompte();
            creationCompte.Show();
        }

        private void Authentification_Load(object sender, EventArgs e)
        {

        }

     
    }
}
