using Microsoft.EntityFrameworkCore;
using System;
using Toledo.Domain.Entities;
using Toledo.Domain.Repository;
using Toledo.Infra.Context;

namespace Toledo.Infra.Repository
{
    public class EmployeeRepository : PersonRepository<Employee, int>, IEmployeeRepository, IDisposable
    {
        private readonly DbContext _db;
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
            _db = context;
        }
    }
}
