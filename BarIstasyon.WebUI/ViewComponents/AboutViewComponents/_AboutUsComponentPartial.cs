using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;
using BarIstasyon.Dto.AboutDtos;

namespace BarIstasyon.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AboutUsComponentPartial(IHttpClientFactory httpClientFactor)
		{
			_httpClientFactory = httpClientFactor;

        }

		public async Task <IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:5001/api/Abouts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}

