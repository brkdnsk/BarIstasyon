using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.FeatureCommands;
using BarIstasyon.Business.Features.CQRS.Queries.FeatureQueries;
using BarIstasyon.Business.Features.CQRS.Handlers.FeatureHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly CreateFeatureCommandHandler _createFeatureCommandHandler;
        private readonly GetAllFeatureQueryHandler _getAllFeatureQueryHandler;
        private readonly UpdateFeatureCommandHandler _updateFeatureCommandHandler;
        private readonly RemoveFeatureCommandHandler _removeFeatureCommandHandler;
        private readonly GetFeatureByIdQueryHandler _getFeatureByIdQueryHandler;

        public FeaturesController(
            CreateFeatureCommandHandler createFeatureCommandHandler,
            GetAllFeatureQueryHandler getAllFeatureQueryHandler,
            UpdateFeatureCommandHandler updateFeatureCommandHandler,
            RemoveFeatureCommandHandler removeFeatureCommandHandler,
            GetFeatureByIdQueryHandler getFeatureByIdQueryHandler)
        {
            _createFeatureCommandHandler = createFeatureCommandHandler;
            _getAllFeatureQueryHandler = getAllFeatureQueryHandler;
            _updateFeatureCommandHandler = updateFeatureCommandHandler;
            _removeFeatureCommandHandler = removeFeatureCommandHandler;
            _getFeatureByIdQueryHandler = getFeatureByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeature(string id, [FromBody] UpdateFeatureCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.FeatureID = objectId;
                await _updateFeatureCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createFeatureCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeatures()
        {
            try
            {
                var result = await _getAllFeatureQueryHandler.Handle(new GetAllFeatureQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemoveFeatureCommand(objectId);
                await _removeFeatureCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getFeatureByIdQueryHandler.Handle(new GetFeatureByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
