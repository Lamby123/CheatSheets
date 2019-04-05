namespace CheatSheets.Extensions
{
    using Microsoft.Extensions.FileProviders;
    using System.IO;

    public static class FileExtensions
    {
        public static string GetFileContents(IFileInfo file)
        {
            using (var contentStream = file.CreateReadStream())
            {
                using (var streamReader = new StreamReader(contentStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
