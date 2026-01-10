using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Modeles.Interfaces
{
    public interface IRendezVousService
    {
        void AjouterRendezVous(RendezVous rdv);
        void AnnulerRendezVous(int rendezVousId);
        List<RendezVous> GetRendezVousParPatient(int patientId);
    }
}
