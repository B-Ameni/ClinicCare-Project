using Xunit;
using System;
using System.Linq;
using ClassLibrary1.Services;
using Modeles.Classes;

namespace ClinicProject.Tests
{
    public class TestsTousServices
    {
        // service patient
        [Trait("XrayTestKey", "PTD-46")]
        [Fact]
        public void PatientService_AddNull()
        {
            var service = new PatientService();
            Assert.Throws<ArgumentNullException>(() => service.Add(null));
        }

        [Fact]
        public void PatientService_AddSanstNom()
        {
            var service = new PatientService();
            var p = new Patient { Nom = "", Prenom = "Test" };
            var ex = Assert.Throws<Exception>(() => service.Add(p));
            Assert.Equal("Nom obligatoire", ex.Message);
        }

        [Fact]
        public void PatientService_UpdateInvalide()
        {
            var service = new PatientService();
            var p = new Patient { Id = 0, Nom = "A", Prenom = "B" };
            var ex = Assert.Throws<Exception>(() => service.Update(p));
            Assert.Equal("Patient invalide", ex.Message);
        }

        [Fact]
        public void PatientService_DeleteIdInvalide()
        {
            var service = new PatientService();
            var ex = Assert.Throws<Exception>(() => service.Delete(0));
            Assert.Equal("Id invalide", ex.Message);
        }

        // service medecin
        [Fact]
        public void MedecinService_AddNull()
        {
            var service = new MedecinService();
            Assert.Throws<ArgumentNullException>(() => service.Add(null));
        }
        [Fact]
        public void MedecinService_AddSansNom()
        {
            var service = new MedecinService();
            var m = new Medecin { Nom = "", Prenom = "Test" };
            var ex = Assert.Throws<Exception>(() => service.Add(m));
            Assert.Equal("Nom obligatoire", ex.Message);
        }

        [Fact]
        public void MedecinService_UpdateIdInvalide()
        {
            var service = new MedecinService();
            var m = new Medecin { Id = 0, Nom = "Test" };
            var ex = Assert.Throws<Exception>(() => service.Update(m));
            Assert.Equal("Médecin invalide", ex.Message);
        }

        [Fact]
        public void MedecinService_DeleteIdInvalide()
        {
            var service = new MedecinService();
            var ex = Assert.Throws<Exception>(() => service.Delete(0));
            Assert.Equal("Id invalide", ex.Message);
        }

        // service responsable

        [Fact]
        public void ResponsableService_AddNull()
        {
            var service = new ResponsableService();
            Assert.Throws<ArgumentNullException>(() => service.Add(null));
        }
        [Fact]
        public void ResponsableService_AddSansNom()
        {
            var service = new ResponsableService();
            var r = new ResponsablePatient { Nom = "", Prenom = "Test" };
            var ex = Assert.Throws<Exception>(() => service.Add(r));
            Assert.Equal("Nom obligatoire", ex.Message);
        }

        [Fact]
        public void ResponsableService_UpdateIdInvalide()
        {
            var service = new ResponsableService();
            var r = new ResponsablePatient { Id = 0, Nom = "A" };
            var ex = Assert.Throws<Exception>(() => service.Update(r));
            Assert.Equal("Responsable invalide", ex.Message);
        }

        [Fact]
        public void ResponsableService_DeleteIdInvalide()
        {
            var service = new ResponsableService();
            var ex = Assert.Throws<Exception>(() => service.Delete(0));
            Assert.Equal("Id invalide", ex.Message);
        }

        // service admin
        [Fact]
        public void AdminService_AddNull()
        {
            var service = new AdministrateurService();
            Assert.Throws<ArgumentNullException>(() => service.Add(null));
        }
        [Fact]
        public void AdministrateurService_AddSansName()
        {
            var service = new AdministrateurService();
            var a = new Administrateur { Nom = "", Prenom = "Test" };
            var ex = Assert.Throws<Exception>(() => service.Add(a));
            Assert.Equal("Nom obligatoire", ex.Message);
        }

