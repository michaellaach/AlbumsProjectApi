using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business.Models;
using MusicLibrary.Business.Models.Users;
using MusicLibrary.Business.Services;
using MusicLibrary.Business.Services.Interfaces;
using MusicLibrary.Infrastructure;

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
        [Authorize(Roles = UserRoleConstants.Admin)]
        public IActionResult GetAll()
        {
            var result = _usersService.GetAll();
            return Ok(result);
        }

        [HttpGet("(id)")]
        [Authorize(Roles = UserRoleConstants.Admin)]
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
        [Authorize(Roles = UserRoleConstants.Admin)]
        public async Task<IActionResult> Create(CreateUserModel model)
        {
            if (_usersService.DoesUsernameExist(model.Username))
            {
                return BadRequest("Username already exists");
            }

            await _usersService.InsertAsync(model);

            return Ok("Successfuly created");
        }

        [HttpPut]
        [Authorize(Roles = UserRoleConstants.Admin)]
        public async Task<IActionResult> Put(UserModel model)
        {

            var user = _usersService.GetById(model.Id);


            if (user == null)
            {
                return BadRequest("Object with the provided id does not exist");
            }

            if (model.Username != user.Username && _usersService.DoesUsernameExist(model.Username))
            {
                return BadRequest("Email already exists");
            }

            await _usersService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = UserRoleConstants.Admin)]
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
        [Authorize]
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
        [Authorize]
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