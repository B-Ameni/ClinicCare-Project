using ClassLibrary1.Modeles;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles.Classes;


namespace ClassLibrary1.Services
{
    public class ResponsableService
    {
        private readonly ResponsablePatientRepository repo;

        public ResponsableService()
        {
            repo = new ResponsablePatientRepository();
        }

        public List<ResponsablePatient> GetAll()
        {
            return repo.GetAll();
        }

        public void Add(ResponsablePatient r)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));
            if (string.IsNullOrWhiteSpace(r.Nom))
                throw new Exception("Nom obligatoire");

            repo.Add(r);
        }

        public void Update(ResponsablePatient r)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));
            if (r.Id <= 0)
                throw new Exception("Responsable invalide");

            repo.Update(r);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id invalide");

            repo.Delete(id);
        }
    }
}
