using ClassLibrary1.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RendezVousRepository
    {
        public List<RendezVous> GetAll()
        {
            var list = new List<RendezVous>();
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM RendezVous";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new RendezVous
                            {
                                Id = reader.GetInt32(0),
                                PatientId = reader.GetInt32(1),
                                MedecinId = reader.GetInt32(2),
                                DateHeure = reader.IsDBNull(3) ? DateTime.MinValue : DateTime.Parse(reader.GetString(3)),
                                Statut = reader.IsDBNull(4) ? "Programmé" : reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Add(RendezVous r)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO RendezVous
                        (PatientId,MedecinId,DateHeure,Statut)
                        VALUES (@pid,@mid,@d,@s)";
                    cmd.Parameters.AddWithValue("@pid", r.PatientId);
                    cmd.Parameters.AddWithValue("@mid", r.MedecinId);
                    cmd.Parameters.AddWithValue("@d", r.DateHeure.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@s", r.Statut);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(RendezVous r)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE RendezVous
                        SET PatientId=@pid,MedecinId=@mid,DateHeure=@d,Statut=@s
                        WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@pid", r.PatientId);
                    cmd.Parameters.AddWithValue("@mid", r.MedecinId);
                    cmd.Parameters.AddWithValue("@d", r.DateHeure.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@s", r.Statut);
                    cmd.Parameters.AddWithValue("@id", r.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM RendezVous WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<RendezVous> GetByDate(DateTime date)
        {
            var list = new List<RendezVous>();
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM RendezVous WHERE Date(DateHeure)=@date";
                    cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new RendezVous
                            {
                                Id = reader.GetInt32(0),
                                PatientId = reader.GetInt32(1),
                                MedecinId = reader.GetInt32(2),
                                DateHeure = reader.IsDBNull(3) ? DateTime.MinValue : DateTime.Parse(reader.GetString(3)),
                                Statut = reader.IsDBNull(4) ? "Programmé" : reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public RendezVous GetById(int id)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM RendezVous WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new RendezVous
                            {
                                Id = reader.GetInt32(0),
                                PatientId = reader.GetInt32(1),
                                MedecinId = reader.GetInt32(2),
                                DateHeure = reader.IsDBNull(3) ? DateTime.MinValue : DateTime.Parse(reader.GetString(3)),
                                Statut = reader.IsDBNull(4) ? "Programmé" : reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}