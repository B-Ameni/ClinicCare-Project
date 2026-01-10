using ClassLibrary1.Modeles.Interfaces;
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
using System.Security.Cryptography;
using ClassLibrary1.Services;

namespace ClinicProject
{
    public partial class AjoutMedecin : Form
    {
        private string type; // "Medecins" ou "Responsables"
        public IUser NouvelUtilisateur { get; private set; }
        public Medecin m { get; private set; }
        public ClassLibrary1.Modeles.ResponsablePatient r { get; private set; }

        public AjoutMedecin(string type)
        {
            InitializeComponent();
            this.type = type;
            label3.Text = type == "Medecins" ? "Ajouter un Médecin" : "Ajouter un Responsable";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = txtBoxNom.Text.Trim();
            string prenom = textBox1.Text.Trim();
            string specialite = textBox2.Text.Trim();
            string email = textBox3.Text.Trim();
            string motDePasse = textBox4.Text.Trim();
            string mdpConfirm = textBox5.Text;

            // ---- Vérifications ----
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires !");
                return;
            }

            if (motDePasse != mdpConfirm)
            {
                MessageBox.Show("Le mot de passe et la confirmation ne correspondent pas !");
                return;
            }

            if (type == "Medecins")
            {
                m = new Medecin
                {
                    Nom = nom,
                    Prenom = prenom,
                    Specialite = specialite,
                    Email = email,
                    MotDePasse = motDePasse
                };
                var medService = new MedecinService();
                medService.Add(m);
            }
            else // Responsable
            {
                r = new ClassLibrary1.Modeles.ResponsablePatient
                {
                    Nom = nom,
                    Prenom = prenom,
                    Specialite = specialite,
                    Email = email,
                    MotDePasse = motDePasse
                };
                var respService = new ResponsableService();
                respService.Add(r);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
