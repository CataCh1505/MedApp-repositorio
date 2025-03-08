
using MedApp_Api.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace MedApp_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RulesController : ControllerBase
{
    private readonly IRules rules;
    public RulesController(IRules _rules) => rules = _rules;

    [HttpGet("GetAllRules")]
    public async Task<IActionResult> GetAllRules() 
        => Ok(await rules.GetAllRules());
}
