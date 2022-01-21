namespace PhoneBook.Core.Contracts.Common;

public interface IBaseService<TEntity> where TEntity : class
{
    TEntity Add(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    TEntity FindById(int id);
    IQueryable<TEntity> GetAll();
}