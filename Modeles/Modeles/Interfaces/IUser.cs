using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Modeles.Interfaces
{
    public interface IUser 
    {
        int Id { get; set; }
        string Nom { get; set; }
        string Prenom { get; set; }
        string Email { get; set; }
        string MotDePasse { get; set; }
    }
}
