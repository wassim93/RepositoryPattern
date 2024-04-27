using RepositoryPattern.Core.Models;

namespace RepositoryPattern.Core.Repository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> SpecialMethod();
    }
}
