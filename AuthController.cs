using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using ParcelManagementSystem.Data;
using ParcelManagementSystem.DTOs;
using ParcelManagementSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;



namespace ParcelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _config;

        public AuthController(ApplicationDBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO dto)
        {
            if (await _context.Users.AnyAsync(s => s.UserName == dto.UserName))
                return BadRequest("نام کاربری تکراری میباشد");

            var user = new User
            {
                UserName = dto.UserName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role,

            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("ثبت نام شما با موفقیت انجام شد");

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("نام کاربری یا رمز عبور اشتباه است");

            var claims = new[]
            {
              new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
        };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["jwt:issuer"],
                audience: _config["jwt:Audience"],
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.Now.AddMinutes(30)

                ) ;
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = jwt });


        }


      

    } 
}

