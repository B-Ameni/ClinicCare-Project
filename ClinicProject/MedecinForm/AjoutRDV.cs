using Modeles.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicProject.MedecinForm
{
    public partial class AjoutRDV : Form
    {
        public RendezVous RDV { get; private set; }  // RDV créé

        private readonly int medecinId; // Médecin connecté

        public AjoutRDV(int medId)
        {
            medecinId = medId;
            InitializeComponent();
          //  InitializeLayout();
        }

        private Button btnConfirmer;
        private Button btnAnnuler;

    
        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPatientId.Text.Trim(), out int patientId))
            {
                MessageBox.Show("ID Patient invalide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RDV = new RendezVous
            {
                MedecinId = medecinId,
                PatientId = patientId,
                DateHeure = dtpDateHeure.Value,
                Statut = "Planifié"
            };

            this.DialogResult = DialogResult.OK;
        }
        public AjoutRDV(int medecinId, RendezVous rdv = null)
        {
            InitializeComponent();
            this.medecinId = medecinId;

            // Configurer DateTimePicker pour date + heure
            dtpDateHeure.Format = DateTimePickerFormat.Custom;
            dtpDateHeure.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDateHeure.ShowUpDown = true;

            if (rdv != null)
            {
                // Si on modifie, pré-remplir les valeurs existantes
                dtpDateHeure.Value = rdv.DateHeure;
                txtPatientId.Text = rdv.PatientId.ToString();
                RDV = rdv;
            }
        }

        private void AjoutRDV_Load(object sender, EventArgs e)
        {

        }

  
    }
}
