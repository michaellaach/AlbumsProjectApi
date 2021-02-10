using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business.Models.Album;
using MusicLibrary.Business.Services;
using MusicLibrary.Business.Services.Interfaces;


namespace OnlineLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _albumService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _albumService.GetById(id);

            if (result == null)
            {
                return NotFound("Object with the provided id does not exist");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAlbumModel model)
        {
            await _albumService.InsertAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlbumModel model)
        {
            var result = _albumService.GetById(model.Id);

            if (result == null)
            {
                return NotFound("Object with the provided id does not exist");
            }

            await _albumService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _albumService.GetById(id);

            if (result == null)
            {
                return NotFound("Object with the provided id does not exist");
            }

            await _albumService.RemoveAsync(id);

            return Ok();
        }
    }
}