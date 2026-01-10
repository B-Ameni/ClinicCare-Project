using ClassLibrary1.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DossierMedicalRepository
    {
        // Récupère tous les dossiers médicaux
        public List<DossierMedical> GetAll()
        {
            var list = new List<DossierMedical>();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, PatientId, MedecinId, ResponsableId, Observations, Fichiers, DateCreation FROM DossierMedical";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dossier = new DossierMedical
                            {
                                Id = reader.GetInt32(0),
                                PatientId = reader.GetInt32(1),
                                MedecinId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                                ResponsableId = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                                Observations = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Fichiers = reader.IsDBNull(5) ? null : reader.GetString(5),
                                DateCreation = reader.GetDateTime(6)
                            };
                            list.Add(dossier);
                        }
                    }
                }
            }

            return list;
        }

        // Ajoute un nouveau dossier médical
        public void Add(DossierMedical d)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO DossierMedical (PatientId, MedecinId, ResponsableId, Observations, Fichiers, DateCreation)
                        VALUES (@PatientId, @MedecinId, @ResponsableId, @Observations, @Fichiers, @DateCreation)";
                    cmd.Parameters.AddWithValue("@PatientId", d.PatientId);
                    cmd.Parameters.AddWithValue("@MedecinId", d.MedecinId.HasValue ? (object)d.MedecinId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ResponsableId", d.ResponsableId.HasValue ? (object)d.ResponsableId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Observations", d.Observations ?? "");
                    cmd.Parameters.AddWithValue("@Fichiers", d.Fichiers ?? "");
                    cmd.Parameters.AddWithValue("@DateCreation", d.DateCreation);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Met à jour un dossier médical existant
        public void Update(DossierMedical d)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE DossierMedical
                        SET PatientId = @PatientId,
                            MedecinId = @MedecinId,
                            ResponsableId = @ResponsableId,
                            Observations = @Observations,
                            Fichiers = @Fichiers
                        WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@PatientId", d.PatientId);
                    cmd.Parameters.AddWithValue("@MedecinId", d.MedecinId.HasValue ? (object)d.MedecinId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ResponsableId", d.ResponsableId.HasValue ? (object)d.ResponsableId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Observations", d.Observations ?? "");
                    cmd.Parameters.AddWithValue("@Fichiers", d.Fichiers ?? "");
                    cmd.Parameters.AddWithValue("@Id", d.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Supprime un dossier médical par Id
        public void Delete(int id)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM DossierMedical WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
