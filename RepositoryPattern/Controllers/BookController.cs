using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core;
using RepositoryPattern.Core.Constants;
using RepositoryPattern.Core.Models;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }
        [HttpGet("GetAllBooksAsync")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            return Ok(await _unitOfWork.Books.GetAllAsync());
        }

        [HttpGet("GetbookByName")]
        public IActionResult GetBookByName()
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == "book", new[] { "Author" }));
        }

        [HttpGet("GetAllBooksWithAuthors")]
        public IActionResult GetAllBooksWithAuthors()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("book"), new[] { "Author" }));
        }
        [HttpGet("GetOrderedBook")]
        public IActionResult GetOrderedBooks()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("book"), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "book3", AuthorId = 1 });
            _unitOfWork.Complete();
            return Ok(book);
        }

        [HttpPost("AddManyBooks")]
        public IActionResult AddManyBooks()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { Title = "book 4", AuthorId = 1 });
            books.Add(new Book { Title = "book 5", AuthorId = 1 });
            books.Add(new Book { Title = "book 6", AuthorId = 1 });

            var res = _unitOfWork.Books.Addrange(books);
            _unitOfWork.Complete();

            return Ok(res);
        }
    }
}
