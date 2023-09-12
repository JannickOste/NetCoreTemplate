namespace App.Core.Domain.Database;

public interface IDatabaseRepository<TEntity> 
{
    TEntity? GetById(int id);
    IEnumerable<TEntity> GetAll();

    TEntity Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}