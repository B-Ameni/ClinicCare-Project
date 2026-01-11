using ClassLibrary1.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modeles.Classes;

namespace ClinicProject
{
    public partial class RDVDialog : Form
    {
        public RendezVous RDV { get; private set; }

        // AJOUT
        public RDVDialog()
        {
            InitializeComponent();
            RDV = new RendezVous();
        }

        // MODIFICATION
        public RDVDialog(RendezVous rdv)
        {
            InitializeComponent();
            RDV = rdv;

            txtPatientId.Text = rdv.PatientId.ToString();
            txtMedecinId.Text = rdv.MedecinId.ToString();
            dtpDateHeure.Value = rdv.DateHeure;
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientId.Text) ||
                string.IsNullOrWhiteSpace(txtMedecinId.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            RDV.PatientId = int.Parse(txtPatientId.Text);
            RDV.MedecinId = int.Parse(txtMedecinId.Text);
            RDV.DateHeure = dtpDateHeure.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
