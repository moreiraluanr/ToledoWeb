using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Toledo.Aplication.Model;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase
{
    public class ListEmployeeUseCase : IUseCase<ListEmployeeRequest, IEnumerable<ListEmployeeResponse>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IDependentRepository _repositoDependent;
        private readonly IMapper _mapper;

        public ListEmployeeUseCase(IEmployeeRepository repository, IDependentRepository repositoDependent, IMapper mapper)
        {
            _repository = repository;
            _repositoDependent = repositoDependent;
            _mapper = mapper;
        }

        public IEnumerable<ListEmployeeResponse> Execute(ListEmployeeRequest request)
        {
            var dependents = _repositoDependent.List().ToList().Select(d => d.IdEmployee);
            var employers = _repository.List().ToList();

            if (!string.IsNullOrWhiteSpace(request.Name))
                employers = employers.Where(e => e.Name.Contains(request.Name)).ToList();

            if (request.DateFirst != DateTime.MinValue && request.DateFinish != DateTime.MinValue)
                employers = _repository.List().ToList().Where(e => e.DateBirth >= request.DateFirst && e.DateBirth <= request.DateFinish).ToList();

            if (request.Gender != null)
                employers = employers.Where(e => e.Gender == request.Gender).ToList();

            if (request.Active != null)
                employers = employers.Where(e => e.Active == request.Active).ToList();

            if (request.NoHaveDependent)
                employers = employers.Where(e => !dependents.Contains(e.Id)).ToList();

            return _mapper.Map<IEnumerable<ListEmployeeResponse>>(employers);
        }
    }
}
