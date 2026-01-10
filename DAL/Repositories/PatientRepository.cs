using ClassLibrary1.Modeles;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class PatientRepository
    {
        public List<Patient> GetAll()
        {
            var list = new List<Patient>();
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Patient";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Patient
                            {
                                Id = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                                Prenom = reader.GetString(2),
                                DateNaissance = reader.IsDBNull(3) ? DateTime.MinValue : DateTime.Parse(reader.GetString(3)),
                                Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Telephone = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                Adresse = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                MotDePasse = reader.IsDBNull(7) ? "" : reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Add(Patient p)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Patient 
                        (Nom,Prenom,DateNaissance,Email,Telephone,Adresse,MotDePasse) 
                        VALUES (@n,@p,@d,@e,@t,@a,@m)";
                    cmd.Parameters.AddWithValue("@n", p.Nom);
                    cmd.Parameters.AddWithValue("@p", p.Prenom);
                    cmd.Parameters.AddWithValue("@d", p.DateNaissance.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@e", p.Email);
                    cmd.Parameters.AddWithValue("@t", p.Telephone);
                    cmd.Parameters.AddWithValue("@a", p.Adresse);
                    cmd.Parameters.AddWithValue("@m", p.MotDePasse);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Patient p)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Patient
                        SET Nom=@n, Prenom=@p, DateNaissance=@d, Email=@e, Telephone=@t, Adresse=@a, MotDePasse=@m
                        WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@n", p.Nom);
                    cmd.Parameters.AddWithValue("@p", p.Prenom);
                    cmd.Parameters.AddWithValue("@d", p.DateNaissance.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@e", p.Email);
                    cmd.Parameters.AddWithValue("@t", p.Telephone);
                    cmd.Parameters.AddWithValue("@a", p.Adresse);
                    cmd.Parameters.AddWithValue("@m", p.MotDePasse);
                    cmd.Parameters.AddWithValue("@id", p.Id);
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
                    cmd.CommandText = "DELETE FROM Patient WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
