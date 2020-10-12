using System.Collections.Generic;

namespace Toledo.Domain.Repository
{
    public interface IPerson<TEntity,TKey> where TEntity : class
    {
        void Insert(TEntity entity);
        void Alter(TEntity entity);
        TEntity Get(TKey key);
        IEnumerable<TEntity> List();
        void Remove(TKey key);
    }
}
