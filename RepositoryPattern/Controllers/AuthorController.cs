using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Models;
using RepositoryPattern.Core.Repository;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBaseRepository<Author> _authorRepository;
        public AuthorController(IBaseRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_authorRepository.GetById(1));
        }
        [HttpGet("GetbyIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _authorRepository.GetByIdAsync(1));
        }
    }
}
