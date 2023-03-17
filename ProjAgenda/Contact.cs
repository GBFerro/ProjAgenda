using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgenda
{
    internal class Contact
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(string name, string phone)
        {
            this.Name = name;
            this.Address = new Address();
            this.Phone = phone;
        }

        //public Contact(string name, Address address, string phone, string email)
        //{
        //    this.Name = name;
        //    this.Address = address;
        //    this.Phone = phone;
        //    this.Email = email;
        //}

        public void EditPhone(string phone)
        {
            this.Phone = phone;
        }

        public void EditEmail(string email)
        {
            this.Email = email;
        }

       

        public override string ToString()
        {
            return $"Nome: {this.Name}\nTelefone: {this.Phone}\nEmail: {this.Email}\n{this.Address}\n\n";
        }
    }
}
