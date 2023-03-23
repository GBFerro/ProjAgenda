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

        public Address(string street, string city, string state, string country, string postalCode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
        }

        public override string ToString()
        {
            return $"{this.Street};{this.State};{this.City};{this.Country};{this.PostalCode}";
        }

    }
}
