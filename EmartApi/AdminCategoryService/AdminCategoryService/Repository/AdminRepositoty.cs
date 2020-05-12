using AdminCategoryService.Entities;
using AdminCategoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCategoryService.Repository
{
    public class AdminRepositoty:IAdminRepository
    {
        private readonly EmartDBContext _context;
        public AdminRepositoty(EmartDBContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCategory(CategoryModel obj)
        {
            try
            {
                Category cat = new Category();
                if(obj!=null)
                {
                    cat.Cid = obj.Cid;
                    cat.Cname = obj.Cname;
                    cat.Cdetails = obj.Cdetails;
                }
                _context.Add(cat);
               var res= await _context.SaveChangesAsync();
                if (res > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }


        public async Task<bool> AddSubcategory(SubCategoryModel obj)
        {
            try
            {
                SubCategory cat = new SubCategory();
                if (obj != null)
                {
                    cat.Cid = obj.Cid;
                    cat.Subid = obj.Subid;
                    cat.Subname = obj.Subname;
                    cat.Sdetails = obj.Sdetails;
                    cat.Gst = obj.Gst;
                }
                _context.Add(cat);
                await _context.SaveChangesAsync();
                 return true;
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletCategory(int Cid)
        {
            Category c = _context.Category.SingleOrDefault(e => e.Cid == Cid);
            _context.Remove(c);
            _context.SaveChanges();
        }


        public void DeletSubCategory(int Subid)
        {
            SubCategory c = _context.SubCategory.SingleOrDefault(e => e.Subid == Subid);
            _context.Remove(c);
            _context.SaveChanges();

        }
        public List<CategoryModel> GetAllCategories()
        {
            List<CategoryModel> c = new List<CategoryModel>();
            List<Category> cat = _context.Category.ToList();
            foreach (var k in cat)
            {
                c.Add(new CategoryModel() { Cid = k.Cid, Cname = k.Cname, Cdetails = k.Cdetails });
            }

            return c;

        }

        public List<SubCategoryModel> GetAllSubcategories()
        {

            List<SubCategoryModel> c = new List<SubCategoryModel>();
            List<SubCategory> cat = _context.SubCategory.ToList();
            foreach (var k in cat)
            {
                c.Add(new SubCategoryModel() { Subid=k.Subid, Cid=k.Cid, Subname=k.Sdetails, Gst=k.Gst });
            }

            return  c;



        }

        public CategoryModel getCategoryid(int Cid)
        {
           
                CategoryModel cat = new CategoryModel();
            Category x= _context.Category.SingleOrDefault(e => e.Cid == Cid);
                cat.Cid = x.Cid;
                cat.Cname = x.Cname;
                cat.Cdetails = x.Cdetails;
                return cat;
         
           
                

        }

        public SubCategoryModel getsubcategorybyid(int Subid)
        {
            SubCategoryModel cat = new SubCategoryModel();
            SubCategory c = _context.SubCategory.SingleOrDefault(e => e.Subid ==Subid);
            cat.Cid = c.Cid;
            cat.Subid = c.Subid;
            cat.Subname = c.Subname;
            cat.Sdetails = c.Sdetails;
            cat.Gst = c.Gst;
            return cat;


        }

        public async Task<bool> updatecategory(CategoryModel obj)
        {
            try
            {
                Category cat = new Category();
                cat.Cid = obj.Cid;
                cat.Cname = obj.Cname;
                cat.Cdetails = obj.Cdetails;
                _context.Category.Update(cat);
                await _context.SaveChangesAsync();
                return true;

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
                SubCategory cat = new SubCategory();
                cat.Cid = obj.Cid;
                cat.Subid = obj.Subid;
                cat.Subname = obj.Subname;
                cat.Sdetails = obj.Sdetails;
                cat.Gst = obj.Gst;
                _context.SubCategory.Update(cat);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<SellerModel> GetAllSellers()
        {
            List<SellerModel> c = new List<SellerModel>();
            List<Seller> cat = _context.Seller.ToList();
            foreach (var k in cat)
            {
                c.Add(new SellerModel() { SellerId=k.SellerId, SellerName=k.SellerName, KycAproval=k.KycAproval  });
            }

            return c;

        }
        public List<UserModel> GetAllUsers()
        {
            List<UserModel> c = new List<UserModel>();
            List<Users> cat = _context.Users.ToList();
            foreach (var k in cat)
            {
                c.Add(new UserModel() { Userid=k.Userid, Username=k.Username, Nooforders=k.Nooforders, Failedorders=k.Failedorders});
            }

            return c;

        }
    }
}
