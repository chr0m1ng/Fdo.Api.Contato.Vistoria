using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Fdo.Api.Contato.Vistoria.Facades.Interfaces;
using Fdo.Api.Contato.Vistoria.Models;
using Fdo.Api.Contato.Vistoria.Services.Interfaces;

using Microsoft.AspNetCore.Http;

namespace Fdo.Api.Contato.Vistoria.Facades
{
    public class VehicleFacade : IVehicleFacade
    {
        private readonly IStorageService _storageService;

        public VehicleFacade(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task SaveVehicleImagesAsync(string plate, IEnumerable<IFormFile> images, CancellationToken cancellationToken)
        {
            await _storageService.CreateFolderAsync(plate, cancellationToken);
            await _storageService.SaveImagesAsync(plate, images.Select(i => new Image(i)), cancellationToken);
        }

        public async Task<Image> GetVehicleImageAsync(string plate, string image, CancellationToken cancellationToken)
        {
            var imageStream = await _storageService.GetFileAsync(plate, image, cancellationToken);
            return imageStream is null ? null : new Image(imageStream);
        }

        public async Task<IEnumerable<string>> ListVehicleImagesAsync(string plate, CancellationToken cancellationToken)
        {
            return await _storageService.GetFolderFileNamesAsync(plate, cancellationToken);
        }
    }
}
