using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetCore.Domain.Data;

namespace NetCore.Infrastructure.Data;

public class DatabaseRepository<TEntity> : IDatabaseRepository<TEntity> where TEntity : class
{
    private readonly DatabaseContext context;
    private readonly DbSet<TEntity> entities;

    public DatabaseRepository(DatabaseContext context)
    {
        this.context = context;
        this.entities = context.Set<TEntity>();
    }

    public TEntity Insert(TEntity entity)
    {
        EntityEntry<TEntity> dbEntityEntry = this.entities.Add(entity);
        this.context.SaveChanges();

        return dbEntityEntry.Entity;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return this.entities.ToList();
    }

    public TEntity? GetById(int id)
    {
        //!TODO: need to look into for dynamic fetch
        return this.entities.Find(id);
    }

    public void Update(TEntity entity)
    {
        this.entities.Update(entity);
        this.context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        this.entities.Remove(entity);
        this.context.SaveChanges();
    }
}