        [Fact]
        public void AdministrateurService_UpdateIdInvalide()
        {
            var service = new AdministrateurService();
            var a = new Administrateur { Id = 0, Nom = "Test" };
            var ex = Assert.Throws<Exception>(() => service.Update(a));
            Assert.Equal("Administrateur invalide", ex.Message);
        }

        [Fact]
        public void AdministrateurService_DeleteIdInvalide()
        {
            var service = new AdministrateurService();
            var ex = Assert.Throws<Exception>(() => service.Delete(0));
            Assert.Equal("Id invalide", ex.Message);
        }

        // service rdv
        [Fact]
        public void RendezVousService_AddNull()
        {
            var service = new RendezVousService();
            Assert.Throws<ArgumentNullException>(() => service.Add(null));
        }

        [Fact]
        public void RendezVousService_UpdateIdInvalide()
        {
            var service = new RendezVousService();
            var rdv = new RendezVous { Id = 0, PatientId = 1, MedecinId = 1 };
            var ex = Assert.Throws<Exception>(() => service.Update(rdv));
            Assert.Equal("Rendez-vous invalide", ex.Message);
        }

        [Fact]
        public void RendezVousService_DeleteIdInvalide()
        {
            var service = new RendezVousService();
            var ex = Assert.Throws<Exception>(() => service.Delete(0));
            Assert.Equal("Id invalide", ex.Message);
        }
        [Fact]
        public void Add_RendezVousDatePassee()
        {
            var service = new RendezVousService();
            var rdv = new RendezVous(1, 1, DateTime.Now.AddDays(-1));

            Assert.Throws<ArgumentException>(() => service.Add(rdv));
        }
        [Fact]
        public void Add_RendezVous_IdPatientInvalide()
        {
            var service = new RendezVousService();
            var rdv = new RendezVous(0, 1, DateTime.Now);

            Assert.Throws<ArgumentException>(() => service.Add(rdv));
        }
        [Fact]
        public void Add_RendezVous_StatutVide()
        {
            var rdv = new RendezVous(1, 1, DateTime.Now);
            rdv.Statut = "";

            Assert.Throws<ArgumentException>(() => new RendezVousService().Add(rdv));
        }
        // service dossier medical
        [Fact]
        public void DossierMedicalService_AddNull()
        {
            var service = new DossierMedicalService();
            Assert.Throws<ArgumentNullException>(() => service.Add(null));
        }

        [Fact]
        public void DossierMedicalService_UpdateIdInvalide()
        {
            var service = new DossierMedicalService();
            var d = new DossierMedical { Id = 0, PatientId = 1 };
            var ex = Assert.Throws<Exception>(() => service.Update(d));
            Assert.Equal("Dossier invalide", ex.Message);
        }

        [Fact]
        public void DossierMedicalService_DeleteIdInvalide()
        {
            var service = new DossierMedicalService();
            var ex = Assert.Throws<Exception>(() => service.Delete(0));
            Assert.Equal("Id invalide", ex.Message);
        }

        // service message
        [Fact]
        public void MessageService_AddNull()
        {
            var service = new MessageService();
            Assert.Throws<ArgumentNullException>(() => service.Add(null));
        }

        [Fact]
        public void MessageService_UpdateIdInvalide()
        {
            var service = new MessageService();
            var m = new Message { Id = 0, ExpediteurId = 1, TypeExpediteur = "Patient" };
            var ex = Assert.Throws<Exception>(() => service.Update(m));
            Assert.Equal("Message invalide", ex.Message);
        }

        [Fact]
        public void MessageService_DeleteIdInvalide()
        {
            var service = new MessageService();
            var ex = Assert.Throws<Exception>(() => service.Delete(0));
            Assert.Equal("Id invalide", ex.Message);
        }
    }
}
