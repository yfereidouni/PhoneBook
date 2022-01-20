using PhoneBook.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Contracts.Common;

public interface IBaseEntityRepository<TEntity> where TEntity : BaseEntity, new()
{
    TEntity Add(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    TEntity FindById(int id);
    IQueryable<TEntity> GetAll();
    
    //IQueryable<TEntity> GetAll(int pageSize = 4, int pageNumber = 1);
}
