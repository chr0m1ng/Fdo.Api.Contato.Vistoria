using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Fdo.Api.Contato.Vistoria.Facades.Interfaces;
using Fdo.Api.Contato.Vistoria.Facades.Filters;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fdo.Api.Contato.Vistoria.Controllers
{
    /// <summary>
    /// Vehicle handling controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleFacade _vehicleFacade;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public VehicleController(IVehicleFacade vehicleFacade)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _vehicleFacade = vehicleFacade;
        }

        /// <summary>
        /// List avaiable vehicle images
        /// </summary>
        /// <param name="apiKey">Used in AuthFilter</param>
        /// <param name="plate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [AuthFilter]
        [HttpGet("{plate}")]
        public async Task<ActionResult<IEnumerable<string>>> ListVehicleImagesAsync(
            [FromHeader(Name = "x-api-key")] string apiKey,
            [FromRoute(Name = "plate")] string plate,
            CancellationToken cancellationToken)
        {
            var images = await _vehicleFacade.ListVehicleImagesAsync(plate, cancellationToken);
            if (images != null)
            {
                return Ok(images);
            }
            return NoContent();
        }

        /// <summary>
        /// Get vehicle image
        /// </summary>
        /// <param name="apiKey">Used in AuthFilter</param>
        /// <param name="plate"></param>
        /// <param name="image"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{plate}/{image}")]
        public async Task<IActionResult> GetVehicleImageAsync(
            [FromHeader(Name = "x-api-key")] string apiKey,
            [FromRoute(Name = "plate")] string plate,
            [FromRoute(Name = "image")] string image,
            CancellationToken cancellationToken)
        {
            var vehicleImage = await _vehicleFacade.GetVehicleImageAsync(plate, image, cancellationToken);
            if (vehicleImage != null)
            {
                return File(vehicleImage.Stream, vehicleImage.MimeType);
            }
            return NoContent();
        }

        /// <summary>
        /// Upload vehicle images
        /// </summary>
        /// <param name="apiKey">Used in AuthFilter</param>
        /// <param name="plate"></param>
        /// <param name="images"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [AuthFilter]
        [HttpPost("{plate}")]
        public async Task<IActionResult> UploadVehicleAsync(
            [FromHeader(Name = "x-api-key")] string apiKey,
            [FromRoute(Name = "plate")] string plate,
            [FromForm(Name = "files")] IEnumerable<IFormFile> images,
            CancellationToken cancellationToken)
        {
            await _vehicleFacade.SaveVehicleImagesAsync(plate, images, cancellationToken);
            return Created(plate, null);
        }
    }
}
