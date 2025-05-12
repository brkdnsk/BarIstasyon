using System;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _NavbarUILayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
		
	}
}

