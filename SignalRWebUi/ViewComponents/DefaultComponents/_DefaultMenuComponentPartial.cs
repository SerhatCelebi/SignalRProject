using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUi.Dtos.ProductDtos;
using SignalRWebUi.Dtos.SliderDtos;

namespace SignalRWebUi.ViewComponents.DefaultComponents
{
    public class _DefaultMenuComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var respongeMessage = await client.GetAsync("https://localhost:7071/api/Product");


            var jsonData = await respongeMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);



        }
    }
}
