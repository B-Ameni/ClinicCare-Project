using ClassLibrary1.Services;
using Modeles.Classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicProject
{
    public partial class ListeDesPatients : Form
    {
        private BindingList<PatientGridItem> data = new BindingList<PatientGridItem>();
        private readonly PatientService patientService = new PatientService();

        public ListeDesPatients()
        {
            InitializeComponent();
            SetupForm();
        }

        // ==================== CLASSE POUR LE DATAGRID ====================
        public class PatientGridItem
        {
            public int Id { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string DateNaissance { get; set; }
            public string Telephone { get; set; }
        }

        // ==================== CONFIGURATION DE L'INTERFACE ====================
        private Panel headerPanel;
        private Label titleLabel;
        private DataGridView dataGridView1;

        private void SetupForm()
        {
            this.Text = "Liste des Patients";
            this.Width = 800;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // -------- HEADER --------
            headerPanel = new Panel
            {
                Height = 70,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(0, 123, 255)
            };
            this.Controls.Add(headerPanel);

            titleLabel = new Label
            {
                Text = "Liste des Patients",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            headerPanel.Controls.Add(titleLabel);

            // -------- DATAGRIDVIEW --------
            dataGridView1 = new DataGridView
            {
                Left = 0,
                Top = 80,
                Width = 800,
                Height = 400,
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

            // Colonnes
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", ReadOnly = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nom", DataPropertyName = "Nom" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Prénom", DataPropertyName = "Prenom" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date Naissance", DataPropertyName = "DateNaissance" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Téléphone", DataPropertyName = "Telephone" });

            var btnCol = new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Text = "Supprimer",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(btnCol);

            // Événements
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;

            dataGridView1.DataSource = data;
            this.Controls.Add(dataGridView1);

            LoadData();
        }

        // ==================== CHARGEMENT DES DONNÉES ====================
        private void LoadData()
        {
            data.Clear();
            var patients = patientService.GetAll();

            foreach (var p in patients)
            {
                data.Add(new PatientGridItem
                {
                    Id = p.Id,
                    Nom = p.Nom,
                    Prenom = p.Prenom,
                    DateNaissance = p.DateNaissance.ToShortDateString(),
                    Telephone = p.Telephone
                });
            }
        }

        // ==================== SUPPRESSION ====================
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !(dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            var item = data[e.RowIndex];
            if (MessageBox.Show($"Supprimer le patient {item.Nom} {item.Prenom} ?", "Confirmer", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                patientService.Delete(item.Id);
                data.RemoveAt(e.RowIndex);
            }
        }

        // ==================== MISE À JOUR ====================
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = data[e.RowIndex];
            var p = patientService.GetAll().FirstOrDefault(x => x.Id == item.Id);
            if (p == null) return;

            p.Nom = item.Nom;
            p.Prenom = item.Prenom;
            p.Telephone = item.Telephone;
            // DateNaissance = on peut ignorer ou ajouter si besoin
            patientService.Update(p);
        }
    }
}
