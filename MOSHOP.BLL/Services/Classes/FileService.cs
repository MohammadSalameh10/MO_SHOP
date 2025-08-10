using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MOSHOP.BLL.Services.Interfaces;

namespace MOSHOP.BLL.Services.Classes
{
    public class FileService : IFIleService
    {
        public async Task<string> UploadAsync(IFormFile file)
        {
           if(file != null && file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return fileName;
            }

            throw new Exception("error");
            
        }
    }
}
