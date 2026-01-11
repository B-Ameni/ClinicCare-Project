using Modeles.Classes;
using System;
using System.Windows.Forms;

namespace ClinicProject.PatientForm
{
    public partial class ProfilPatient : Form
    {
        private Patient patient;

        public ProfilPatient(Patient p)
        {
            patient = p;
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            this.Text = $"Profil de {patient.Nom} {patient.Prenom}";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(400, 450);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            int top = 20;
            int leftLabel = 20;
            int leftValue = 150;
            int gap = 40;

            void AddLabelValue(string labelText, string valueText)
            {
                Label lbl = new Label()
                {
                    Text = labelText,
                    Top = top,
                    Left = leftLabel,
                    Width = 120
                };

                Label val = new Label()
                {
                    Text = valueText,
                    Top = top,
                    Left = leftValue,
                    Width = 200,
                    AutoSize = true
                };

                this.Controls.Add(lbl);
                this.Controls.Add(val);

                top += gap;
            }

            AddLabelValue("Nom :", patient.Nom);
            AddLabelValue("Prénom :", patient.Prenom);
            AddLabelValue("Date de naissance :", patient.DateNaissance.ToShortDateString());
            AddLabelValue("Email :", patient.Email);
            AddLabelValue("Téléphone :", patient.Telephone);
            AddLabelValue("Adresse :", patient.Adresse);
            AddLabelValue("Nombre de RDV :", patient.RendezVous.Count.ToString());
            AddLabelValue("Nombre de dossiers :", patient.Dossiers.Count.ToString());
            AddLabelValue("Messages reçus :", patient.Messages.Count.ToString());

            Button btnFermer = new Button()
            {
                Text = "Fermer",
                Width = 100,
                Height = 30,
                Top = top + 20,
                Left = (this.ClientSize.Width - 100) / 2,
                BackColor = System.Drawing.Color.RoyalBlue,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnFermer.Click += (s, e) => this.Close();
            this.Controls.Add(btnFermer);
        }

        private void ProfilPatient_Load(object sender, EventArgs e)
        {

        }
    }
}
