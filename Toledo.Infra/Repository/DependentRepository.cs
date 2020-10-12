using System;
using Toledo.Domain.Entities;
using Toledo.Domain.Repository;
using Toledo.Infra.Context;

namespace Toledo.Infra.Repository
{
    public class DependentRepository : PersonRepository<Dependent, int>, IDependentRepository, IDisposable
    {
        public DependentRepository(DependentContext context) : base(context)
        {
            
        }
    }
}
