using AutoMapper;
using Toledo.Aplication.Model;
using Toledo.Domain.Entities;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase
{
    public class AlterDependetUseCase : IUseCase<AlterDependetRequest>
    {
        private readonly IDependentRepository _repository;
        private readonly IMapper _mapper;

        public AlterDependetUseCase(IDependentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Execute(AlterDependetRequest request)
        {
            var dependet = _mapper.Map<Dependent>(request);
            _repository.Alter(dependet);
        }
    }
}
