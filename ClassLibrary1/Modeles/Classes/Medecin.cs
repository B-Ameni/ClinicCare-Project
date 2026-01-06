using ClassLibrary1.Modeles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Modeles
{
    public class Medecin : IUser
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Specialite { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public List<RendezVous> RendezVous { get; set; }
        public List<DossierMedical> Dossiers { get; set; }
        public List<Message> Messages { get; set; }


        public Medecin()
        {
            RendezVous = new List<RendezVous>();
            Dossiers = new List<DossierMedical>();
            Messages = new List<Message>();
        }
    }

}
