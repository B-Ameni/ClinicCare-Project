using ClassLibrary1.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MessageRepository
    {
        // Récupère tous les messages
        public List<Message> GetAll()
        {
            var list = new List<Message>();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, ExpediteurId, TypeExpediteur, DestinataireId, TypeDestinataire, Contenu, DateEnvoi
                        FROM Message";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var msg = new Message
                            {
                                Id = reader.GetInt32(0),
                                ExpediteurId = reader.GetInt32(1),
                                TypeExpediteur = reader.GetString(2),
                                DestinataireId = reader.GetInt32(3),
                                TypeDestinataire = reader.GetString(4),
                                Contenu = reader.GetString(5),
                                DateEnvoi = reader.GetDateTime(6)
                            };
                            list.Add(msg);
                        }
                    }
                }
            }

            return list;
        }

        // Ajoute un nouveau message
        public void Add(Message m)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Message 
                        (ExpediteurId, TypeExpediteur, DestinataireId, TypeDestinataire, Contenu, DateEnvoi)
                        VALUES (@ExpediteurId, @TypeExpediteur, @DestinataireId, @TypeDestinataire, @Contenu, @DateEnvoi)";

                    cmd.Parameters.AddWithValue("@ExpediteurId", m.ExpediteurId);
                    cmd.Parameters.AddWithValue("@TypeExpediteur", m.TypeExpediteur ?? "");
                    cmd.Parameters.AddWithValue("@DestinataireId", m.DestinataireId);
                    cmd.Parameters.AddWithValue("@TypeDestinataire", m.TypeDestinataire ?? "");
                    cmd.Parameters.AddWithValue("@Contenu", m.Contenu ?? "");
                    cmd.Parameters.AddWithValue("@DateEnvoi", m.DateEnvoi);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Met à jour un message existant
        public void Update(Message m)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Message
                        SET ExpediteurId = @ExpediteurId,
                            TypeExpediteur = @TypeExpediteur,
                            DestinataireId = @DestinataireId,
                            TypeDestinataire = @TypeDestinataire,
                            Contenu = @Contenu
                        WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@ExpediteurId", m.ExpediteurId);
                    cmd.Parameters.AddWithValue("@TypeExpediteur", m.TypeExpediteur ?? "");
                    cmd.Parameters.AddWithValue("@DestinataireId", m.DestinataireId);
                    cmd.Parameters.AddWithValue("@TypeDestinataire", m.TypeDestinataire ?? "");
                    cmd.Parameters.AddWithValue("@Contenu", m.Contenu ?? "");
                    cmd.Parameters.AddWithValue("@Id", m.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Supprime un message par Id
        public void Delete(int id)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Message WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
