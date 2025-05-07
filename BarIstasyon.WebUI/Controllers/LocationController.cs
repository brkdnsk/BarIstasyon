using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.LocationCommands;
using BarIstasyon.Business.Features.CQRS.Handlers.LocationHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateLocationCommandHandler _createLocationCommandHandler;

        public LocationController(CreateLocationCommandHandler createLocationCommandHandler)
        {
            _createLocationCommandHandler = createLocationCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createLocationCommandHandler.Handle(command);
                return Ok("Adres Bilgisi Eklendi");
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun yanıt döndürülmesi sağlanır
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}
