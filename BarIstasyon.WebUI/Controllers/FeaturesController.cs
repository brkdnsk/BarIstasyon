using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.FeatureCommands;
using BarIstasyon.Business.Features.CQRS.Handlers.FeatureHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateFeatureCommandHandler _createFeatureCommandHandler;

        public FeaturesController(CreateFeatureCommandHandler createFeatureCommandHandler)
        {
            _createFeatureCommandHandler = createFeatureCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureCommand command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createFeatureCommandHandler.Handle(command);
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
