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
        private readonly IConfiguration _configuration;
        private readonly JsonService _jsonService;

        public BookController(IHttpClientFactory clientFactory, IConfiguration configuration, JsonService jsonService)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            _jsonService = jsonService;
        }
        public async Task<IActionResult> Index()
        {
            List<BookListVm>? bookListVm;
            var client = _clientFactory.CreateClient(clientName);
            bookListVm = await client.GetFromJsonAsync<List<BookListVm>>("Book");

            return View(bookListVm);
        }

        public async Task<IActionResult> Insert()
        {
            var client = _clientFactory.CreateClient(clientName);
            var tempAuthor = await client.GetAsync("Author");
            //<List<AuthorListVm>> <List<CategoryListVm>>
            var tempCat = await client.GetAsync("Category");
            if (tempAuthor.IsSuccessStatusCode && tempAuthor.IsSuccessStatusCode)
            {
                var authorJson = await tempAuthor.Content.ReadAsStringAsync();
                var categoryJson = await tempCat.Content.ReadAsStringAsync();

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

            var response = await client.PostAsJsonAsync("book", bookInsertVm);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Book");


            return View(bookInsertVm);
        }


        public async Task<IActionResult> Update(int id)
        {
            var client = _clientFactory.CreateClient(clientName);

            var tempAuthor = await client.GetFromJsonAsync<List<AuthorListVm>>("Author");

            var tempCat = await client.GetFromJsonAsync<List<CategoryListVm>>("Category");

            var bookUpdateVm = await client.GetFromJsonAsync<BookUpdateVm>($"Book/{id}");

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


            var response = await client.PutAsJsonAsync("Book", bookUpdateVm);
            if (response.IsSuccessStatusCode)
                return View(bookUpdateVm);
            return RedirectToAction("Index", "Book");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient(clientName);
            var response = await client.DeleteAsync($"Book/{id}");

            return RedirectToAction("Index", "Book");

        }
    }
}
