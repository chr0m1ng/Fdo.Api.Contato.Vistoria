using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Fdo.Api.Contato.Vistoria.Models;

namespace Fdo.Api.Contato.Vistoria.Services.Interfaces
{
    public interface IStorageService
    {
        Task CreateFolderAsync(string folder, CancellationToken cancellationToken);
        Task SaveImagesAsync(string folder, IEnumerable<Image> images, CancellationToken cancellationToken);
        Task<IEnumerable<string>> GetFolderFileNamesAsync(string folder, CancellationToken cancellationToken);
        Task<FileStream> GetFileAsync(string folder, string file, CancellationToken cancellationToken);
        Task<bool> TrySetStoragePathAsync(string path, CancellationToken cancellationToken);
    }
}
