using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.AboutCommands;
using BarIstasyon.Business.Features.CQRS.Commands.BannerCommands;
using BarIstasyon.Business.Features.CQRS.Handlers.AboutHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.BannerHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateBannerCommandsHandler _createBannersCommandHandler;

        public BannersController(CreateBannerCommandsHandler createBannersCommandHandler)
        {
            _createBannersCommandHandler = createBannersCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner([FromBody] CreateBannerCommands command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createBannersCommandHandler.Handle(command);
                return Ok("Hakkımda Bilgisi Eklendi");
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun yanıt döndürülmesi sağlanır
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}
