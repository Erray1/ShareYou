using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareYou.Application.SessionConnectionServices;
using ShareYou.Domain.Entities;
using System.Security.Claims;

namespace ShareYou.Infrastructure.Controllers;

// Здесь будет происходить валидацияя подключения
// и перенаправление на страницу с доской

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class JoinController : ControllerBase
{
    private readonly ISessionConnectionWorker _connectionWorker;
    private readonly IServiceProvider _serviceProvider;
    private readonly UserManager<User> _userManager;
    public JoinController(
        ISessionConnectionWorker connectionWorker, 
        IServiceProvider serviceProvider,
        UserManager<User> userManager)
    {
        _connectionWorker = connectionWorker; 
        _serviceProvider = serviceProvider;
        _userManager = userManager;
    }

    [HttpPatch("{whiteboardID}")]
    public async Task<IActionResult> JoinWhiteboard(string whiteboardID)
    {
        var userId = (await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)!.Value))!.Id.ToString(); // ????
        var connectionState = await _connectionWorker.GetSessionConnectionStateAsync(whiteboardID, userId);
        if (!connectionState.CanJoin)
        {
            return Forbid(connectionState.ErrorMessage!);        
        }
        var baseAddress = HttpContext.Request.PathBase;
        var connectionString = ConnectionsUtilities.GenerateSessionConnectionString(baseAddress, whiteboardID, connectionState);
        return Redirect(connectionString);
    }
}

