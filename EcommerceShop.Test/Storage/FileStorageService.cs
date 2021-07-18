using EcommerceShop.BackEnd.Storage;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
