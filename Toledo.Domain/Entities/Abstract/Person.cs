using System;
using Toledo.Domain.Enums;

namespace Toledo.Domain.Entities
{
    public abstract class Person : Entity<int>
    {
        protected Person() { }
        protected Person(string name, string document, DateTime dateBirth, EGender gender)
        {
            Name = name;
            Document = document;
            DateBirth = dateBirth;
            Gender = gender;
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public DateTime DateBirth { get; private set; }
        public EGender Gender { get; private set; }
    }
}
