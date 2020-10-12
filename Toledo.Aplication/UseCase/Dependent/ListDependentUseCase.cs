using AutoMapper;
using System.Collections.Generic;
using Toledo.Aplication.Model.Dependent.Request;
using Toledo.Aplication.Model.Dependent.Response;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase
{
    public class ListDependentUseCase : IUseCase<ListDependentRequest, IEnumerable<ListDependentResponse>>
    {
        private readonly IDependentRepository _repository;
        private readonly IMapper _mapper;

        public ListDependentUseCase(IDependentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ListDependentResponse> Execute(ListDependentRequest request)
        {
            var Dependents = _repository.List();
            return _mapper.Map<IEnumerable<ListDependentResponse>>(Dependents);
        }
    }
}
