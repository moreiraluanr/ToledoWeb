using System;
using Toledo.Domain.Enums;

namespace Toledo.Domain.Entities
{
    public class Dependent : Person
    {
        public Dependent() { }
        public Dependent(
            int idEmployee, 
            string name, 
            string document, 
            DateTime dateBirth, 
            EGender gender) : base(name, document, dateBirth, gender) //valida id depois
        {
            IdEmployee = idEmployee;
        }

        public int IdEmployee { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
