using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserLogin.API.Common;
using UserLogin.API.ViewModels;
using UserLogin.Domain.Exceptions;
using UserLogin.Services.DTO;
using UserLogin.Services.Interfaces;

namespace UserLogin.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAll();
                return Ok(Responses<IEnumerable<UserDTO>>.SuccessResult(users));

            }
            catch (DomainException e)
            {
                return BadRequest(Responses<dynamic>.DomainErrorMessage(e.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses<dynamic>.ApplicationErrorMessage());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            try
            {
                var user = await _userService.GetById(id);
                return Ok(Responses<UserDTO>.SuccessResult(user));
            }
            catch (DomainException e)
            {
                return BadRequest(Responses<dynamic>.DomainErrorMessage(e.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses<dynamic>.ApplicationErrorMessage());
            }
        }

        [HttpGet("get-by-email")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetByEmail(email);
                return Ok(Responses<UserDTO>.SuccessResult(user));
            }
            catch (DomainException e)
            {
                return BadRequest(Responses<dynamic>.DomainErrorMessage(e.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses<dynamic>.ApplicationErrorMessage());
            }
        }

        [HttpGet("search-by-email")]
        public async Task<IActionResult> SearchUserByEmail([FromQuery] string email)
        {
            try
            {
                var users = await _userService.SearchByEmail(email);
                return Ok(Responses<IEnumerable<UserDTO>>.SuccessResult(users));
            }
            catch (DomainException e)
            {
                return BadRequest(Responses<dynamic>.DomainErrorMessage(e.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses<dynamic>.ApplicationErrorMessage());
            }
        }

        [HttpGet("seach-by-name")]
        public async Task<IActionResult> SearchUserByName([FromQuery] string name)
        {
            try
            {
                var users = await _userService.SearchByName(name);
                return Ok(Responses<IEnumerable<UserDTO>>.SuccessResult(users));
            }
            catch (DomainException e)
            {
                return BadRequest(Responses<dynamic>.DomainErrorMessage(e.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses<dynamic>.ApplicationErrorMessage());
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDto = _mapper.Map<UserDTO>(userViewModel);

                var userCreated = await _userService.Create(userDto);

                return Ok(Responses<UserDTO>.SuccessResult(userCreated, "User Successfully created"));

            }
            catch (DomainException e)
            {
                return BadRequest(Responses<dynamic>.DomainErrorMessage(e.Message, e.Errors));

            }
            catch (Exception)
            {
                return StatusCode(500, Responses<dynamic>.ApplicationErrorMessage());
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.Remove(id);
                return Ok(Responses<dynamic>.SuccessResult(null, "User Removed"));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses<dynamic>.ApplicationErrorMessage());
            }

        }

    }
}
