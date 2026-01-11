using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeles.Classes
{
    public class RendezVous
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedecinId { get; set; }
        public DateTime DateHeure { get; set; }
        public string Statut { get; set; }


        public RendezVous()
        {
            Statut = "Programmé";
        }


        public RendezVous(int patientId, int medecinId, DateTime dateHeure)
        {
            PatientId = patientId;
            MedecinId = medecinId;
            DateHeure = dateHeure;
            Statut = "Programmé";
        }
    }

}
