using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BarIstasyon.Business.Features.CQRS.Commands.PricingCommands;
using BarIstasyon.Business.Features.CQRS.Commands.ServiceCommands;
using BarIstasyon.Business.Features.CQRS.Handlers.ServiceHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateServiceCommandHandler _createServiceCommandHandler;

        public ServicesController(CreateServiceCommandHandler createServiceCommandHandler)
        {
            _createServiceCommandHandler = createServiceCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createServiceCommandHandler.Handle(command);
                return Ok("Servis Bilgisi Eklendi");
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun yanıt döndürülmesi sağlanır
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}
