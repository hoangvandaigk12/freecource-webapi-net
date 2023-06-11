using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApilApp.Models;
using MyWebApilApp.Repositories;

namespace MyWebApilApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public ProductsController(Repositories.IBookRepository repo)
        {
            _bookRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            try
            {
                return Ok(await _bookRepo.GetAllBooksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepo.GetBookById(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                var newBookId = await _bookRepo.AddBookAsync(model);
                var book = await _bookRepo.GetBookById(newBookId);
                return book == null ? NotFound() : Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookModel model)
        {
            if(id != model.Id)
            {
                return NotFound();
            }
            await _bookRepo.UpdateBookAsync(id, model); ;
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _bookRepo.DeleteBookAsync(id);
            return Ok();
        }
    }
}
