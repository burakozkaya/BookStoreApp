using BookStoreWeb.Models;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string clientName = "BookStoreApi";
        private readonly JsonService _jsonService;

        public BookController(IHttpClientFactory clientFactory, JsonService jsonService)
        {
            _clientFactory = clientFactory;
            _jsonService = jsonService;
        }
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient(clientName);
            var bookResponse = await client.GetAsync("api/Book");
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
            var client = _clientFactory.CreateClient(clientName);
            var authorResponse = await client.GetAsync("api/Author");
            //<List<AuthorListVm>> <List<CategoryListVm>>
            var categoryResponse = await client.GetAsync("api/Category");
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
            var client = _clientFactory.CreateClient(clientName);

            var response = await client.PostAsJsonAsync("api/book", bookInsertVm);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Book");

            return View(bookInsertVm);
        }


        public async Task<IActionResult> Update(int id)
        {
            var client = _clientFactory.CreateClient(clientName);

            var tempAuthor = await client.GetFromJsonAsync<List<AuthorListVm>>("api/Author");

            var tempCat = await client.GetFromJsonAsync<List<CategoryListVm>>("api/Category");

            var bookUpdateVm = await client.GetFromJsonAsync<BookUpdateVm>($"api/Book/{id}");

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
            var client = _clientFactory.CreateClient(clientName);


            var response = await client.PutAsJsonAsync("api/Book", bookUpdateVm);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Book");
            return RedirectToAction("Update", "Book", bookUpdateVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient(clientName);
            var response = await client.DeleteAsync($"api/Book/{id}");
            TempData["Delete"] = response.IsSuccessStatusCode;
            return RedirectToAction("Index", "Book");
        }
    }
}
