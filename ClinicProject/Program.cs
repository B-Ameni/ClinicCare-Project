using System;
using System.Windows.Forms;
using ClassLibrary1.Modeles;
using ClinicProject.Auth;
using DAL;
using Modeles.Classes;

namespace ClinicProject
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1️⃣ Initialisation de la base SQLite
            DatabaseInitializer.Initialize();

            // 2️⃣ Responsable de test (simulation login)
            ResponsablePatient responsableTest = new ResponsablePatient
            {
                Id = 1, // ⚠️ IMPORTANT : doit exister en BD
                Nom = "b",
                Prenom = "b",
                Specialite = "b",
                Email = "@b",
                MotDePasse = "b"
            };

            // 3️⃣ Initialisation WinForms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 4️⃣ Lancement de la messagerie
           // Application.Run(new MessagerieResp(responsableTest));
           Application.Run(new Authentification());
        }
    }
}
