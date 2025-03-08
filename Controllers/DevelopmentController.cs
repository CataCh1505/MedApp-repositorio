using Microsoft.AspNetCore.Mvc;

namespace MedApp_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DevelopmentController : ControllerBase
{
    // Get: obtener datos
    // Post: crear datos
    // Patch/Put: actualizar datos
    // Delete: borrar datos

    [HttpGet("ApiVersion")]
    public IActionResult ApiVersion()
    {
        return Ok("V1.0.0");
    }

    [HttpGet("Test")]
    public IActionResult Test()
    {
        return Ok("V1.0.0");
    }


}
