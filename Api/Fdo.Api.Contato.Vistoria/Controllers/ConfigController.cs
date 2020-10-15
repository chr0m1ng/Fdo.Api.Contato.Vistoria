using System.Threading;
using System.Threading.Tasks;

using Fdo.Api.Contato.Vistoria.Facades.Interfaces;
using Fdo.Api.Contato.Vistoria.Models.Requests.Config;
using Fdo.Api.Contato.Vistoria.Models.UI;

using Microsoft.AspNetCore.Mvc;

namespace Fdo.Api.Contato.Vistoria.Controllers
{
    /// <summary>
    /// Config UI controller
    /// </summary>

    [Route("api/[controller]")]
    public class ConfigController : Controller
    {
        private readonly ApiSettings _apiSettings;
        private readonly IConfigFacade _configFacade;

        /// <summary>
        /// Config controller constructor
        /// </summary>
        /// <param name="apiSettings"></param>
        /// <param name="configFacade"></param>
        public ConfigController(ApiSettings apiSettings, IConfigFacade configFacade)
        {
            _apiSettings = apiSettings;
            _configFacade = configFacade;
        }

        /// <summary>
        /// Returns the config view
        /// </summary>
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return View(_apiSettings);
        }

        /// <summary>
        /// Set the storage path
        /// </summary>
        /// <param name="configRequest"></param>
        /// <param name="cancellationToken"></param>
        [HttpPatch]
        public async Task<IActionResult> UpdateStoragePathAsync([FromBody] ConfigPatchRequest configRequest, CancellationToken cancellationToken)
        {
            if (await _configFacade.TrySetStoragePathAsync(configRequest?.StoragePath, cancellationToken))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
