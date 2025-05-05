using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BarIstasyon.Business.Features.CQRS.Commands.CoffeePricingCommands;

using BarIstasyon.Business.Features.CQRS.Handlers.CoffeePricingHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeePricingController : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateCoffeePricingCommandHandler _createCoffeePricingCommandHandler;

        public CoffeePricingController(CreateCoffeePricingCommandHandler _createCoffeePricingCommandHandler)
        {
            _createCoffeePricingCommandHandler = _createCoffeePricingCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoffeePricing([FromBody] CreateCoffeePricingCommand command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createCoffeePricingCommandHandler.Handle(command);
                return Ok("Kahve Fiyat Bilgisi Eklendi");
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun yanıt döndürülmesi sağlanır
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}
