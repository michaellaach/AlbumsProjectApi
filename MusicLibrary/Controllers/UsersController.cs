using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business.Models;
using MusicLibrary.Business.Models.Users;
using MusicLibrary.Business.Services;
using MusicLibrary.Business.Services.Interfaces;

namespace MusicLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IAlbumService _albumService;

        public UsersController(IUsersService usersService, IAlbumService albumService)
        {
            _usersService = usersService;
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _usersService.GetAll();
            return Ok(result);
        }

        [HttpGet("(id)")]
        public IActionResult Get(Guid id)
        {
            var result = _usersService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserModel model)
        {

            await _usersService.InsertAsync(model);

            return Ok("Successfuly created");
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserModel model)
        {

            var result = _usersService.GetById(model.Id);

            if (result == null)
            {
                return BadRequest("Object does not exist");
            }

            await _usersService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _usersService.GetById(id);

            if (result == null)
            {
                return BadRequest("Object does not exist");
            }

            await _usersService.DeleteAsync(id);
            return Ok();
        }


        [HttpGet("{userId}/books")]
       
        public IActionResult GetUserAlbums(Guid userId)
        {
            var user = _usersService.GetUserWithAlbums(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user.Albums);
        }


        [HttpPost("{userId}/albums/{albumId}")]
        public async Task<IActionResult> BoughtAlbum(Guid userId, Guid albumId)
        {
            var user = _usersService.GetUserWithAlbums(userId);
            var album = _albumService.GetById(albumId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (album == null)
            {
                return NotFound("Album not found");
            }

            if (album.QuantityInStock <= 0)
            {
                return BadRequest("There are not enough album in stock");
            }

            if (user.Albums.Any(b => b.Id == albumId))
            {
                return BadRequest("The user has already bought that album");
            }

            await _usersService.BoughtAlbum(userId, albumId);

            return Ok();
        }



    }
}