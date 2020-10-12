using Toledo.Domain.Entities;

namespace Toledo.Domain.Repository
{
    public interface IEmployeeRepository : IPerson<Employee, int>
    {
    }
}
