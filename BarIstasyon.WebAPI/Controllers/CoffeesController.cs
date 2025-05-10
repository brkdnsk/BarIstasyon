using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeCommands;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeeQueries;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeesController : ControllerBase
    {
        private readonly CreateCoffeeCommandHandler _createCoffeeCommandHandler;
        private readonly GetAllCoffeeQueryHandler _getAllCoffeeQueryHandler;
        private readonly UpdateCoffeeCommandHandler _updateCoffeeCommandHandler;
        private readonly RemoveCoffeeCommandHandler _removeCoffeeCommandHandler;
        private readonly GetCoffeeByIdQueryHandler _getCoffeeByIdQueryHandler;

        public CoffeesController(
            CreateCoffeeCommandHandler createCoffeeCommandHandler,
            GetAllCoffeeQueryHandler getAllCoffeeQueryHandler,
            UpdateCoffeeCommandHandler updateCoffeeCommandHandler,
            RemoveCoffeeCommandHandler removeCoffeeCommandHandler,
            GetCoffeeByIdQueryHandler getCoffeeByIdQueryHandler)
        {
            _createCoffeeCommandHandler = createCoffeeCommandHandler;
            _getAllCoffeeQueryHandler = getAllCoffeeQueryHandler;
            _updateCoffeeCommandHandler = updateCoffeeCommandHandler;
            _removeCoffeeCommandHandler = removeCoffeeCommandHandler;
            _getCoffeeByIdQueryHandler = getCoffeeByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoffee(string id, [FromBody] UpdateCoffeeCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.CoffeeId = objectId;
                await _updateCoffeeCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoffee([FromBody] CreateCoffeeCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createCoffeeCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoffees()
        {
            try
            {
                var result = await _getAllCoffeeQueryHandler.Handle(new GetAllCoffeeQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffee(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemoveCoffeeCommand(objectId);
                await _removeCoffeeCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoffeeById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getCoffeeByIdQueryHandler.Handle(new GetCoffeeByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
