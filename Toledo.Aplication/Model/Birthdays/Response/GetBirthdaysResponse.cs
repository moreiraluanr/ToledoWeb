using System;
using Toledo.Domain.Enums;

namespace Toledo.Aplication.Model
{
    public class GetBirthdaysResponse
    {
        public string Name { get; private set; }
        public string Document { get; private set; }
        public DateTime DateBirth { get; private set; }
        public EGender Gender { get; private set; }
    }
}
