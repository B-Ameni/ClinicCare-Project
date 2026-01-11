using ClassLibrary1.Modeles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Modeles.Classes
{
    public class Patient : IUser
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string MotDePasse { get; set; }
        public List<RendezVous> RendezVous { get; set; }
        public List<DossierMedical> Dossiers { get; set; }
        public List<Message> Messages { get; set; }


        public Patient()
        {
            RendezVous = new List<RendezVous>();
            Dossiers = new List<DossierMedical>();
            Messages = new List<Message>();
        }
    }

}
