using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.LocationCommands;
using BarIstasyon.Business.Features.CQRS.Queries.LocationQueries;
using BarIstasyon.Business.Features.CQRS.Handlers.LocationHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly CreateLocationCommandHandler _createLocationCommandHandler;
        private readonly GetAllLocationQueryHandler _getAllLocationQueryHandler;
        private readonly UpdateLocationCommandHandler _updateLocationCommandHandler;
        private readonly RemoveLocationCommandHandler _removeLocationCommandHandler;
        private readonly GetLocationByIdQueryHandler _getLocationByIdQueryHandler;

        public LocationsController(
            CreateLocationCommandHandler createLocationCommandHandler,
            GetAllLocationQueryHandler getAllLocationQueryHandler,
            UpdateLocationCommandHandler updateLocationCommandHandler,
            RemoveLocationCommandHandler removeLocationCommandHandler,
            GetLocationByIdQueryHandler getLocationByIdQueryHandler)
        {
            _createLocationCommandHandler = createLocationCommandHandler;
            _getAllLocationQueryHandler = getAllLocationQueryHandler;
            _updateLocationCommandHandler = updateLocationCommandHandler;
            _removeLocationCommandHandler = removeLocationCommandHandler;
            _getLocationByIdQueryHandler = getLocationByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(string id, [FromBody] UpdateLocationCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.LocationID = objectId;
                await _updateLocationCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createLocationCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                var result = await _getAllLocationQueryHandler.Handle(new GetAllLocationQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemoveLocationCommand(objectId);
                await _removeLocationCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getLocationByIdQueryHandler.Handle(new GetLocationByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
