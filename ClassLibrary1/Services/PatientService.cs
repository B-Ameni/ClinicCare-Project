using ClassLibrary1.Modeles;
using DAL;
using System;
using System.Collections.Generic;

namespace ClassLibrary1.Services
{
    public class PatientService
    {
        private readonly PatientRepository repo;

        public PatientService()
        {
            repo = new PatientRepository();
        }

        public List<Patient> GetAll()
        {
            return repo.GetAll();
        }

        public void Add(Patient p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            if (string.IsNullOrWhiteSpace(p.Nom))
                throw new Exception("Nom obligatoire");

            repo.Add(p);
        }

        public void Update(Patient p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            if (p.Id <= 0)
                throw new Exception("Patient invalide");

            repo.Update(p);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id invalide");

            repo.Delete(id);
        }
    }
}
