using System;
using Microsoft.AspNetCore.Mvc;

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
				var values = JsonCovert.DeserializeObject<List<>>(jsonData);
			}
			return View();
		}
	}
}

