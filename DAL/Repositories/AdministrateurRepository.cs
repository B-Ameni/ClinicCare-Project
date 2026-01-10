using ClassLibrary1.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AdministrateurRepository
    {
        public List<Administrateur> GetAll()
        {
            var list = new List<Administrateur>();
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Administrateur";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Administrateur
                            {
                                Id = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                                Prenom = reader.GetString(2),
                                Email = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                MotDePasse = reader.IsDBNull(4) ? "" : reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Add(Administrateur a)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Administrateur 
                        (Nom,Prenom,Email,MotDePasse) 
                        VALUES (@n,@p,@e,@m)";
                    cmd.Parameters.AddWithValue("@n", a.Nom);
                    cmd.Parameters.AddWithValue("@p", a.Prenom);
                    cmd.Parameters.AddWithValue("@e", a.Email);
                    cmd.Parameters.AddWithValue("@m", a.MotDePasse);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Administrateur a)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Administrateur
                        SET Nom=@n,Prenom=@p,Email=@e,MotDePasse=@m
                        WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@n", a.Nom);
                    cmd.Parameters.AddWithValue("@p", a.Prenom);
                    cmd.Parameters.AddWithValue("@e", a.Email);
                    cmd.Parameters.AddWithValue("@m", a.MotDePasse);
                    cmd.Parameters.AddWithValue("@id", a.Id);
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
                    cmd.CommandText = "DELETE FROM Administrateur WHERE Id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
