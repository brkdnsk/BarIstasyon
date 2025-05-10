using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeeFeaturesQueries;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeatureHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeaturesHandlers;


namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeFeaturesController : ControllerBase
        
    {
        private readonly CreateCoffeeFeatureCommandHandler _createCoffeeFeatureCommandHandler;
        private readonly GetCoffeeFeaturesQueryHandler _getAllCoffeeFeatureQueryHandler;
        private readonly UpdateCoffeeFeatureCommandHandler _updateCoffeeFeatureCommandHandler;
        private readonly RemoveCoffeeFeatureCommandHandler _removeCoffeeFeatureCommandHandler;
        private readonly GetAllCoffeeFeaturesByIdQueryHandler _getCoffeeFeatureByIdQueryHandler;

        public CoffeeFeaturesController(
            CreateCoffeeFeatureCommandHandler createCoffeeFeatureCommandHandler,
            GetCoffeeFeaturesQueryHandler getAllCoffeeFeatureQueryHandler,
            UpdateCoffeeFeatureCommandHandler updateCoffeeFeatureCommandHandler,
            RemoveCoffeeFeatureCommandHandler removeCoffeeFeatureCommandHandler,
            GetAllCoffeeFeaturesByIdQueryHandler getCoffeeFeatureByIdQueryHandler)
        {
            _createCoffeeFeatureCommandHandler = createCoffeeFeatureCommandHandler;
            _getAllCoffeeFeatureQueryHandler = getAllCoffeeFeatureQueryHandler;
            _updateCoffeeFeatureCommandHandler = updateCoffeeFeatureCommandHandler;
            _removeCoffeeFeatureCommandHandler = removeCoffeeFeatureCommandHandler;
            _getCoffeeFeatureByIdQueryHandler = getCoffeeFeatureByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoffeeFeatures(string id, [FromBody] UpdateCoffeeFeatureCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.CoffeeFeatureID = objectId;
                await _updateCoffeeFeatureCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoffeeFeature([FromBody] CreateCoffeeFeatureCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createCoffeeFeatureCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoffeeFeatures()
        {
            try
            {
                var result = await _getAllCoffeeFeatureQueryHandler.Handle(new GetAllCoffeeFeatureQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffeeFeatures(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemoveCoffeeFeatureCommand(objectId);
                await _removeCoffeeFeatureCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoffeeFeatureById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getCoffeeFeatureByIdQueryHandler.Handle(new GetCoffeeFeatureByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
