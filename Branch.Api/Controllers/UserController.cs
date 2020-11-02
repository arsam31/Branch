using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Branch.Api.DTOs;
using Branch.Data.Core.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Branch.Data.Core.Domain;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Runtime.Serialization;
using System.Net.Http;
using Branch.Data;

namespace Branch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public UserController(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles="admin")]
        public IActionResult GetAll()
        {
            IEnumerable<User> userObj = _userRepository.GetAll().Where(c=>c.IsActive == true);
            var allUser = new List<UserRegister>();
            _mapper.Map<List<User>, List<UserRegister>>(userObj.ToList(), allUser);
            return Ok(allUser);
        }

        [HttpGet("GetUser/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetUser(long id)
        {
            User user = _userRepository.GetById(id);
            if (user.IsActive == true)
            {
                return Ok(user);
            }
            return NotFound("User does not exist");
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserRegister Input)
        {
            if (_userRepository.IsEmailExist(Input.Email))
            {
                return BadRequest("user with this email already exist.try again with different email");
            }
            else
            {
                var UserObj = _mapper.Map<User>(Input);
                _userRepository.Add(UserObj);
                _userRepository.SaveChanges();
                var UserObj1 = _mapper.Map<User,UserRegister>(UserObj);
                return Ok(UserObj1);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="admin,teacher,user")]
        public IActionResult UpdateUser(int id, [FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User obj = _userRepository.GetById(id);
            if (obj == null)
            {
                return NotFound("User not found");
            }

            obj.FirstName = user.FirstName;
            obj.LastName = user.LastName;
            obj.Mobile = user.Mobile;
            obj.Remarks = user.Remarks;
            obj.Password = user.Password;

            var userObj = _mapper.Map<User>(user);
            _userRepository.Update(obj, userObj);
            return Ok("Success");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,teacher,user")]
        public IActionResult DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            user.IsActive = false;
            _userRepository.SaveChanges();
            return Ok("Success");
        }
    }
}