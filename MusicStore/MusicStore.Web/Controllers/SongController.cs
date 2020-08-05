using Microsoft.AspNetCore.Mvc;
using MusicStore.Core.DTOs;
using MusicStore.Core.Entities;
using MusicStore.Core.Interfaces;
using System.Threading.Tasks;

namespace MusicStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService songService;
        public SongController(ISongService songService)
        {
            this.songService = songService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var operationResult = await songService.GetAll();
            if (!operationResult.IsSuccess)
            {
                return NotFound(operationResult.Message);
            }
            return Ok(operationResult.Result);
        }

        [HttpGet("{searchTerm}")]
        public async Task<IActionResult> GetByArtist(string searchTerm)
        {
            var operationResult = await songService.GetByArtist(searchTerm);
            if (!operationResult.IsSuccess)
            {
                return NotFound(operationResult.Message);
            }
            return Ok(operationResult.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SongDTO songDTO)
        {
            var operationResult = await songService.Save(songDTO);
            if (!operationResult.IsSuccess)
            {
                return NotFound(operationResult.Message);
            }
            return Ok(operationResult.Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var operationResult = await songService.Delete(id);
            if (!operationResult.IsSuccess)
            {
                return NotFound(operationResult.Message);
            }
            return NoContent();
        }
    }
}