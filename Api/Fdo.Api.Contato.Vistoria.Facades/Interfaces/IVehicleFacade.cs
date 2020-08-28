using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Fdo.Api.Contato.Vistoria.Models;

using Microsoft.AspNetCore.Http;

namespace Fdo.Api.Contato.Vistoria.Facades.Interfaces
{
    public interface IVehicleFacade
    {
        /// <summary>
        /// Storage vehicle image
        /// </summary>
        /// <param name="plate"></param>
        /// <param name="images"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SaveVehicleImagesAsync(string plate, IEnumerable<IFormFile> images, CancellationToken cancellationToken);

        /// <summary>
        /// Get specific storaged vehicle image
        /// </summary>
        /// <param name="plate"></param>
        /// <param name="image"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Image> GetVehicleImageAsync(string plate, string image, CancellationToken cancellationToken);

        /// <summary>
        /// List storaged vehicle images
        /// </summary>
        /// <param name="plate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> ListVehicleImagesAsync(string plate, CancellationToken cancellationToken);
    }
}
