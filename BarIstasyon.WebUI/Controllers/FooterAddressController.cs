using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.FooterAddressCommands;
using BarIstasyon.Business.Features.CQRS.Handlers.FooterAddressHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateFooterAddressCommandHandler _createFooterAddressCommandHandler;

        public FooterAddressController(CreateFooterAddressCommandHandler createFooterAddressCommandHandler)
        {
            _createFooterAddressCommandHandler = createFooterAddressCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress([FromBody] CreateFooterAddressCommand command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createFooterAddressCommandHandler.Handle(command);
                return Ok("Alt Bilgi Eklendi");
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun yanıt döndürülmesi sağlanır
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}
