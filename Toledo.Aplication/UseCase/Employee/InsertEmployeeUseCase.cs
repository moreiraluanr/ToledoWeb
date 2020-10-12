using AutoMapper;
using Toledo.Aplication.Model;
using Toledo.Domain.Entities;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase
{
    public class InsertEmployeeUseCase : IUseCase<InsertEmployeeRequest>
    {
        private readonly IEmployeeRepository _repository;

        private readonly IMapper _mapper;
        public InsertEmployeeUseCase(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Execute(InsertEmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);
            _repository.Insert(employee);
        }
    }
}
