using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace EcommerceShop.BackEnd.Storage
{
    public class FileStorageService : IStorageService
    {
        private readonly string _imgSourceFolder;
        private const string IMG_SOURCE_FOLDER_NAME = "img-Source";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _imgSourceFolder = Path.Combine(webHostEnvironment.WebRootPath, IMG_SOURCE_FOLDER_NAME);
        }

        public string GetFileUrl(string fileName)
        {
            return $"{Startup.clientUrls["Swagger"]}/{IMG_SOURCE_FOLDER_NAME}/{fileName}";
            //return $"https://localhost:44354/{IMG_SOURCE_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_imgSourceFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_imgSourceFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}
