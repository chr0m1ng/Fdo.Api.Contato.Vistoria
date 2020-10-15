using System.Threading;
using System.Threading.Tasks;

using Fdo.Api.Contato.Vistoria.Facades.Interfaces;
using Fdo.Api.Contato.Vistoria.Services.Interfaces;

namespace Fdo.Api.Contato.Vistoria.Facades
{
    public class ConfigFacade : IConfigFacade
    {
        private readonly IStorageService _storageService;

        public ConfigFacade(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<bool> TrySetStoragePathAsync(string path, CancellationToken cancellationToken)
        {
            return await _storageService.TrySetStoragePathAsync(path, cancellationToken);
        }
    }
}
