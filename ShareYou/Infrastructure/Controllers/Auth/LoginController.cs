using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShareYou.Application.SecretsManagement;
using ShareYou.Domain.Entities;
using ShareYou.Infrastructure.DTO.Requests;
using ShareYou.Infrastructure.DTO.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShareYou.Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ISecretsManager _secretsManager;
    private readonly IConfiguration _config;
    private readonly SignInManager<User> _signInManager;
    public LoginController(
        ISecretsManager secrets, 
        SignInManager<User> signInManager,
        IConfiguration configuration)
    {
        _secretsManager = secrets;
        _signInManager = signInManager;
        _config = configuration;
    }

    [HttpPost]
    public async Task<ActionResult> Login([FromBody] LoginModel request)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Name, request.Password, false, false);

        if (!result.Succeeded) return BadRequest(new LoginResult { Succesful = false, Error = "Адрес почты или пароль неверны" });

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, request.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretsManager.GetJWTSecurityKey()!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddDays(Convert.ToInt32(_config["JWTExpiryInDays"]!));

        var token = new JwtSecurityToken(
            _config["JWTIssuer"],
            _config["JWTAudience"],
            claims,
            expires: expiry,
            signingCredentials: creds);
        return Ok(new LoginResult { Succesful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }   
}

