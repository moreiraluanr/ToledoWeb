using AutoMapper;
using Toledo.Aplication.Model;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase
{
    public class RemoveDependentUseCase : IUseCase<RemoveDependetRequest>
    {
        private readonly IDependentRepository _repository;
        private readonly IMapper _mapper;

        public RemoveDependentUseCase(IDependentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Execute(RemoveDependetRequest request)
        {
            _repository.Remove(request.Id);
        }
    }
}
