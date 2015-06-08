using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Models
{
    public class ClientModel
    {
        public ClientModel()
        {

        }

        public ClientModel(Client model)
        {
            IdClient = model.IdClient;
            Name = model.Name;
            SurName = model.Surname;
            Patronymic = model.Patronymic;
            Phone = model.Phone;
            Mail = model.Mail;
            Password = model.Password;
            PasswordSalt = model.PasswordSalt;
            IsAdmin = model.IsAdmin;
        }

        public int IdClient { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public bool? IsAdmin { get; set; }
    }
}