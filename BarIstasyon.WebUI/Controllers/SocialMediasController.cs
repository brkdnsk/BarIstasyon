using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BarIstasyon.Business.Features.CQRS.Commands.PricingCommands;
using BarIstasyon.Business.Features.CQRS.Commands.SocialMediaCommands;
using BarIstasyon.Business.Features.CQRS.Handlers.SocialMediaHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateSocialMediaCommandHandler _createSocialMediaCommandHandler;

        public SocialMediasController(CreateSocialMediaCommandHandler createSocialMediaCommandHandler)
        {
            _createSocialMediaCommandHandler = createSocialMediaCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia([FromBody] CreateSocialMediaCommand command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createSocialMediaCommandHandler.Handle(command);
                return Ok("Sosyal Medya Bilgisi Eklendi");
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun yanıt döndürülmesi sağlanır
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}
