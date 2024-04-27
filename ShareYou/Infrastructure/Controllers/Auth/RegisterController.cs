using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareYou.Domain.Entities;
using ShareYou.Infrastructure.DTO.Requests;
using ShareYou.Infrastructure.DTO.Responses;

namespace ShareYou.Infrastructure.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
	private readonly UserManager<User> _userManager;
	public RegisterController(UserManager<User> userManager)
	{
		_userManager = userManager;
	}

	[HttpPost]
	public async Task<ActionResult> Register([FromBody] RegisterModel model)
	{
		User newUser = new (){ UserName = model.Name, Email = model.Email};

		var result = await _userManager.CreateAsync(newUser, model.Password!);

		if (!result.Succeeded)
		{
			var errors = result.Errors.Select(x => x.Description);

			return Ok(new RegisterResult { Succesful = false, Errors = errors });
		}
		else return Ok(new RegisterResult { Succesful = true });
	}
}

