namespace Cloud.Repositories.EntityFrameworkCore
{
    public interface IEfCoreRepository<TEntity> : IRepository<TEntity>
         where TEntity : class
    {
    }
}
