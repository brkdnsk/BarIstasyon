using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeDescriptionHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeDescriptionsController : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateCoffeeDescriptionCommandHandler _createCoffeeDescriptionCommandHandler;

        public CoffeeDescriptionsController(CreateCoffeeDescriptionCommandHandler createCoffeeDescriptionCommandHandler)
        {
            _createCoffeeDescriptionCommandHandler = createCoffeeDescriptionCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoffeeDescription([FromBody] CreateCoffeeDescriptionCommand command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createCoffeeDescriptionCommandHandler.Handle(command);
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
