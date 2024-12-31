using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using SignalRWebUi.Dtos.ContactDtos;


namespace SignalRWebUi.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _UILayoutFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var respongeMessage = await client.GetAsync("https://localhost:7071/api/Contact");


            var jsonData = await respongeMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return View(values);



        }
    }
}
