using ClassLibrary1.Modeles;
using ClassLibrary1.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Modeles.Classes;

namespace ClinicProject.MedecinForm
{
    public partial class MessagerieMedecin: Form
    {
        private readonly Medecin med;

        private readonly MessageService messageService = new MessageService();
        private readonly PatientService patientService = new PatientService();
        private readonly MedecinService medecinService = new MedecinService();

        private int selectedId;
        private string selectedType;

        public MessagerieMedecin(Medecin medecin)
        {
            InitializeComponent();
            med = medecin;
        }

        private void MessagerieResp_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }

        // ===================== CONTACTS =====================
        private void LoadContacts()
        {
            listBoxContacts.Items.Clear();

            foreach (var p in patientService.GetAll())
            {
                listBoxContacts.Items.Add(new ContactItem
                {
                    Id = p.Id,
                    Type = "Patient",
                    Nom = p.Nom + " " + p.Prenom
                });
            }

            foreach (var m in medecinService.GetAll())
            {
                listBoxContacts.Items.Add(new ContactItem
                {
                    Id = m.Id,
                    Type = "Medecin",
                    Nom = "Dr " + m.Nom + " " + m.Prenom
                });
            }
        }

        // ===================== SELECTION CONTACT =====================
        private void listBoxContacts_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var contact = listBoxContacts.SelectedItem as ContactItem;
            if (contact == null) return;

            selectedId = contact.Id;
            selectedType = contact.Type;

            lblConversation.Text = "Conversation avec : " + contact.Nom;
            LoadConversation();
        }

        // ===================== CONVERSATION =====================
        private void LoadConversation()
        {
            listBoxMessages.Clear(); // Efface tout le contenu

            var messages = messageService.GetConversation(
                med.Id,
                "Responsable",
                selectedId,
                selectedType
            );

            foreach (var m in messages)
            {
                bool isMe = m.ExpediteurId == med.Id &&
                            m.TypeExpediteur == "Responsable";

                string prefix = isMe ? "Moi" : "Lui";

                listBoxMessages.SelectionStart = listBoxMessages.TextLength;
                listBoxMessages.SelectionLength = 0;

                // Couleur différente si c'est moi ou l'autre
                listBoxMessages.SelectionColor = isMe ? Color.Blue : Color.DarkGreen;
                listBoxMessages.AppendText($"{prefix} [{m.DateEnvoi:dd/MM HH:mm}] : ");
                    
                listBoxMessages.SelectionColor = Color.Black;
                listBoxMessages.AppendText(m.Contenu + "\n\n");
            }

            // Scroll automatique en bas
            listBoxMessages.SelectionStart = listBoxMessages.TextLength;
            listBoxMessages.ScrollToCaret();
        }

        // ===================== ENVOI MESSAGE =====================
        private void btnEnvoyer_Click_1(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Veuillez sélectionner un contact.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            var msg = new Modeles.Classes.Message
            {
                ExpediteurId = med.Id,
                TypeExpediteur = "Responsable",
                DestinataireId = selectedId,
                TypeDestinataire = selectedType,
                Contenu = txtMessage.Text
            };

            messageService.Add(msg);
            txtMessage.Clear();
            LoadConversation();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    // ===================== CLASSE CONTACT =====================
    public class ContactItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Nom { get; set; }

        public override string ToString()
        {
            return $"{Nom} ({Type})";
        }
    }
}
