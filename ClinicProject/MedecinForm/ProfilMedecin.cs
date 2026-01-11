using ClassLibrary1.Modeles;
using Modeles.Classes;
using System;
using System.Windows.Forms;

namespace ClinicProject.MedecinForm
{
    public partial class ProfilMedecin : Form
    {
        private Medecin medecin;

        public ProfilMedecin(Medecin m)
        {
            medecin = m;
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            this.Text = $"Profil Dr. {medecin.Nom} {medecin.Prenom}";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(400, 350);
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

            AddLabelValue("Nom :", medecin.Nom);
            AddLabelValue("Prénom :", medecin.Prenom);
            AddLabelValue("Email :", medecin.Email);
            AddLabelValue("Spécialité :", medecin.Specialite);
            AddLabelValue("Nombre de RDV :", medecin.RendezVous?.Count.ToString() ?? "0");

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
    }
}
