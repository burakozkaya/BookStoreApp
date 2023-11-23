using BookStoreApp.BLL.Abstract;
using BookStoreApp.Dto.Dto.CategoryDto;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var response = await _categoryService.GetAllIncludingAllAsync();
            if (response.IsSuccess)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GeyByIdCategory(int id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            if (response.IsSuccess)
                return Ok(response.Data);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(CategoryInsertDto insertDto)
        {
            var response = await _categoryService.AddAsync(insertDto);
            if (response.IsSuccess)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _categoryService.RemoveAsync(id);
            if (response.IsSuccess)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> PutCategory(CategoryUpdateDto updateDto)
        {
            var response = await _categoryService.UpdateAsync(updateDto);
            if (response.IsSuccess)
                return Ok();
            return BadRequest();
        }
    }
}
