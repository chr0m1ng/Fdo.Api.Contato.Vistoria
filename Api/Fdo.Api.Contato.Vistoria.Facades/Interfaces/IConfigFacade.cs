using System.Threading;
using System.Threading.Tasks;

namespace Fdo.Api.Contato.Vistoria.Facades.Interfaces
{
    public interface IConfigFacade
    {
        Task<bool> TrySetStoragePathAsync(string path, CancellationToken cancellationToken);
    }
}
