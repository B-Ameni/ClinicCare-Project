using ClinicProject.PatientForm;
using Modeles.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicProject.MedecinForm
{
    public partial class AccueilMedecin : Form
    {
        private Medecin med;
        public AccueilMedecin(Medecin medecin)
        {
            InitializeComponent();
            med = medecin;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new CalendrierMedecin(med).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ListePatientsMedecin().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MessagerieMedecin(med).Show();
        }

        private void AccueilMedecin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProfilMedecin profilForm = new ProfilMedecin(med);
            profilForm.ShowDialog();
        }
    }
}
