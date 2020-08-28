namespace Fdo.Api.Contato.Vistoria.Models.UI
{
    /// <summary>
    /// Class to use data from appsettings.json "Settings" field
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Current API Version
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Base storage path on disk
        /// </summary>
        public string StoragePath { get; set; }

        /// <summary>
        /// Server api key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Server request api key header
        /// </summary>
        public string AuthHeader { get; set; }
    }
}
