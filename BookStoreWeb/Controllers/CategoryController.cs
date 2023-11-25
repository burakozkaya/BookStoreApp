using BookStoreWeb.Models;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _client;
        private readonly JsonService _jsonService;
        private const string clientName = "BookStoreApi";


        public CategoryController(IHttpClientFactory clientFactory, JsonService jsonService)
        {
            _client = clientFactory.CreateClient(clientName);
            _jsonService = jsonService;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var temp = await response.Content.ReadAsStringAsync();
                var categoryListVm = _jsonService.Deserialize<List<CategoryListVm>>(temp);
                return View(categoryListVm);
            }

            return new EmptyResult();
        }

        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CategoryInsertVm categoryInsertVm)
        {
            var categoryResponse = await _client.PostAsJsonAsync("/api/Category", categoryInsertVm);
            if (categoryResponse.IsSuccessStatusCode)
                return RedirectToAction("Index", "Category");
            return View(categoryInsertVm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryResponse = await _client.DeleteAsync($"/api/Category/{id}");
            return RedirectToAction("Index", "Category");
        }

        public async Task<IActionResult> Update(int id)
        {
            var categoryResponse = await _client.GetAsync($"api/Category/{id}");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
                var categoryUpdateVm = _jsonService.Deserialize<CategoryUpdateVm>(categoryJson);
                categoryUpdateVm.Id = id;
                return View(categoryUpdateVm);
            }

            return RedirectToAction("Index", "Category");

        }
    }
}
