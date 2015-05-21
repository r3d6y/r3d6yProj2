using restMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restMVC4.Services.Interfaces
{
    public interface IClientService
    {
        Client Insert(ClientModel model);
        bool Delete(int id);
        IEnumerable<Client> List();
        Client GetById(int id);
        Client GetByEmail(string email);
        void Update(ClientModel model);
    }
}
