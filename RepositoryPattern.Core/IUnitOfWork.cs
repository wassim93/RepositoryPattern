﻿using RepositoryPattern.Core.Models;
using RepositoryPattern.Core.Repository;

namespace RepositoryPattern.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IBookRepository Books { get; }
        int Complete();

    }
}
