using ClassLibrary1.Services;
using Modeles.Classes;
using System;
using System.Windows.Forms;

namespace ClinicProject.PatientForm
{
    public partial class CreationCompte : Form
    {
        private readonly PatientService patientService;

        public CreationCompte()
        {
            InitializeComponent();
            patientService = new PatientService();
            InitializeLayout();
        }

        private TextBox txtNom;
        private TextBox txtPrenom;
        private DateTimePicker dtpDateNaissance;
        private TextBox txtEmail;
        private TextBox txtTelephone;
        private TextBox txtAdresse;
        private TextBox txtMotDePasse;
        private TextBox txtConfirmerMotDePasse;
        private Button btnCreerCompte;

        private void InitializeLayout()
        {
            this.Text = "Création de compte Patient";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(400, 500);

            var lblNom = new Label() { Text = "Nom", Top = 20, Left = 30, Width = 100 };
            txtNom = new TextBox() { Top = 20, Left = 150, Width = 200 };

            var lblPrenom = new Label() { Text = "Prénom", Top = 60, Left = 30, Width = 100 };
            txtPrenom = new TextBox() { Top = 60, Left = 150, Width = 200 };

            var lblDateNaissance = new Label() { Text = "Date de naissance", Top = 100, Left = 30, Width = 120 };
            dtpDateNaissance = new DateTimePicker() { Top = 100, Left = 150, Width = 200, Format = DateTimePickerFormat.Short };

            var lblEmail = new Label() { Text = "Email", Top = 140, Left = 30, Width = 100 };
            txtEmail = new TextBox() { Top = 140, Left = 150, Width = 200 };

            var lblTelephone = new Label() { Text = "Téléphone", Top = 180, Left = 30, Width = 100 };
            txtTelephone = new TextBox() { Top = 180, Left = 150, Width = 200 };

            var lblAdresse = new Label() { Text = "Adresse", Top = 220, Left = 30, Width = 100 };
            txtAdresse = new TextBox() { Top = 220, Left = 150, Width = 200 };

            var lblMotDePasse = new Label() { Text = "Mot de passe", Top = 260, Left = 30, Width = 100 };
            txtMotDePasse = new TextBox() { Top = 260, Left = 150, Width = 200, PasswordChar = '*' };

            var lblConfirmerMotDePasse = new Label() { Text = "Confirmer mot de passe", Top = 300, Left = 30, Width = 150 };
            txtConfirmerMotDePasse = new TextBox() { Top = 300, Left = 180, Width = 170, PasswordChar = '*' };

            btnCreerCompte = new Button()
            {
                Text = "Créer le compte",
                Top = 350,
                Left = 150,
                Width = 150,
                Height = 35,
                BackColor = System.Drawing.Color.RoyalBlue,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCreerCompte.Click += BtnCreerCompte_Click;

            this.Controls.Add(lblNom);
            this.Controls.Add(txtNom);
            this.Controls.Add(lblPrenom);
            this.Controls.Add(txtPrenom);
            this.Controls.Add(lblDateNaissance);
            this.Controls.Add(dtpDateNaissance);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblTelephone);
            this.Controls.Add(txtTelephone);
            this.Controls.Add(lblAdresse);
            this.Controls.Add(txtAdresse);
            this.Controls.Add(lblMotDePasse);
            this.Controls.Add(txtMotDePasse);
            this.Controls.Add(lblConfirmerMotDePasse);
            this.Controls.Add(txtConfirmerMotDePasse);
            this.Controls.Add(btnCreerCompte);
        }

        private void BtnCreerCompte_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifications simples
                if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                    string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtMotDePasse.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtMotDePasse.Text != txtConfirmerMotDePasse.Text)
                {
                    MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Création du patient
                Modeles.Classes.Patient nouveauPatient = new Modeles.Classes.Patient
                {
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    DateNaissance = dtpDateNaissance.Value,
                    Email = txtEmail.Text.Trim(),
                    Telephone = txtTelephone.Text.Trim(),
                    Adresse = txtAdresse.Text.Trim(),
                    MotDePasse = txtMotDePasse.Text
                };

                patientService.Add(nouveauPatient);

                MessageBox.Show("Compte créé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création du compte : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
