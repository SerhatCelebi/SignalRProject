using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUi.Dtos.BasketDtos;
using System.Text;

namespace SignalRWebUi.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var respongeMessage = await client.GetAsync("https://localhost:7071/api/Basket/BasketListByMenuTableWithProductName?id=1");
            if (respongeMessage.IsSuccessStatusCode)
            {
                var jsonData = await respongeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        
    }
}
