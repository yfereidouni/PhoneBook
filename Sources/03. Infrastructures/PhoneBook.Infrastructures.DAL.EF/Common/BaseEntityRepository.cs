using PB.Core.Contracts.Common;
using PB.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Infrastructures.DAL.EF.Common;

public abstract class BaseEntityRepository<TEntity> : IBaseEntityRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly PhoneBookDbContext phoneBookDbContext;

    public BaseEntityRepository(PhoneBookDbContext phoneBookDbContext)
    {
        this.phoneBookDbContext = phoneBookDbContext;
    }
    public void Add(TEntity entity)
    {
        phoneBookDbContext.Set<TEntity>().Add(entity);
        phoneBookDbContext.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        phoneBookDbContext.Set<TEntity>().Remove(entity);
        phoneBookDbContext.SaveChanges();
    }

    public TEntity FindById(int id)
    {
        return phoneBookDbContext.Set<TEntity>().Find(id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return phoneBookDbContext.Set<TEntity>().AsQueryable();
    }

    public void Update(TEntity entity)
    {
        phoneBookDbContext.Set<TEntity>().Update(entity);
    }
}