using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Toledo.Aplication.Model;
using Toledo.Domain.Entities;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase
{
    public class GetBirthdaysUseCase : IUseCase<GetBirthdaysRequest,IEnumerable<GetBirthdaysResponse>>
    {
        private readonly IDependentRepository _repositoryDependet;
        private readonly IEmployeeRepository _repositoryEmployee;
        private readonly IMapper _mapper;

        public GetBirthdaysUseCase(
            IDependentRepository repositoryDependent,
            IEmployeeRepository repositoryEmployee,
            IMapper mapper)
        {
            _repositoryDependet = repositoryDependent;
            _repositoryEmployee = repositoryEmployee;
            _mapper = mapper;
        }

        public IEnumerable<GetBirthdaysResponse> Execute(GetBirthdaysRequest request)
        {
            IEnumerable<Person> dependents = _repositoryDependet.List().Where(d => d.DateBirth.Month == request.Month && d.DateBirth.Day >= DateTime.Now.Day);
            IEnumerable<Person> employers = _repositoryEmployee.List().Where(d => d.DateBirth.Month == request.Month && d.DateBirth.Day >= DateTime.Now.Day);
            return _mapper.Map<IEnumerable<GetBirthdaysResponse>>(dependents.Union(employers));
        }
    }
}
