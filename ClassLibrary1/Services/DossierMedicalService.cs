using Modeles.Classes;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Services
{
    public class DossierMedicalService
    {
        private readonly DossierMedicalRepository repo;

        public DossierMedicalService()
        {
            repo = new DossierMedicalRepository();
        }

        public List<DossierMedical> GetAll()
        {
            return repo.GetAll();
        }

        public void Add(DossierMedical d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));

            repo.Add(d);
        }

        public void Update(DossierMedical d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));
            if (d.Id <= 0)
                throw new Exception("Dossier invalide");

            repo.Update(d);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id invalide");

            repo.Delete(id);
        }
    }
}
