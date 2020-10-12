using AutoMapper;
using Toledo.Aplication.Model;
using Toledo.Domain.Repository;

namespace Toledo.Aplication.UseCase
{
    public class GetEmployeeUseCase : IUseCase<GetEmployeeRequest, GetEmployeeResponse>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetEmployeeUseCase(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public GetEmployeeResponse Execute(GetEmployeeRequest request)
        {
            var employee = _repository.Get(request.Id);
            return _mapper.Map<GetEmployeeResponse>(employee);
        }
    }
}
