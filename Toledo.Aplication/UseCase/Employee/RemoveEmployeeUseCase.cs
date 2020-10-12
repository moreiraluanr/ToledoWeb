using AutoMapper;
using Toledo.Aplication.Model;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase.Interface
{
    public class RemoveEmployeeUseCase : IUseCase<RemoveEmployeeRequest>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public RemoveEmployeeUseCase(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Execute(RemoveEmployeeRequest request)
        {
            _repository.Remove(request.Id);
        }
    }
}
