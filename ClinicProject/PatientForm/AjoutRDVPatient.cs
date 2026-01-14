using Modeles.Classes;
using System;
using System.Linq;
using System.Windows.Forms;
using ClassLibrary1.Services;

namespace ClinicProject.PatientForm
{
    public partial class AjoutRDVPatientt : Form
    {
        public RendezVous RDV { get; private set; }
        private readonly int patientId;
        private readonly MedecinService medecinService;

        public AjoutRDVPatientt(int patId)
        {
            InitializeComponent();
            patientId = patId;
            medecinService = new MedecinService();

            ConfigurerDateTimePicker();
            InitialiserComboMedecins();
        }

        public AjoutRDVPatientt(int patId, RendezVous rdv)
        {
            InitializeComponent();
            patientId = patId;
            medecinService = new MedecinService();

            ConfigurerDateTimePicker();
            InitialiserComboMedecins();

            if (rdv != null)
            {
                RDV = rdv;
                dtpDateHeure.Value = rdv.DateHeure;

                // Sélectionner le médecin correspondant dans le combo
                for (int i = 0; i < cmbListePatients.Items.Count; i++)
                {
                    var item = (ComboboxItem)cmbListePatients.Items[i];
                    if (item.Value == rdv.MedecinId)
                    {
                        cmbListePatients.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        // ==========================
        // Configurer le DateTimePicker
        // ==========================
        private void ConfigurerDateTimePicker()
        {
            dtpDateHeure.Format = DateTimePickerFormat.Custom;
            dtpDateHeure.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDateHeure.ShowUpDown = true;
        }

        // ==========================
        // Charger les médecins dans le ComboBox
        // ==========================
        private void InitialiserComboMedecins()
        {
            cmbListePatients.Items.Clear();
            cmbListePatients.DropDownStyle = ComboBoxStyle.DropDownList;

            var medecins = medecinService.GetAll();
            foreach (var m in medecins)
            {
                cmbListePatients.Items.Add(new ComboboxItem
                {
                    Text = $"{m.Nom} {m.Prenom}",
                    Value = m.Id
                });
            }

            if (cmbListePatients.Items.Count > 0)
                cmbListePatients.SelectedIndex = 0;
        }

        // ==========================
        // Confirmer ajout / modification
        // ==========================
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (cmbListePatients.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un médecin",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedMedecin = (ComboboxItem)cmbListePatients.SelectedItem;

            if (dtpDateHeure.Value <= DateTime.Now)
            {
                MessageBox.Show("La date doit être future",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (RDV == null)
                RDV = new RendezVous();

            RDV.MedecinId = selectedMedecin.Value;
            RDV.PatientId = patientId;
            RDV.DateHeure = dtpDateHeure.Value;
            RDV.Statut = "Planifié";

            DialogResult = DialogResult.OK;
            Close();
        }
    }

    // ==========================
    // Classe pour ComboBox
    // ==========================
    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public override string ToString() => Text;
    }
}
