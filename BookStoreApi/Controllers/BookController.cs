using BookStoreApp.BLL.Abstract;
using BookStoreApp.Dto.Dto.BookDto;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var response = await _bookService.GetAllIncludingAllAsync();
            if (response.IsSuccess)
                return Ok(response.Data);
            return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var response = await _bookService.GetByIdAsync(id);
            if (response.IsSuccess)
                return Ok(response.Data);
            return BadRequest();

        }
        [HttpPost]
        public async Task<IActionResult> PostBook(BookInsertDto insertDto)
        {
            var response = await _bookService.AddAsync(insertDto);
            if (response.IsSuccess)
                return Ok();
            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> PutBook(BookUpdateDto bookUpdateDto)
        {
            var TempLate = await _bookService.GetByIdAsync(bookUpdateDto.Id);


            var response = await _bookService.UpdateAsync(bookUpdateDto);
            if (response.IsSuccess)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.RemoveAsync(id);
            if (response.IsSuccess)
                return Ok();
            return BadRequest();
        }

    }
}
