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
    private readonly PhoneBookDbContext pBDB;

    public BaseEntityRepository(PhoneBookDbContext pBDB)
    {
        this.pBDB = pBDB;
    }
    public void Add(TEntity entity)
    {
        pBDB.Set<TEntity>().Add(entity);
        pBDB.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        pBDB.Set<TEntity>().Remove(entity);
        pBDB.SaveChanges();
    }

    public TEntity FindById(int id)
    {
        return pBDB.Set<TEntity>().Find(id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return pBDB.Set<TEntity>().AsQueryable();
    }

    public void Update(TEntity entity)
    {
        pBDB.Set<TEntity>().Update(entity);
    }
}