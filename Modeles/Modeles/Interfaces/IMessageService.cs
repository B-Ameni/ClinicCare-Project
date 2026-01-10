using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Modeles.Interfaces
{
    public interface IMessageService
    {
        void EnvoyerMessage(Message message);
        List<Message> GetMessagesParUtilisateur(int userId, string typeUtilisateur);
    }
}
