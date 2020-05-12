using AdminCategoryService.Entities;
using AdminCategoryService.Models;
using AdminCategoryService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCategoryService.Manager
{
    public class AdminManager:IManager
    {

        public readonly IAdminRepository _repo;

        public AdminManager(IAdminRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddCategory(CategoryModel obj)
        {
            try
            {
                await _repo.AddCategory(obj);
                  return true;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> AddSubcategory(SubCategoryModel obj)
        {
               var x= await _repo.AddSubcategory(obj);
            if (x)
                return true;
            else
                return false;
           
        }

        public string DeletCategory(int cid)
        {
            _repo.DeletCategory(cid);
            return "Category deleted";
        }

        public string DeletSubCategory(int subid)
        {
            _repo.DeletSubCategory(subid);
            return "subcategory deleted";
        }

        public List<CategoryModel> GetAllCategories()
        {
            try
            {
                List<CategoryModel> cat = _repo.GetAllCategories();
                return cat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SellerModel> GetAllSellers()
        {
            List<SellerModel> seller = _repo.GetAllSellers();
            return seller;
        }

        public List<SubCategoryModel> GetAllSubcategories()
        {
            try
            {
                List<SubCategoryModel> subcat = _repo.GetAllSubcategories().ToList();
                if (subcat.Count != 0)
                    return subcat;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = _repo.GetAllUsers();
            return users;
        }

        public CategoryModel getCategoryid(int cid)
        {
            try
            {
                CategoryModel cat = _repo.getCategoryid(cid);
                if (cat != null)
                {
                    return cat;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public SubCategoryModel getsubcategorybyid(int subid)
        {
            try
            {
                SubCategoryModel subcat = _repo.getsubcategorybyid(subid);
                if (subcat != null)
                {
                    return subcat;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> updatecategory(CategoryModel obj)
        {
            try
            {
                bool cat = await _repo.updatecategory(obj);
                if (cat)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> updatesubcategory(SubCategoryModel obj)
        {
            try
            {
                bool subcat = await _repo.updatesubcategory(obj);
                if (subcat)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
