using AutoMapper;
using Toledo.Aplication.Model;
using Toledo.Domain.Entities;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase
{
    public class AlterEmployeeUseCase : IUseCase<AlterEmployeeRequest>
    {
        private readonly IEmployeeRepository _repository;

        private readonly IMapper _mapper;

        public AlterEmployeeUseCase(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Execute(AlterEmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);
            _repository.Alter(employee);
        }
    }
}
