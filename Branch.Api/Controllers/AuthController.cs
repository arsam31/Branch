using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Branch.Api.DTOs;
using Branch.Data.Core.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Branch.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

		private IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IUserRepository userRepository, IConfiguration configuration)
		{
			_userRepository = userRepository;
            _configuration = configuration;
            //var test = _userRepository.GetAll();
        }

		[HttpPost("gettoken")]
		public IActionResult GetToken([FromBody]TokenRequest Input)
		{
			
			
				var oUser=_userRepository.AuthenticateUser(Input.Email,Input.Password);
				if (oUser!=null)
				{

					var claimsdata = new[] {
                        new Claim(ClaimTypes.Name, oUser.UserName),
					    new Claim(ClaimTypes.Role, oUser.Role)
                        
                    };
					var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
                    int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);
                    var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                    var token = new JwtSecurityToken(
                                                        issuer: _configuration["Jwt:Issuer"],
                                                        audience: _configuration["Jwt:Audience"],
                                                        expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                                                        claims: claimsdata,
                                                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                                                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                var tokenobj = new
                {
                    generatedToken = tokenString
                };
                return Ok(tokenobj);
            }

            return BadRequest("wrong request");
		}
	}

	
}