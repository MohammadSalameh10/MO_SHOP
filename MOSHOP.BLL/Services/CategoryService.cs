using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MOSHOP.DAL.DTO.Requests;
using MOSHOP.DAL.DTO.Responses;
using MOSHOP.DAL.Models;
using MOSHOP.DAL.Repositories;

namespace MOSHOP.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();

            return _categoryRepository.Add(category);

        }

        public int DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null)
            {
                return 0;
            }
            return _categoryRepository.Remove(category);
        }

        public IEnumerable<CategoryResponses> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return categories.Adapt<IEnumerable<CategoryResponses>>();
        }

        public CategoryResponses? GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return category is null ? null : category.Adapt<CategoryResponses>();
        }

        public int UpdateCategory(int id, CategoryRequest request)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null)
            {
                return 0;
            }
            category.Name = request.Name;
            return _categoryRepository.Update(category);

        }
        public bool ToggleStatus(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null)
            {
                return false;
            }
            category.status = category.status == Status.Active ? Status.Inactive : Status.Active;
            _categoryRepository.Update(category);
            return true;
        }
    }
}
