using ClassLibrary1.Modeles;
using ClassLibrary1.Services;
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
    public partial class ListeDesPatients : Form
    {
        private List<Patient> patients;
        private readonly PatientService patientService;

        public ListeDesPatients()
        {
            InitializeComponent();
            patientService = new PatientService();
        }

        
        private void ListeDesPatients_Load(object sender, EventArgs e)
        {
            patients = patientService.GetAll();
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = patients.Select(p => new
            {
                p.Id,
                p.Nom,
                p.Prenom,
                NumTel = p.Telephone
            }).ToList();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifie qu'on clique bien sur une ligne et la dernière colonne (Supprimer)
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["Supprimer"].Index)
                return;

            // Récupérer l'ID du patient sélectionné
            int patientId = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            var patient = patients.FirstOrDefault(p => p.Id == patientId);
            if (patient == null) return;

            // Confirmation
            var confirm = MessageBox.Show(
                $"Supprimer le patient : {patient.Nom} {patient.Prenom} ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            // Supprimer du service + liste locale
            patientService.Delete(patient.Id);
            patients.Remove(patient);

            LoadData();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int patientId = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            var patient = patients.FirstOrDefault(p => p.Id == patientId);
            if (patient == null) return;

            patient.Nom = dataGridView1.Rows[e.RowIndex].Cells["Nom"].Value?.ToString();
            patient.Prenom = dataGridView1.Rows[e.RowIndex].Cells["Prenom"].Value?.ToString();
            patient.Telephone = dataGridView1.Rows[e.RowIndex].Cells["NumTel"].Value?.ToString();

            patientService.Update(patient);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
