using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.BaseCommands;
using BarIstasyon.Business.Features.CQRS.Queries.BaseQueries;
using BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;



namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController : ControllerBase
    {
        private readonly CreateBaseCommandHandler _createBaseCommandHandler;
        private readonly GetAllBaseQueryHandler _getAllBaseQueryHandler;
        private readonly UpdateBaseCommandHandler _updateBaseCommandHandler;
        private readonly RemoveBaseCommandHandler _removeBaseCommandHandler;
        private readonly GetBaseByIdQueryHandler _getBaseByIdQueryHandler;

        public BasesController(
            CreateBaseCommandHandler createBaseCommandHandler,
            GetAllBaseQueryHandler getAllBaseQueryHandler,
            UpdateBaseCommandHandler updateBaseCommandHandler,
            RemoveBaseCommandHandler removeBaseCommandHandler,
            GetBaseByIdQueryHandler getBaseByIdQueryHandler)
        {
            _createBaseCommandHandler = createBaseCommandHandler;
            _getAllBaseQueryHandler = getAllBaseQueryHandler;
            _updateBaseCommandHandler = updateBaseCommandHandler;
            _removeBaseCommandHandler = removeBaseCommandHandler;
            _getBaseByIdQueryHandler = getBaseByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBase(string id, [FromBody] UpdateBaseCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.id = objectId;
                await _updateBaseCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBase([FromBody] CreateBaseCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createBaseCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBases()
        {
            try
            {
                var result = await _getAllBaseQueryHandler.Handle(new GetAllBaseQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBase(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemoveBaseCommand(objectId);
                await _removeBaseCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBaseById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getBaseByIdQueryHandler.Handle(new GetBaseByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
