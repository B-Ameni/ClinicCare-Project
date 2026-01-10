using ClassLibrary1.Modeles;
using ClassLibrary1.Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicProject
{
    public partial class ListeDesWorkers : Form
    {
        private BindingList<UserGridItem> data = new BindingList<UserGridItem>();
        private readonly MedecinService medService = new MedecinService();
        private readonly ResponsableService respService = new ResponsableService();

        public ListeDesWorkers()
        {
            InitializeComponent();
            SetupForm();
        }

        public class UserGridItem
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Specialite { get; set; }
        }

        // ================== CONFIGURATION INTERFACE ==================
        private Panel headerPanel;
        private Label titleLabel;
        private ComboBox comboBox1;
        private Button buttonAjouter;
        private DataGridView dataGridView1;

        private void SetupForm()
        {
            this.Text = "Liste des médecins et responsables";
            this.Width = 800;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // ================== HEADER ==================
            headerPanel = new Panel
            {
                Height = 70,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(0, 123, 255) // bleu
            };
            this.Controls.Add(headerPanel);

            titleLabel = new Label
            {
                Text = "Liste des médecins et responsables",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            headerPanel.Controls.Add(titleLabel);

            // ================== COMBOBOX ==================
            comboBox1 = new ComboBox
            {
                Left = 20,
                Top = 90,
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBox1.Items.Add("");
            comboBox1.Items.Add("Medecins");
            comboBox1.Items.Add("Responsables");
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.Controls.Add(comboBox1);

            // ================== BOUTON AJOUTER ==================
            buttonAjouter = new Button
            {
                Left = 200,
                Top = 90,
                Width = 100,
                Height = 30,
                Text = "Ajouter",
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            buttonAjouter.FlatAppearance.BorderSize = 0;
            buttonAjouter.Click += ButtonAjouter_Click;
            this.Controls.Add(buttonAjouter);

            // ================== DATAGRIDVIEW ==================
            dataGridView1 = new DataGridView
            {
                Left = 0,
                Top = 140,
                Width = 800,
                Height = 300,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(240, 240, 240)
                },
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Brancher les événements après
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            // Colonnes
             
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", ReadOnly = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nom", DataPropertyName = "Nom" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Prénom", DataPropertyName = "Prenom" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Spécialité", DataPropertyName = "Specialite" });

            var btnCol = new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Text = "Supprimer",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(btnCol);

            dataGridView1.DataSource = data;
            this.Controls.Add(dataGridView1);

            LoadData();
        }

        // ================== CHARGEMENT DES DONNÉES ==================
        private void LoadData(string filter = "")
        {
            data.Clear();

            var medecins = medService.GetAll();
            var responsables = respService.GetAll();

            if (string.IsNullOrEmpty(filter) || filter == "Medecins")
            {
                foreach (var m in medecins)
                {
                    data.Add(new UserGridItem
                    {
                        Id = m.Id,
                        Type = "Medecin",
                        Nom = m.Nom,
                        Prenom = m.Prenom,
                        Specialite = m.Specialite
                    });
                }
            }

            if (string.IsNullOrEmpty(filter) || filter == "Responsables")
            {
                foreach (var r in responsables)
                {
                    data.Add(new UserGridItem
                    {
                        Id = r.Id,
                        Type = "Responsable",
                        Nom = r.Nom,
                        Prenom = r.Prenom,
                        Specialite = r.Specialite
                    });
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(comboBox1.SelectedItem?.ToString() ?? "");
        }

        private void ButtonAjouter_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected))
            {
                MessageBox.Show("Sélectionnez Medecins ou Responsables !");
                return;
            }

            var formAjout = new AjoutMedecin(selected);
            if (formAjout.ShowDialog() == DialogResult.OK)
            {
                if (selected == "Medecins")
                {
                    var m = formAjout.NouvelUtilisateur as Medecin;
                    if (m != null) medService.Add(m);
                }
                else
                {
                    var r = formAjout.NouvelUtilisateur as ClassLibrary1.Modeles.ResponsablePatient;
                    if (r != null) respService.Add(r);
                }

                LoadData(selected);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !(dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            var item = data[e.RowIndex];
            if (MessageBox.Show($"Supprimer {item.Type} {item.Nom} ?", "Confirmer", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (item.Type == "Medecin") medService.Delete(item.Id);
                else respService.Delete(item.Id);

                LoadData(comboBox1.SelectedItem?.ToString() ?? "");
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = data[e.RowIndex];

            if (item.Type == "Medecin")
            {
                var m = medService.GetAll().First(x => x.Id == item.Id);
                m.Nom = item.Nom;
                m.Prenom = item.Prenom;
                m.Specialite = item.Specialite;
                medService.Update(m);
            }
            else
            {
                var r = respService.GetAll().First(x => x.Id == item.Id);
                r.Nom = item.Nom;
                r.Prenom = item.Prenom;
                r.Specialite = item.Specialite;
                respService.Update(r);
            }
        }
    }
}
