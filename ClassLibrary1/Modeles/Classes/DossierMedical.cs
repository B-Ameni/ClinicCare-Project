using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Modeles
{
    public class DossierMedical
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int? MedecinId { get; set; }
        public int? ResponsableId { get; set; }
        public string Observations { get; set; }
        public string Fichiers { get; set; }
        public DateTime DateCreation { get; set; }


        public DossierMedical()
        {
            DateCreation = DateTime.Now;
        }


        public DossierMedical(int patientId)
        {
            PatientId = patientId;
            DateCreation = DateTime.Now;
        }
    }

}
