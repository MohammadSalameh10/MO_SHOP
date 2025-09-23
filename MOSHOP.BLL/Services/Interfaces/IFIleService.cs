using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MOSHOP.BLL.Services.Interfaces
{
    public interface IFIleService
    {
        Task<string> UploadAsync(IFormFile filePath);

        Task<List<string>> UploadManyAsync(List<IFormFile> files);
    }
}
