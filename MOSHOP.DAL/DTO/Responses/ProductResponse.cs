using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MOSHOP.DAL.DTO.Responses
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public string MainImage { get; set; }

        public string MainImageUrl => $"https://localhost:7254/images/{MainImage}";
        
    }
}
