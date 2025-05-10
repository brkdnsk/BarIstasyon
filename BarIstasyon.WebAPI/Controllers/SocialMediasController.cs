using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.SocialMediaCommands;
using BarIstasyon.Business.Features.CQRS.Queries.SocialMediaQueries;
using BarIstasyon.Business.Features.CQRS.Handlers.SocialMediaHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly CreateSocialMediaCommandHandler _createSocialMediaCommandHandler;
        private readonly GetAllSocialMediaQueryHandler _getAllSocialMediaQueryHandler;
        private readonly UpdateSocialMediaCommandHandler _updateSocialMediaCommandHandler;
        private readonly RemoveSocialMediaCommandHandler _removeSocialMediaCommandHandler;
        private readonly GetSocialMediaByIdQueryHandler _getSocialMediaByIdQueryHandler;

        public SocialMediasController(
            CreateSocialMediaCommandHandler createSocialMediaCommandHandler,
            GetAllSocialMediaQueryHandler getAllSocialMediaQueryHandler,
            UpdateSocialMediaCommandHandler updateSocialMediaCommandHandler,
            RemoveSocialMediaCommandHandler removeSocialMediaCommandHandler,
            GetSocialMediaByIdQueryHandler getSocialMediaByIdQueryHandler)
        {
            _createSocialMediaCommandHandler = createSocialMediaCommandHandler;
            _getAllSocialMediaQueryHandler = getAllSocialMediaQueryHandler;
            _updateSocialMediaCommandHandler = updateSocialMediaCommandHandler;
            _removeSocialMediaCommandHandler = removeSocialMediaCommandHandler;
            _getSocialMediaByIdQueryHandler = getSocialMediaByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialMedia(string id, [FromBody] UpdateSocialMediaCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.SocialMediaID = objectId;
                await _updateSocialMediaCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia([FromBody] CreateSocialMediaCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createSocialMediaCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSocialMedias()
        {
            try
            {
                var result = await _getAllSocialMediaQueryHandler.Handle(new GetAllSocialMediaQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemoveSocialMediaCommand(objectId);
                await _removeSocialMediaCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getSocialMediaByIdQueryHandler.Handle(new GetSocialMediaByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
