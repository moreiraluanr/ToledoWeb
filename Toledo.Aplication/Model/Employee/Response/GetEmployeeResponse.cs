using System;
using Toledo.Domain.Enums;

namespace Toledo.Aplication.Model
{
    public class GetEmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime DateBirth { get; set; }
        public EGender Gender { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public string Place { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Neighborhood { get; set; }
        public bool Active { get; set; }
    }
}
