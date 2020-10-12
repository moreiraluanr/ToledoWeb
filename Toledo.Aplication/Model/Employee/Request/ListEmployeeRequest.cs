using System;
using Toledo.Domain.Enums;

namespace Toledo.Aplication.Model
{
    public class ListEmployeeRequest
    {
        public string Name { get; set; }
        public DateTime DateFirst { get; set; }
        public DateTime DateFinish { get; set; }
        public EGender? Gender { get; set; }
        public bool? Active { get; set; }
        public bool NoHaveDependent { get; set; }
    }
}
