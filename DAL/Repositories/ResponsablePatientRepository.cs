using ClassLibrary1.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles.Classes;


namespace DAL.Repositories
{
    public class ResponsablePatientRepository
    {
        public List<ResponsablePatient> GetAll()
        {
            var list = new List<ResponsablePatient>();
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ResponsablePatient";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ResponsablePatient
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

        public void Add(ResponsablePatient r)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO ResponsablePatient 
                        (Nom,Prenom,Specialite,Email,MotDePasse) 
                        VALUES (@n,@p,@s,@e,@m)";
                    cmd.Parameters.AddWithValue("@n", r.Nom);
                    cmd.Parameters.AddWithValue("@p", r.Prenom);
                    cmd.Parameters.AddWithValue("@s", r.Specialite);
                    cmd.Parameters.AddWithValue("@e", r.Email);
                    cmd.Parameters.AddWithValue("@m", r.MotDePasse);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(ResponsablePatient r)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE ResponsablePatient
                        SET Nom=@n,Prenom=@p,Specialite=@s,Email=@e,MotDePasse=@m
                        WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@n", r.Nom);
                    cmd.Parameters.AddWithValue("@p", r.Prenom);
                    cmd.Parameters.AddWithValue("@s", r.Specialite);
                    cmd.Parameters.AddWithValue("@e", r.Email);
                    cmd.Parameters.AddWithValue("@m", r.MotDePasse);
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
                    cmd.CommandText = "DELETE FROM ResponsablePatient WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
