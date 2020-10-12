using AutoMapper;
using System.Collections.Generic;
using Toledo.Aplication.Model;
using Toledo.Aplication.Model.Dependent.Response;
using Toledo.Domain.Entities;

namespace Toledo.Aplication.Mappers
{
    public class AutoMapProfiller : Profile
    {
        public AutoMapProfiller()
        {
            #region Employee
            CreateMap<InsertEmployeeRequest, Employee>();
            CreateMap<AlterEmployeeRequest, Employee>();
            CreateMap<Employee, GetEmployeeResponse>();
            CreateMap<Employee, ListEmployeeResponse>();
            #endregion

            #region Dependent
            CreateMap<InsertDependetRequest, Dependent>();
            CreateMap<AlterDependetRequest, Dependent>();
            CreateMap<Dependent, GetDependentResponse>();
            CreateMap<Dependent, ListDependentResponse>();
            #endregion

            #region Birthdays
            CreateMap<Person, GetBirthdaysResponse>();
            #endregion
        }
    }
}
