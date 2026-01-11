using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace DAL
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            Batteries.Init();
            CreatePatientTable();
            CreateMedecinTable();
            CreateResponsableTable();
            CreateAdministrateurTable();
            CreateRendezVousTable();
            CreateDossierMedicalTable();
            CreateMessageTable();
            CreateDefaultAdminIfNotExists();
        }

        public static void CreatePatientTable()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Patient(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nom TEXT NOT NULL,
                            Prenom TEXT NOT NULL,
                            DateNaissance TEXT,
                            Email TEXT,
                            Telephone TEXT,
                            Adresse TEXT,
                            MotDePasse TEXT
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CreateMedecinTable()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Medecin(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nom TEXT NOT NULL,
                            Prenom TEXT NOT NULL,
                            Specialite TEXT,
                            Email TEXT,
                            MotDePasse TEXT
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CreateResponsableTable()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS ResponsablePatient(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nom TEXT NOT NULL,
                            Prenom TEXT NOT NULL,
                            Specialite TEXT,
                            Email TEXT,
                            MotDePasse TEXT
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CreateAdministrateurTable()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Administrateur(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nom TEXT NOT NULL,
                            Prenom TEXT NOT NULL,
                            Email TEXT,
                            MotDePasse TEXT
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CreateRendezVousTable()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS RendezVous(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            PatientId INTEGER NOT NULL,
                            MedecinId INTEGER NOT NULL,
                            DateHeure TEXT,
                            Statut TEXT,
                            FOREIGN KEY(PatientId) REFERENCES Patient(Id),
                            FOREIGN KEY(MedecinId) REFERENCES Medecin(Id)
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CreateDossierMedicalTable()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS DossierMedical(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            PatientId INTEGER NOT NULL,
                            MedecinId INTEGER,
                            ResponsableId INTEGER,
                            Observations TEXT,
                            Fichiers TEXT,
                            DateCreation TEXT,
                            FOREIGN KEY(PatientId) REFERENCES Patient(Id),
                            FOREIGN KEY(MedecinId) REFERENCES Medecin(Id),
                            FOREIGN KEY(ResponsableId) REFERENCES ResponsablePatient(Id)
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CreateMessageTable()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Message(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            ExpediteurId INTEGER NOT NULL,
                            TypeExpediteur TEXT NOT NULL,
                            DestinataireId INTEGER NOT NULL,
                            TypeDestinataire TEXT NOT NULL,
                            Contenu TEXT,
                            DateEnvoi TEXT
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void CreateDefaultAdminIfNotExists()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                // Vérifier s'il existe déjà un admin
                using (var checkCmd = conn.CreateCommand())
                {
                    checkCmd.CommandText = "SELECT COUNT(*) FROM Administrateur";
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count > 0)
                        return; // Admin existe déjà → on sort
                }

                // Insérer l'admin par défaut
                using (var insertCmd = conn.CreateCommand())
                {
                    insertCmd.CommandText = @"
                INSERT INTO Administrateur (Nom, Prenom, Email, MotDePasse)
                VALUES (@nom, @prenom, @email, @mdp);
            ";

                    insertCmd.Parameters.AddWithValue("@nom", "admin");
                    insertCmd.Parameters.AddWithValue("@prenom", "admin");
                    insertCmd.Parameters.AddWithValue("@email", "admin");
                    insertCmd.Parameters.AddWithValue("@mdp", "admin"); // à hasher plus tard

                    insertCmd.ExecuteNonQuery();
                }
            }
        }

    }
}
