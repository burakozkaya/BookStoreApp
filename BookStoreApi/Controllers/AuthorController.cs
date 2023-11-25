using BookStoreApp.BLL.Abstract;
using BookStoreApp.Dto.Dto.AuthorDto;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {
            var response = await _authorService.GetAllIncludingAllAsync();
            if (response.IsSuccess)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var response = await _authorService.GetByIdAsync(id);
            if (response.IsSuccess)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }
        [HttpPost]
        public async Task<IActionResult> PostAuthor(AuthorInsertDto insertDto)
        {
            var response = await _authorService.AddAsync(insertDto);
            if (response.IsSuccess)
                return Ok();
            return BadRequest(response.Message);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAuthorById(int id)
        {
            var response = await _authorService.RemoveAsync(id);
            if (response.IsSuccess)
                return Ok();
            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(AuthorUpdateDto insertDto)
        {
            var response = await _authorService.UpdateAsync(insertDto);
            if (response.IsSuccess)
                return Ok();
            return BadRequest(response.Message);
        }

    }
}
