using AutoMapper;
using Toledo.Aplication.Model;
using Toledo.Domain.Entities;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase
{
    public class InsertDependetUseCase : IUseCase<InsertDependetRequest>
    {
        private readonly IDependentRepository _respository;
        private readonly IMapper _mapper;

        public InsertDependetUseCase(IDependentRepository respository, IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;
        }

        public void Execute(InsertDependetRequest request)
        {
            var dependent = _mapper.Map<Dependent>(request);
            _respository.Insert(dependent);
        }
    }
}
