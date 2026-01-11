using ClassLibrary1.Modeles;
using ClassLibrary1.Services;
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

namespace ClinicProject
{
    public partial class ListeDesMedecins : Form
    {

        private BindingList<UserGridItem> data = new BindingList<UserGridItem>();
        private readonly MedecinService medService = new MedecinService();
        private readonly ResponsableService respService = new ResponsableService();
        public ListeDesMedecins()
        {
            InitializeComponent();
        }

        // Classe pour le DataGrid
        public class UserGridItem
        {
            public int Id { get; set; }
            public string Type { get; set; } // "Medecin" ou "Responsable"
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Specialite { get; set; }
        }

        private void ListeDesMedecins_Load(object sender, EventArgs e)
        {
            // Setup du ComboBox
            comboBox1.Items.Add(""); // vide → afficher tout
            comboBox1.Items.Add("Medecins");
            comboBox1.Items.Add("Responsables");
            comboBox1.SelectedIndex = 0;

            SetupGrid();
            LoadData();
        }

        // ================== CONFIGURATION DATAGRID ==================
        private void SetupGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Id",
                DataPropertyName = "Id",
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nom",
                DataPropertyName = "Nom"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Prenom",
                DataPropertyName = "Prenom"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Specialite",
                DataPropertyName = "Specialite"
            });

            var btn = new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Text = "Supprimer",
                UseColumnTextForButtonValue = true
            };

            dataGridView1.Columns.Add(btn);

            dataGridView1.DataSource = data;
        }

        // ================== CHARGEMENT DES DONNÉES ==================
        private void LoadData(string filter = "")
        {
            data.Clear();

            var medecins = medService.GetAll();
            var responsables = respService.GetAll();

            // ===== MÉDECINS =====
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

            // ===== RESPONSABLES =====
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

            dataGridView1.Refresh();
        }

        // ================== FILTRE COMBOBOX ==================
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboBox1.SelectedItem?.ToString() ?? "";
            LoadData(selected);
        }

        // ================== SUPPRESSION ==================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var item = data[e.RowIndex];

                var confirm = MessageBox.Show(
                    $"Supprimer {item.Type} : {item.Nom} ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;

                if (item.Type == "Medecin")
                {
                    medService.Delete(item.Id);
                }
                else
                {
                    respService.Delete(item.Id);
                }

                LoadData(comboBox1.SelectedItem?.ToString() ?? "");
            }
        }

        // ================== MODIFICATION INLINE ==================
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

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

        // ================== AJOUT ==================
        private void button1_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selected))
            {
                MessageBox.Show("Veuillez sélectionner 'Medecins' ou 'Responsables' avant d'ajouter.");
                return;
            }

            var formAjout = new AjoutMedecin(selected);

            if (formAjout.ShowDialog() == DialogResult.OK)
            {
                if (selected == "Medecins")
                {
                    var m = formAjout.NouvelUtilisateur as Medecin;
                    if (m != null)
                    {
                        medService.Add(m);
                    }
                }
                else
                {
                    var r = formAjout.NouvelUtilisateur as ResponsablePatient;
                    if (r != null)
                    {
                        respService.Add(r);
                    }
                }

                LoadData(selected); // 🔥 Rafraîchit le datagrid après ajout
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

