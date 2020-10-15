using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fdo.Api.Contato.Vistoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Ping endpoint
        /// </summary>
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Alive!");
        }
    }
}
