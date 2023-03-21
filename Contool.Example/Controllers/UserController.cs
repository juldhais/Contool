using Contool.Example.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contool.Example.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly ISingletonUserService _singletonUserService;
    private readonly IScopedUserService _scopedUserService;
    private readonly ITransientUserService _transientUserService;
    private readonly NoInterfaceUserService _noInterfaceUserService;

    public UserController(
        ISingletonUserService singletonUserService,
        IScopedUserService scopedUserService,
        ITransientUserService transientUserService,
        NoInterfaceUserService noInterfaceUserService)
	{
        _singletonUserService = singletonUserService;
        _scopedUserService = scopedUserService;
        _transientUserService = transientUserService;
        _noInterfaceUserService = noInterfaceUserService;
    }

    [HttpGet("singleton")]
    public ActionResult GetAllSingleton()
    {
        var response = _singletonUserService.GetAll();
        return Ok(response);
    }

    [HttpGet("scoped")]
    public ActionResult GetAllScoped()
    {
        var response = _scopedUserService.GetAll();
        return Ok(response);
    }

    [HttpGet("transient")]
    public ActionResult GetAllTransient()
    {
        var response = _transientUserService.GetAll();
        return Ok(response);
    }

    [HttpGet("nointerface")]
    public ActionResult GetAllNoInterface()
    {
        var response = _noInterfaceUserService.GetAll();
        return Ok(response);
    }
}
