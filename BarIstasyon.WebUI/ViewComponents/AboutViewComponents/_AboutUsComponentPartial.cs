using System;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebUI.ViewComponents.AboutViewComponents
{
	public class _AboutUsComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

