using System.IO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;

namespace Fdo.Api.Contato.Vistoria.Models
{
    public class Image
    {
        public string FileName { get; set; }

        public string MimeType { get; set; }

        public MemoryStream Stream { get; set; }

        public Image(Stream stream, int seek = default)
        {
            Stream = new MemoryStream();
            stream.CopyTo(Stream);
            Stream.Seek(seek, SeekOrigin.Begin);
        }

        public Image(FileStream fileStream) : this(fileStream, default)
        {
            FileName = Path.GetFileName(fileStream.Name);
            InitializeMimeType();
        }

        public Image(IFormFile formFile) : this(formFile.OpenReadStream())
        {
            FileName = formFile.FileName;
            InitializeMimeType();
        }

        private void InitializeMimeType()
        {
            if (new FileExtensionContentTypeProvider().TryGetContentType(FileName, out var mimeType))
            {
                MimeType = mimeType;
            }
        }
    }
}
