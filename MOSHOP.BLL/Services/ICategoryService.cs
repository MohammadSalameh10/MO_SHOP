using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.DAL.DTO.Requests;
using MOSHOP.DAL.DTO.Responses;

namespace MOSHOP.BLL.Services
{
    public interface ICategoryService
    {
        int CreateCategory(CategoryRequest request);
        IEnumerable<CategoryResponses> GetAllCategories();
        CategoryResponses? GetCategoryById(int id);
        int UpdateCategory(int id, CategoryRequest request);
        int DeleteCategory(int id);
        bool ToggleStatus(int id);
    }
}
