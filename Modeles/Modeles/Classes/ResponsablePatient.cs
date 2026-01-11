using ClassLibrary1.Modeles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeles.Classes
{
    public class ResponsablePatient :IUser
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public String Specialite { get; set; }
        public List<DossierMedical> DossiersGeres { get; set; }
        public List<Message> Messages { get; set; }


        public ResponsablePatient()
        {
            DossiersGeres = new List<DossierMedical>();
            Messages = new List<Message>();
        }
    }

}
