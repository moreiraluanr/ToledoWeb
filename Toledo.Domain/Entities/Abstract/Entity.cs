namespace Toledo.Domain.Entities
{
    public abstract class Entity<TKey>
    {
        protected Entity()
        {

        }
        public TKey Id { get; set; }
    }
}
