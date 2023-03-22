using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgenda
{
    internal class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public Address()
        {
            
        }

        //public Address EditAddress(Address address)
        //{
        //    this.Street = address.Street;
        //    this.City = address.City;
        //    this.PostalCode = address.PostalCode;
        //    this.Country = address.Country;
        //    this.State = address.State;

        //    return this;
        //}

        public void EditStreet(string street)
        {
            this.Street = street;
        }

        public void EditCity(string city)
        {
            this.City = city;
        }

        public void EditState(string state)
        {
            this.State = state;
        }

        public void EditCountry(string country)
        {
            this.Country = country;
        }

        public void EditPostalCode(string postalCode)
        {
            this.PostalCode = postalCode;
        }

        public override string ToString()
        {
            return $"\nEndereço: {this.Street}\nEstado: {this.State}\nCidade: {this.City}\nPais: {this.Country}\nCEP: {this.PostalCode}";
        }

    }
}
