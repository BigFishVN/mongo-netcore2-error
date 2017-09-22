namespace Contract.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Contract.Interfaces;

    using Models.Interfaces;

    using MongoDB.Driver;

    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected IDbBuilder DbBuilder { get; }

        protected IMongoCollection<T> MongoCollection { get; set; }

        protected IMongoDatabase MongoDatabase { get; set; }

        public BaseRepository(IDbBuilder builder)
        {
            DbBuilder = builder;
            Task.WaitAll(Initialize());
        }

        protected async Task Initialize()
        {
            GetDatabase();
            GetCollection();
            if (MongoCollection != null)
            {
                await CreateIndex();
            }
        }

        protected void GetDatabase()
        {
            var client = new MongoClient(DbBuilder.GetConnectionString());
            MongoDatabase = client.GetDatabase(DbBuilder.GetDatabaseName());
        }

        protected void GetCollection()
        {
            var type = typeof(T);
            if (MongoCollection == null)
            {
                MongoCollection = MongoDatabase.GetCollection<T>(type.Name);
            }
        }

        protected virtual async Task CreateIndex()
        {
            try
            {
                await MongoCollection.Indexes.CreateOneAsync(
                    Builders<T>.IndexKeys.Descending(x => x.Code).Descending(x => x.Id),
                    new CreateIndexOptions { Name = "code_id" });
                await MongoCollection.Indexes.CreateOneAsync(
                    Builders<T>.IndexKeys.Descending(x => x.Name).Descending(x => x.Id),
                    new CreateIndexOptions { Name = "name_id" });
            }
            catch (Exception)
            {
                // nothing
            }
        }

        public async Task Add(T entity)
        {
            await MongoCollection.InsertOneAsync(entity);
        }

        public async Task AddMany(ICollection<T> entities)
        {
            await MongoCollection.InsertManyAsync(entities);
        }

        public async Task BulkInsert(ICollection<T> entities)
        {
            var stores = new List<WriteModel<T>>();

            stores.AddRange(entities.Select(x => new InsertOneModel<T>(x)));

            await MongoCollection.BulkWriteAsync(stores);
        }

        public async Task<long> Count(Expression<Func<T, bool>> filter)
        {
            return await MongoCollection.CountAsync(filter);
        }

        public async Task Delete(T entity)
        {
            await MongoCollection.DeleteOneAsync(Builders<T>.Filter.Eq(e => e.Id, entity.Id));
            
        }

        public async Task Delete(Expression<Func<T, bool>> filter)
        {
            await MongoCollection.DeleteOneAsync(filter);
        }

        public async Task<ICollection<T>> GetByExpression(Expression<Func<T, bool>> filter, SortDefinition<T> sort = null, ProjectionDefinition<T> projection = null)
        {
            var findFluent = BuildFindFluent(filter, sort, projection);
            return await findFluent.ToListAsync();
        }

        public async Task<ICollection<T>> GetAll(SortDefinition<T> sort = null, ProjectionDefinition<T> projection = null)
        {
            var findFluent = BuildFindFluent(_ => true, sort, projection);
            return await findFluent.ToListAsync();
        }

        public async Task<ICollection<T>> GetByPageAndQuantity(
            int page,
            int quantity,
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null)
        {
            var findFluent = BuildFindFluent(filter, sort, projection);
            return await findFluent.Limit(quantity).Skip((page - 1) * quantity).ToListAsync();
        }

        public async Task<T> GetSingleByExpression(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null,
            int index = 1)
        {
            var findFluent = BuildFindFluent(filter, sort, projection);
            return await findFluent.Limit(1).Skip(index - 1).FirstOrDefaultAsync();
        }

        protected IFindFluent<T, T> BuildFindFluent(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null)
        {
            var fluent = MongoCollection.Find(filter);
            if (projection != null)
            {
                fluent.Options.Projection = Builders<T>.Projection.Combine(projection);
            }

            if (sort != null)
            {
                fluent.Sort(sort);
            }

            return fluent;
        }
    }
}