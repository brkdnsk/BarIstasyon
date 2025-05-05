using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeCommands;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeHandlers;
using Microsoft.AspNetCore.Mvc;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeesController : ControllerBase  // ControllerBase, API controller'ları için daha uygun bir sınıftır.
    {
        private readonly CreateCoffeeCommandHandler _createCoffeeCommandHandler;

        public CoffeesController(CreateCoffeeCommandHandler createCoffeeCommandHandler)
        {
            _createCoffeeCommandHandler = createCoffeeCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoffee([FromBody] CreateCoffeeCommand command)  // [FromBody] parametresi ekledim
        {
            if (command == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            try
            {
                await _createCoffeeCommandHandler.Handle(command);
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
