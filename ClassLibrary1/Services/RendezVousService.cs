using DAL.Repositories;
using Modeles.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Services
{
    public class RendezVousService
    {
        private readonly RendezVousRepository repo;
        private readonly PatientService patientService;
        private readonly MedecinService medecinService;

        // ===================== CONSTRUCTEUR =====================
        public RendezVousService()
        {
            repo = new RendezVousRepository();
            patientService = new PatientService();
            medecinService = new MedecinService();
        }

        // ===================== CRUD =====================
        public List<RendezVous> GetAll()
        {
            return repo.GetAll();
        }

        public RendezVous GetById(int id)
        {
            if (id <= 0)
                throw new Exception("Id de rendez-vous invalide");

            return repo.GetById(id);
        }

        public List<RendezVous> GetByDate(DateTime date)
        {
            return repo.GetByDate(date);
        }

        public void Add(RendezVous rdv)
        {
            if (rdv == null)
                throw new ArgumentNullException(nameof(rdv));

            VerifierDisponibilite(rdv);
            repo.Add(rdv);
        }

        public void Update(RendezVous rdv)
        {
            if (rdv == null)
                throw new ArgumentNullException(nameof(rdv));
            if (rdv.Id <= 0)
                throw new Exception("Rendez-vous invalide");

            VerifierDisponibilite(rdv);
            repo.Update(rdv);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id invalide");

            repo.Delete(id);
        }

        // ===================== DISPONIBILITÉ =====================

        public bool MedecinDisponible(int medecinId, DateTime dateHeure, int? rdvIdIgnore = null)
        {
            return !repo.GetAll().Any(r =>
                r.MedecinId == medecinId &&
                r.DateHeure == dateHeure &&
                (rdvIdIgnore == null || r.Id != rdvIdIgnore)
            );
        }

        public bool PatientDisponible(int patientId, DateTime dateHeure, int? rdvIdIgnore = null)
        {
            return !repo.GetAll().Any(r =>
                r.PatientId == patientId &&
                r.DateHeure == dateHeure &&
                (rdvIdIgnore == null || r.Id != rdvIdIgnore)
            );
        }

        public void VerifierDisponibilite(RendezVous rdv)
        {
            if (!MedecinDisponible(rdv.MedecinId, rdv.DateHeure, rdv.Id))
                throw new Exception("Le médecin n'est pas disponible à cette date et heure.");

            if (!PatientDisponible(rdv.PatientId, rdv.DateHeure, rdv.Id))
                throw new Exception("Le patient n'est pas disponible à cette date et heure.");
        }

        // ===================== HELPERS UI =====================

        public string GetPatientName(int patientId)
        {
            var patient = patientService.GetAll()
                .FirstOrDefault(p => p.Id == patientId);

            return patient != null
                ? $"{patient.Nom} {patient.Prenom}"
                : "Inconnu";
        }

        public string GetMedecinName(int medecinId)
        {
            var medecin = medecinService.GetAll()
                .FirstOrDefault(m => m.Id == medecinId);

            return medecin != null
                ? $"{medecin.Nom} {medecin.Prenom}"
                : "Inconnu";
        }
        public void UpdateStatut(int rdvId, string statut)
        {
            if (rdvId <= 0)
                throw new Exception("Rendez-vous invalide");

            var rdv = repo.GetById(rdvId);
            if (rdv == null)
                throw new Exception("Rendez-vous introuvable");

            // Mettre à jour uniquement le statut
            rdv.Statut = statut;

            // Sauvegarder la modification dans la base
            repo.Update(rdv);
        }
    }
}
