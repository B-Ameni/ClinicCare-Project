using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles.Classes;


namespace ClassLibrary1.Services
{
    public class RendezVousService
    {
        private readonly RendezVousRepository repo;
        private readonly PatientService patientService;
        private readonly MedecinService medecinService;

        public RendezVousService()
        {
            repo = new RendezVousRepository();
            patientService = new PatientService();    
            medecinService = new MedecinService();
        }

        public List<RendezVous> GetAll()
        {
            return repo.GetAll();
        }

        public void Add(RendezVous rdv)
        {
            if (rdv == null)
                throw new ArgumentNullException(nameof(rdv));

            repo.Add(rdv);
        }

        public void Update(RendezVous rdv)
        {
            if (rdv == null)
                throw new ArgumentNullException(nameof(rdv));
            if (rdv.Id <= 0)
                throw new Exception("Rendez-vous invalide");

            repo.Update(rdv);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id invalide");

            repo.Delete(id);
        }

        public List<RendezVous> GetByDate(DateTime date)
        {
            return repo.GetByDate(date);
        }

        public RendezVous GetById(int id)
        {
            return repo.GetById(id);
        }
        public string GetPatientName(int patientId)
        {
            var patient = patientService.GetAll().FirstOrDefault(p => p.Id == patientId);
            return patient != null ? $"{patient.Nom} {patient.Prenom}" : "Inconnu";
        }

        public string GetMedecinName(int medecinId)
        {
            var medecin = medecinService.GetAll().FirstOrDefault(m => m.Id == medecinId);
            return medecin != null ? $"{medecin.Nom} {medecin.Prenom}" : "Inconnu";
        }
    }

}
