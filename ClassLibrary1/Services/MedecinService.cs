using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles.Classes;


namespace ClassLibrary1.Services
{
    public class MedecinService
    {
        private readonly MedecinRepository repo;

        public MedecinService()
        {
            repo = new MedecinRepository();
        }

        public List<Medecin> GetAll()
        {
            return repo.GetAll();
        }

        public void Add(Medecin m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            if (string.IsNullOrWhiteSpace(m.Nom))
                throw new Exception("Nom obligatoire");

            repo.Add(m);
        }

        public void Update(Medecin m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            if (m.Id <= 0)
                throw new Exception("Médecin invalide");

            repo.Update(m);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id invalide");

            repo.Delete(id);
        }
    }
}