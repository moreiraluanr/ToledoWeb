using AutoMapper;
using Toledo.Aplication.Model;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase
{
    public class GetDependentUseCase : IUseCase<GetDependentRequest, GetDependentResponse>
    {
        private readonly IDependentRepository _repository;
        private readonly IMapper _mapper;

        public GetDependentUseCase(IDependentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public GetDependentResponse Execute(GetDependentRequest request)
        {
            var dependent = _repository.Get(request.Id);
            return _mapper.Map<GetDependentResponse>(dependent);
        }
    }
}
