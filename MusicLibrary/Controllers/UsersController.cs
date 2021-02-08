using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business.Models;
using MusicLibrary.Business.Models.Users;
using MusicLibrary.Business.Services.Interfaces;

namespace MusicLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
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
    

    }
}