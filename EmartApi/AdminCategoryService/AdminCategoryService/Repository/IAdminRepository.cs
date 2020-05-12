using AdminCategoryService.Entities;
using AdminCategoryService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminCategoryService.Repository
{
    public interface IAdminRepository
    {

        List<CategoryModel> GetAllCategories();
        List<SubCategoryModel> GetAllSubcategories();
        Task<bool> AddCategory(CategoryModel obj);
        Task<bool> AddSubcategory(SubCategoryModel obj);
        CategoryModel getCategoryid(int Cid);
        SubCategoryModel getsubcategorybyid(int Subid);
        void DeletCategory(int Cid);
        void DeletSubCategory(int Subid);
        Task<bool> updatecategory(CategoryModel obj);
        Task<bool> updatesubcategory(SubCategoryModel obj);
        List<SellerModel> GetAllSellers();
        List<UserModel> GetAllUsers();
    }
}
