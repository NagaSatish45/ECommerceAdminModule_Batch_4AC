using AdminCategoryService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminCategoryService.Manager
{
    public interface IManager
    {
        List<Category> GetAllCategories();
        List<SubCategory> GetAllSubcategories();
        Task<bool> AddCategory(Category obj);
        Task<bool> AddSubcategory(SubCategory obj);
        Category getCategoryid(int cid);
        SubCategory getsubcategorybyid(int subid);
        string DeletCategory(int cid);
        string DeletSubCategory(int subid);
        Task<bool> updatecategory(Category obj);
        Task<bool> updatesubcategory(SubCategory obj);
        List<Seller> GetAllSellers();
        List<Users> GetAllUsers();

    }
}
