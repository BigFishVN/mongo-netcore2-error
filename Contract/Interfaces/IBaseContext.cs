namespace Contract.Interfaces
{
    using Models.Entities;

    public interface IBaseContext
    {
        IRepository<T> ResolveRepository<T>()
            where T : BaseEntity;
    }
}