using BookStoreWeb.Models;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient _client;
        private readonly JsonService _jsonService;

        public BookController(IHttpClientFactory clientFactory, JsonService jsonService)
        {
            _client = clientFactory.CreateClient("BookStoreApi");
            _jsonService = jsonService;
        }
        public async Task<IActionResult> Index()
        {
            var bookResponse = await _client.GetAsync("api/Book");
            if (bookResponse.IsSuccessStatusCode)
            {
                var bookJson = await bookResponse.Content.ReadAsStringAsync();
                var bookListVm = _jsonService.Deserialize<List<BookListVm>>(bookJson);
                return View(bookListVm);
            }

            return View();
        }

        public async Task<IActionResult> Insert()
        {
            var authorResponse = await _client.GetAsync("api/Author");
            var categoryResponse = await _client.GetAsync("api/Category");
            if (authorResponse.IsSuccessStatusCode && authorResponse.IsSuccessStatusCode)
            {
                var authorJson = await authorResponse.Content.ReadAsStringAsync();
                var categoryJson = await categoryResponse.Content.ReadAsStringAsync();

                var authorList = _jsonService.Deserialize<List<AuthorListVm>>(authorJson);
                var categoryList = _jsonService.Deserialize<List<CategoryListVm>>(categoryJson);
                ViewBag.AuthorSelectItem = authorList.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()

                });
                ViewBag.CategorySelectItem = categoryList.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(BookInsertVm bookInsertVm)
        {

            var response = await _client.PostAsJsonAsync("api/book", bookInsertVm);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Book");

            return View(bookInsertVm);
        }


        public async Task<IActionResult> Update(int id)
        {

            var tempAuthor = await _client.GetFromJsonAsync<List<AuthorListVm>>("api/Author");

            var tempCat = await _client.GetFromJsonAsync<List<CategoryListVm>>("api/Category");

            var bookUpdateVm = await _client.GetFromJsonAsync<BookUpdateVm>($"api/Book/{id}");

            ViewBag.AuthorSelectItem = tempAuthor.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()

            });
            ViewBag.CategorySelectItem = tempCat.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View(bookUpdateVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BookUpdateVm bookUpdateVm)
        {


            var response = await _client.PutAsJsonAsync("api/Book", bookUpdateVm);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Book");
            return RedirectToAction("Update", "Book", bookUpdateVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _client.DeleteAsync($"api/Book/{id}");
            TempData["Delete"] = response.IsSuccessStatusCode;
            return RedirectToAction("Index", "Book");
        }
    }
}
