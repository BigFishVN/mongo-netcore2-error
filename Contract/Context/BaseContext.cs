namespace Contract.Context
{
    using Contract.Interfaces;
    using Contract.Repositories;

    using Models.Entities;

    public class BaseContext : IBaseContext
    {
        private readonly IDbBuilder builder;

        public BaseContext(IDbBuilder builder)
        {
            this.builder = builder;
        }

        public IRepository<T> ResolveRepository<T>()
            where T : BaseEntity
        {
            return new BaseRepository<T>(builder);
        }
    }
}