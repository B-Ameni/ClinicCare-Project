using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Modeles
{
    public class Message
    {
        public int Id { get; set; }
        public int ExpediteurId { get; set; }
        public string TypeExpediteur { get; set; }
        public int DestinataireId { get; set; }
        public string TypeDestinataire { get; set; }
        public string Contenu { get; set; }
        public DateTime DateEnvoi { get; set; }


        public Message()
        {
            DateEnvoi = DateTime.Now;
        }


        public Message(int expediteurId, string typeExpediteur, int destinataireId, string typeDestinataire, string contenu)
        {
            ExpediteurId = expediteurId;
            TypeExpediteur = typeExpediteur;
            DestinataireId = destinataireId;
            TypeDestinataire = typeDestinataire;
            Contenu = contenu;
            DateEnvoi = DateTime.Now;
        }
    }

}
