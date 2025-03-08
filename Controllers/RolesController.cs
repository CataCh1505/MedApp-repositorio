using MedApp_Api.DatabaseModels;
using MedApp_Api.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace MedApp_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoles roles;

        public RolesController(IRoles _roles) => roles = _roles;

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
            => Ok(await roles.GetRoles());


        [HttpGet("GetById/{roleId}")]
        public async Task<IActionResult> GetById(string roleId)
            => Ok(await roles.GetById(roleId));
        
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(Role role)
         => Ok(await roles.AddRole(role));

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(Role role)
         => Ok(await roles.UpdateRole(role));

         [HttpDelete("Delete/{roleId}")]
        public async Task<IActionResult> Delete(string roleId)
            => Ok(await roles.Delete(roleId));
    }
}