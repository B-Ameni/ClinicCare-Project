using ClassLibrary1.Modeles;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modeles.Classes;


namespace ClassLibrary1.Services
{
    public class MessageService
    {
        private readonly MessageRepository repo;

        public MessageService()
        {
            repo = new MessageRepository();
        }

        public List<Message> GetAll()
        {
            return repo.GetAll();
        }

        public void Add(Message m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));

            repo.Add(m);
        }

        public void Update(Message m)
        {
            if (m == null)
                throw new ArgumentNullException(nameof(m));
            if (m.Id <= 0)
                throw new Exception("Message invalide");

            repo.Update(m);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id invalide");

            repo.Delete(id);
        }
        public List<Message> GetConversation(
    int userId,
    string userType,
    int otherId,
    string otherType)
        {
            return repo.GetConversation(userId, userType, otherId, otherType);
        }

    }
}
