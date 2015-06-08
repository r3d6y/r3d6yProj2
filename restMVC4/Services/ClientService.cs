using restMVC4.Models;
using restMVC4.Repositories;
using restMVC4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Services
{
    public class ClientService : IClientService
    {
        private readonly BaseRepository<Client> clientRepository;
        public ClientService()
        {
            clientRepository = new BaseRepository<Client>();
        }

        public Client Insert(ClientModel model)
        {
            Client client = CopyClientFromModel(model);
            clientRepository.Insert(ref client);
            return client;
        }

        public bool Delete(int id)
        {
            var client = clientRepository.FirstOrDefault(c => c.IdClient == id);
            if (client != null)
                return clientRepository.Delete(client);
            else
                return false;
        }

        public IEnumerable<Client> List()
        {
            return clientRepository.ToList();
        }

        public Client GetById(int id)
        {
            return clientRepository.FirstOrDefault(c => c.IdClient == id);
        }

        public Client GetByEmail(string email)
        {
            return clientRepository.FirstOrDefault(c => c.Mail == email);
        }

        public void Update(ClientModel model)
        {
            Client client = CopyClientFromModel(model);
            clientRepository.Update(client);
        }

        private Client CopyClientFromModel(ClientModel model)
        {
            Client client = new Client();
            client.IdClient = model.IdClient;
            client.Mail = model.Mail;
            client.Name = model.Name;
            client.Password = model.Password;
            client.PasswordSalt = model.PasswordSalt;
            client.Patronymic = model.Patronymic;
            client.Phone = model.Phone;
            client.Surname = model.SurName;
            client.IsAdmin = false;

            return client;
        }
    }
}