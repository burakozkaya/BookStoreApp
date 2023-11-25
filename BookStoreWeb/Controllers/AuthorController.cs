using BookStoreWeb.Models;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string clientName = "BookStoreApi";
        private readonly JsonService _jsonService;

        public AuthorController(IHttpClientFactory clientFactory, JsonService jsonService)
        {
            _clientFactory = clientFactory;
            _jsonService = jsonService;
        }
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient(clientName);
            var authorResponse = await client.GetAsync("api/Author");
            if (authorResponse.IsSuccessStatusCode)
            {
                var authorJson = await authorResponse.Content.ReadAsStringAsync();
                var authorListVm = _jsonService.Deserialize<List<AuthorListVm>>(authorJson);
                return View(authorListVm);
            }
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _clientFactory.CreateClient(clientName);
            var authorResponse = await client.GetAsync($"api/Author/{id}");
            if (authorResponse.IsSuccessStatusCode)
            {
                var authorJson = await authorResponse.Content.ReadAsStringAsync();
                var authorInsertVm = _jsonService.Deserialize<AuthorInsertVm>(authorJson);
                AuthorUpdateVm authorUpdateVm = new AuthorUpdateVm()
                {
                    Id = id,
                    Name = authorInsertVm.Name
                };
                return View(authorUpdateVm);
            }

            return RedirectToAction("Index", "Author");
        }
        [HttpPost]
        public async Task<IActionResult> Update(AuthorUpdateVm authorUpdateVm)
        {
            var client = _clientFactory.CreateClient(clientName);
            var response = await client.PutAsJsonAsync("api/Author", authorUpdateVm);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Author");

            }
            return View(authorUpdateVm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient(clientName);
            var authorResponse = await client.DeleteAsync($"api/Author/{id}");
            return RedirectToAction("Index");
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(AuthorInsertVm authorInsertVm)
        {
            var client = _clientFactory.CreateClient(clientName);

            var authorResponse = await client.PostAsJsonAsync("api/Author", authorInsertVm);
            if (authorResponse.IsSuccessStatusCode)
                return RedirectToAction("Index", "Author");
            return View();
        }
    }
}
