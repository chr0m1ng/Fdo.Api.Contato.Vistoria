
using Newtonsoft.Json;

namespace Fdo.Api.Contato.Vistoria.Models.Requests.Config
{
    public class ConfigPatchRequest
    {
        [JsonProperty("storage_path")]
        public string StoragePath { get; set; }
    }
}
