using ClassLibrary1.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles.Classes;

namespace DAL.Repositories
{
    public class MedecinRepository
    {
        public List<Medecin> GetAll()
        {
            var list = new List<Medecin>();
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Medecin";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Medecin
                            {
                                Id = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                                Prenom = reader.GetString(2),
                                Specialite = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                MotDePasse = reader.IsDBNull(5) ? "" : reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Add(Medecin m)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Medecin 
                        (Nom,Prenom,Specialite,Email,MotDePasse) 
                        VALUES (@n,@p,@s,@e,@m)";
                    cmd.Parameters.AddWithValue("@n", m.Nom);
                    cmd.Parameters.AddWithValue("@p", m.Prenom);
                    cmd.Parameters.AddWithValue("@s", m.Specialite);
                    cmd.Parameters.AddWithValue("@e", m.Email);
                    cmd.Parameters.AddWithValue("@m", m.MotDePasse);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Medecin m)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Medecin
                        SET Nom=@n,Prenom=@p,Specialite=@s,Email=@e,MotDePasse=@m
                        WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@n", m.Nom);
                    cmd.Parameters.AddWithValue("@p", m.Prenom);
                    cmd.Parameters.AddWithValue("@s", m.Specialite);
                    cmd.Parameters.AddWithValue("@e", m.Email);
                    cmd.Parameters.AddWithValue("@m", m.MotDePasse);
                    cmd.Parameters.AddWithValue("@id", m.Id);
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
                    cmd.CommandText = "DELETE FROM Medecin WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
