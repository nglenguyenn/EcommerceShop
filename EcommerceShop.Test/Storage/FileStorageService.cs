using EcommerceShop.BackEnd.Storage;
using Moq;

namespace EcommerceShop.Test.Storage
{
    public class FileStorageService
    {
        public static IStorageService IStorageService()
        {
            var fileStorageService = Mock.Of<IStorageService>();

            return fileStorageService;
        }
    }
}
