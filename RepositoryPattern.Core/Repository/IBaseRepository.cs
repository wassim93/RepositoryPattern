using RepositoryPattern.Core.Constants;
using System.Linq.Expressions;

namespace RepositoryPattern.Core.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, Object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        T Add(T entity);
        IEnumerable<T> Addrange(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);
        void Attach(T entity);
        int Count();
        int Count(Expression<Func<T, bool>> criteria);

    }
}
