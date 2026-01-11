using Modeles.Classes;
using System;
using System.Linq;
using System.Windows.Forms;
using ClassLibrary1.Services;

namespace ClinicProject.PatientForm
{
    public partial class AjoutRDVPatientt : Form
    {
        public RendezVous RDV { get; private set; }
        private readonly int patientId;
        private readonly MedecinService medecinService;

        // ===== AJOUT =====
        public AjoutRDVPatientt(int patId)
        {
            InitializeComponent();
            patientId = patId;
            medecinService = new MedecinService();
            ConfigurerDateTimePicker();
        }

        // ===== MODIFICATION =====
        public AjoutRDVPatientt(int patId, RendezVous rdv)
        {
            InitializeComponent();
            patientId = patId;
            medecinService = new MedecinService();
            ConfigurerDateTimePicker();

            if (rdv != null)
            {
                RDV = rdv;
                dtpDateHeure.Value = rdv.DateHeure;

                // Charger le nom du médecin
                var medecin = medecinService.GetAll()
                    .FirstOrDefault(m => m.Id == rdv.MedecinId);

                if (medecin != null)
                    txtMedecinNom.Text = medecin.Nom;
            }
        }

        // ===== DATE + HEURE =====
        private void ConfigurerDateTimePicker()
        {
            dtpDateHeure.Format = DateTimePickerFormat.Custom;
            dtpDateHeure.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDateHeure.ShowUpDown = true;
        }

        // ===== CONFIRMER =====
        private void button2_Click_1(object sender, EventArgs e)
        {
            string nomMedecin = txtMedecinNom.Text.Trim();

            if (string.IsNullOrEmpty(nomMedecin))
            {
                MessageBox.Show("Veuillez saisir le nom du médecin",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔍 Chercher médecin par nom
            var medecin = medecinService.GetAll()
                .FirstOrDefault(m =>
                    m.Nom.Equals(nomMedecin, StringComparison.OrdinalIgnoreCase));

            if (medecin == null)
            {
                MessageBox.Show("Médecin introuvable",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpDateHeure.Value <= DateTime.Now)
            {
                MessageBox.Show("La date doit être future",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (RDV == null)
            {
                RDV = new RendezVous();
            }

            RDV.MedecinId = medecin.Id;
            RDV.PatientId = patientId;
            RDV.DateHeure = dtpDateHeure.Value;
            RDV.Statut = "Planifié";

            DialogResult = DialogResult.OK;
            Close();
        }

   
    }
}
