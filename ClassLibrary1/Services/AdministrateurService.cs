using Modeles.Classes;
using DAL.Repositories;
using System;
using System.Collections.Generic;

namespace ClassLibrary1.Services
{
    public class AdministrateurService
    {
        private readonly AdministrateurRepository repo;

        public AdministrateurService()
        {
            repo = new AdministrateurRepository();
        }

        public List<Administrateur> GetAll()
        {
            return repo.GetAll();
        }

        public void Add(Administrateur a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (string.IsNullOrWhiteSpace(a.Nom)) throw new Exception("Nom obligatoire");
            repo.Add(a);
        }

        public void Update(Administrateur a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (a.Id <= 0) throw new Exception("Administrateur invalide");
            repo.Update(a);
        }

        public void Delete(int id)
        {
            if (id <= 0) throw new Exception("Id invalide");
            repo.Delete(id);
        }
    }
}
