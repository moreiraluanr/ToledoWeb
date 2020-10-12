using System;
using Toledo.Domain.Enums;

namespace Toledo.Aplication.Model.Dependent.Response
{
    public class ListDependentResponse
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime DateBirth { get; set; }
        public EGender Gender { get; set; }
    }
}
