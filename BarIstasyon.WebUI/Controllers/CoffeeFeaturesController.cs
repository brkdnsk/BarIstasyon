using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeDescriptionHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeaturesHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeFeature : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateCoffeeFeatureCommandHandler _createCoffeeFeatureCommandHandler;

        public CoffeeFeature(CreateCoffeeFeatureCommandHandler createCoffeeFeatureCommandHandler)
        {
            _createCoffeeFeatureCommandHandler = createCoffeeFeatureCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoffeeFeature([FromBody] CreateCoffeeFeatureCommand command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createCoffeeFeatureCommandHandler.Handle(command);
                return Ok("Kahve Açıklaması Bilgisi Eklendi");
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun yanıt döndürülmesi sağlanır
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}
