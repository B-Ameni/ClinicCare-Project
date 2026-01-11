using ClinicProject.MedecinForm;
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

namespace ClinicProject.PatientForm
{
    public partial class AccueilPatient : Form
    {
        private Patient p;
        public AccueilPatient(Patient patient)
        {
            InitializeComponent();
            p = patient;
        }

        private void AccueilPatient_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ProfilPatient profilForm = new ProfilPatient(p);
            profilForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new PriseRDV(p).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DossierMedicalFormPatient(p.Id).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MessageriePatient(p).Show();
        }
    }
}
