using System;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebUI.ViewComponents.UILayoutViewComponents
{
	public class _FooterUILayoutComponentPartial : ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

