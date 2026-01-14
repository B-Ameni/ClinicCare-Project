using ClassLibrary1.Modeles;
using ClassLibrary1.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Modeles.Classes;

namespace ClinicProject
{
    public partial class MessagerieResp : Form
    {
        private readonly ResponsablePatient responsable;

        private readonly MessageService messageService = new MessageService();
        private readonly PatientService patientService = new PatientService();
        private readonly MedecinService medecinService = new MedecinService();
        private readonly ResponsableService responsableService = new ResponsableService();

        private int selectedId;
        private string selectedType;

        public MessagerieResp(ResponsablePatient responsableConnecte)
        {
            InitializeComponent();
            responsable = responsableConnecte;
        }

        private void MessagerieResp_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }

        // ===================== CONTACTS =====================
        private void LoadContacts()
        {
            listBoxContacts.Items.Clear();

            // Ajouter patients
            foreach (var p in patientService.GetAll())
            {
                listBoxContacts.Items.Add(new ContactItem
                {
                    Id = p.Id,
                    Type = "Patient",
                    Nom = p.Nom + " " + p.Prenom
                });
            }

            // Ajouter médecins
            foreach (var m in medecinService.GetAll())
            {
                listBoxContacts.Items.Add(new ContactItem
                {
                    Id = m.Id,
                    Type = "Medecin",
                    Nom = "Dr " + m.Nom + " " + m.Prenom
                });
            }

            // Ajouter responsables (sauf soi-même)
            foreach (var r in responsableService.GetAll().Where(rp => rp.Id != responsable.Id))
            {
                listBoxContacts.Items.Add(new ContactItem
                {
                    Id = r.Id,
                    Type = "Responsable",
                    Nom = r.Nom + " " + r.Prenom
                });
            }
        }

        // ===================== SELECTION CONTACT =====================
        private void listBoxContacts_SelectedIndexChanged(object sender, EventArgs e)
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
            listBoxMessages.Clear();

            var messages = messageService.GetConversation(
                responsable.Id,
                "Responsable",
                selectedId,
                selectedType
            );

            foreach (var m in messages)
            {
                bool isMe = m.ExpediteurId == responsable.Id && m.TypeExpediteur == "Responsable";
                string prefix = isMe ? "Moi" : "Lui";

                listBoxMessages.SelectionStart = listBoxMessages.TextLength;
                listBoxMessages.SelectionLength = 0;

                listBoxMessages.SelectionColor = isMe ? Color.Blue : Color.DarkGreen;
                listBoxMessages.AppendText($"{prefix} [{m.DateEnvoi:dd/MM HH:mm}] : ");

                listBoxMessages.SelectionColor = Color.Black;
                listBoxMessages.AppendText(m.Contenu + "\n\n");
            }

            listBoxMessages.SelectionStart = listBoxMessages.TextLength;
            listBoxMessages.ScrollToCaret();
        }

        // ===================== ENVOI MESSAGE =====================
        private void btnEnvoyer_Click(object sender, EventArgs e)
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
                ExpediteurId = responsable.Id,
                TypeExpediteur = "Responsable",
                DestinataireId = selectedId,
                TypeDestinataire = selectedType,
                Contenu = txtMessage.Text,
                DateEnvoi = DateTime.Now
            };

            messageService.Add(msg);
            txtMessage.Clear();
            LoadConversation();
        }
    }

    // ===================== CLASSE CONTACT =====================
    public class ContactItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Nom { get; set; }

        public override string ToString() => $"{Nom} ({Type})";
    }
}
