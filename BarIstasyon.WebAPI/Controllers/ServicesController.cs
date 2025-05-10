using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.ServiceCommands;
using BarIstasyon.Business.Features.CQRS.Queries.ServiceQueries;
using BarIstasyon.Business.Features.CQRS.Handlers.ServiceHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly CreateServiceCommandHandler _createServiceCommandHandler;
        private readonly GetAllServiceQueryHandler _getAllServiceQueryHandler;
        private readonly UpdateServiceCommandHandler _updateServiceCommandHandler;
        private readonly RemoveServiceCommandHandler _removeServiceCommandHandler;
        private readonly GetServiceByIdQueryHandler _getServiceByIdQueryHandler;

        public ServicesController(
            CreateServiceCommandHandler createServiceCommandHandler,
            GetAllServiceQueryHandler getAllServiceQueryHandler,
            UpdateServiceCommandHandler updateServiceCommandHandler,
            RemoveServiceCommandHandler removeServiceCommandHandler,
            GetServiceByIdQueryHandler getServiceByIdQueryHandler)
        {
            _createServiceCommandHandler = createServiceCommandHandler;
            _getAllServiceQueryHandler = getAllServiceQueryHandler;
            _updateServiceCommandHandler = updateServiceCommandHandler;
            _removeServiceCommandHandler = removeServiceCommandHandler;
            _getServiceByIdQueryHandler = getServiceByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(string id, [FromBody] UpdateServiceCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.ServiceID = objectId;
                await _updateServiceCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createServiceCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            try
            {
                var result = await _getAllServiceQueryHandler.Handle(new GetAllServiceQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemoveServiceCommand(objectId);
                await _removeServiceCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getServiceByIdQueryHandler.Handle(new GetServiceByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
