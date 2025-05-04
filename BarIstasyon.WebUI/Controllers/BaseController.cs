using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BarIstasyon.Business.Features.CQRS.Commands.BaseCommands;

using BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateBaseCommandHandler _createBaseCommandHandler;

        public BaseController(CreateBaseCommandHandler createBaseCommandHandler)
        {
            _createBaseCommandHandler = createBaseCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBase([FromBody] CreateBaseCommand command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createBaseCommandHandler.Handle(command);
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
