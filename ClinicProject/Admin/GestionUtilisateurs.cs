using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicProject
{
    public partial class GestionUtilisateurs : Form
    {
        public GestionUtilisateurs()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ListeDesPatients();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new ListeDesWorkers();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new ListeDesWorkers();
            form.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
