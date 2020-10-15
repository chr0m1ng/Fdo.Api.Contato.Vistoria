using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Fdo.Api.Contato.Vistoria.Models;
using Fdo.Api.Contato.Vistoria.Models.UI;
using Fdo.Api.Contato.Vistoria.Services.Extensions;
using Fdo.Api.Contato.Vistoria.Services.Interfaces;

namespace Fdo.Api.Contato.Vistoria.Services
{
    public class StorageService : IStorageService
    {
        private readonly ApiSettings _apiSettings;

        public StorageService(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public async Task CreateFolderAsync(string folder, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                var fullPath = GetStoragePath(folder);
                Directory.CreateDirectory(fullPath);
            }, cancellationToken);
        }

        public async Task<IEnumerable<string>> GetFolderFileNamesAsync(string folder, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var fullPath = GetStoragePath(folder);
                try
                {
                    var files = Directory.GetFileSystemEntries(fullPath);
                    return files.Select(Path.GetFileName);
                }
                catch (Exception)
                {
                    return null;
                }
            }, cancellationToken);
        }

        public async Task SaveImagesAsync(string folder, IEnumerable<Image> images, CancellationToken cancellationToken)
        {
            var saveImagesTasks = images.Select(i => SaveImageAsync(folder, i, cancellationToken));
            await Task.WhenAll(saveImagesTasks);
        }

        public async Task<FileStream> GetFileAsync(string folder, string file, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var fullPath = Path.Combine(GetStoragePath(folder), file);
                    return new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                }
                catch (Exception)
                {
                    return null;
                }
            }, cancellationToken);
        }

        private async Task SaveImageAsync(string folder, Image image, CancellationToken cancellationToken)
        {
            var fullPath = Path.Combine(GetStoragePath(folder), image.FileName);
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await image.Stream.CopyToAsync(fileStream, cancellationToken);
            }
        }

        private string GetStoragePath(string folder)
        {
            return Path.Combine(_apiSettings.StoragePath, DateTime.Now.GetFullDateNameBr(), folder);
        }

        public async Task<bool> TrySetStoragePathAsync(string path, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                if (Directory.Exists(path))
                {
                    _apiSettings.StoragePath = path;
                    return true;
                }
                return false;
            }, cancellationToken);
        }
    }
}
