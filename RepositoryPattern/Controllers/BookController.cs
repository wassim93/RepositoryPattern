using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Constants;
using RepositoryPattern.Core.Models;
using RepositoryPattern.Core.Repository;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseRepository<Book> _bookRepository;
        public BookController(IBaseRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_bookRepository.GetById(1));
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookRepository.GetAll());
        }
        [HttpGet("GetAllBooksAsync")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            return Ok(await _bookRepository.GetAllAsync());
        }

        [HttpGet("GetbookByName")]
        public IActionResult GetBookByName()
        {
            return Ok(_bookRepository.Find(b => b.Title == "book", new[] { "Author" }));
        }

        [HttpGet("GetAllBooksWithAuthors")]
        public IActionResult GetAllBooksWithAuthors()
        {
            return Ok(_bookRepository.FindAll(b => b.Title.Contains("book"), new[] { "Author" }));
        }
        [HttpGet("GetOrderedBook")]
        public IActionResult GetOrderedBooks()
        {
            return Ok(_bookRepository.FindAll(b => b.Title.Contains("book"), null, null, b => b.Id, OrderBy.Descending));
        }
    }
}
