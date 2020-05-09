using AdminCategoryService.Entities;
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

        public async Task<bool> AddCategory(Category obj)
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

        public async Task<bool> AddSubcategory(SubCategory obj)
        {
               await _repo.AddSubcategory(obj);
                    return true;
           
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

        public List<Category> GetAllCategories()
        {
            try
            {
                List<Category> cat = _repo.GetAllCategories();
                return cat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Seller> GetAllSellers()
        {
            List<Seller> seller = _repo.GetAllSellers();
            return seller;
        }

        public List<SubCategory> GetAllSubcategories()
        {
            try
            {
                List<SubCategory> subcat = _repo.GetAllSubcategories().ToList();
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

        public List<Users> GetAllUsers()
        {
            List<Users> users = _repo.GetAllUsers();
            return users;
        }

        public Category getCategoryid(int cid)
        {
            try
            {
                Category cat = _repo.getCategoryid(cid);
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

        public SubCategory getsubcategorybyid(int subid)
        {
            try
            {
                SubCategory subcat = _repo.getsubcategorybyid(subid);
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

        public async Task<bool> updatecategory(Category obj)
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

        public async Task<bool> updatesubcategory(SubCategory obj)
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
