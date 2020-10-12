using System;
using Toledo.Domain.Enums;

namespace Toledo.Domain.Entities
{
    public class Employee : Person
    {
        private Employee()
        {}

        public Employee(
            string name, 
            string document, 
            DateTime dateBirth, 
            EGender gender, 
            string phone, 
            string zipCode, 
            string place,
            string city,
            string state,
            string neighborhood,
            bool active) : base(name, document, dateBirth, gender)
        {
            Phone = phone;
            ZipCode = zipCode;
            Place = place;
            City = city;
            State = state;
            Neighborhood = neighborhood;
            Active = active;
        }

        public string Phone { get; private set; }
        public string ZipCode { get; private set; }
        public string Place { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Neighborhood { get; private set; }
        public bool Active { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
