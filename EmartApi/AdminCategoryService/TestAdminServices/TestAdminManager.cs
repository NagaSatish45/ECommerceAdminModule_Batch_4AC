using AdminCategoryService.Entities;
using AdminCategoryService.Manager;
using AdminCategoryService.Models;
using AdminCategoryService.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestAdminServices
{
    class TestAdminManager
    {
        AdminManager _manager;
        [SetUp]
        public void setup()
        {
            _manager = new AdminManager(new AdminRepositoty(new EmartDBContext()));

        }
        [TearDown]
        public void Teardown()
        {
            _manager = null;
        }

        //Testing Add Category Success
        [Test]
        [Description("get category")]
        [TestCase(903, "electronics", "electric gadgets")]
        [TestCase(904  , "clothings", "Wholesale")]
        [TestCase(905, "HomeNeeds", "All home needies")]
        public async Task TestAddCategory_success(int cid, string cname, string cdetails)
        {
            try
            {
                CategoryModel cat = new CategoryModel();
                cat.Cid = cid;
                cat.Cname = cname;
                cat.Cdetails = cdetails;
                await _manager.AddCategory(cat);
                var x = _manager.getCategoryid(cat.Cid);
                Assert.NotNull(x);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }



        }

        [Test]
        [Description("Add Subcategory")]
        [TestCase(900, 2, "def", "pens", 4)]
        [TestCase(901, 1, "lkj", "cello", 5)]
        [TestCase(902, 1, "dsa", "butterflow", 3)]
        public async Task TestAddsubcategory(int Subid, int Cid, string Sdetails, string Subname, int Gst)
        {
            try
            {
                await _manager.AddSubcategory(new SubCategoryModel()
                {
                    Subid = Subid,
                    Cid = Cid,
                    Sdetails = Sdetails,
                    Subname = Subname,
                    Gst = Gst,


                });
                var result = _manager.getsubcategorybyid(Subid);
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        [Test]
        [Description("Testing Getby id for category")]
        [TestCase(900)]
        [TestCase(901)]
        public void TestGetbycategory_success(int cid)
        {
            try
            {
                CategoryModel result = _manager.getCategoryid(cid);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        //Failure Test Cases
        [Test]
        [TestCase(105)]
        [TestCase(999)]
        public void TestGetbycategory_Failure(int cid)
        {

            CategoryModel result = _manager.getCategoryid(cid);
            Assert.IsNull(result);
        }



        //Success TestCase
        [Test]
        [Description("Testing get by id for  Subcategory")]
        [TestCase(900)]
        [TestCase(901)]
        public void TestGetbysubcategory_success(int subid)
        {
            try
            {
                var result = _manager.getsubcategorybyid(subid);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        //Failure TestCase
        [Test]
        [Description("Testing get by id for  Subcategory")]
        [TestCase(1000)]
        [TestCase(1002)]
        public void TestGetbysubcategory_Failure(int subid)
        {
            try
            {
                var result = _manager.getsubcategorybyid(subid);
                Assert.IsNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        //Testing Delete Category
        [Test]
        [Description("Testing delete by id for  category")]
        [TestCase(902)]
        public void TestDelete_Success(int cid)
        {
            try
            {
                _manager.DeletCategory(cid);
                var result = _manager.getCategoryid(cid);
                Assert.IsNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        //Testing Delete subCategory
        [Test]
        [Description("Testing delete by id for  subcategory")]
      
        [TestCase(902)]
        public void TestDeleteSubcategory_Success(int subid)
        {
            try
            {
                _manager.DeletSubCategory(subid);
                var result = _manager.getsubcategorybyid(subid);
                Assert.IsNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [Test]
        [Description("Getcategorylist")]
        public void TestGetcategorylist()
        {
            try
            {
                var result = _manager.GetAllCategories();
                Assert.NotNull(result);
                Assert.Greater(result.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [Test]
        [Description("GetUserslist")]
        public void TestGetUserslist()
        {
            try
            {
                var result = _manager.GetAllUsers();
                Assert.NotNull(result);
                Assert.Greater(result.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        [Test]
        [Description("GetSellerlist")]
        public void TestGetsellerlist()
        {
            try
            {
                var result = _manager.GetAllSellers();
                Assert.NotNull(result);
                Assert.Greater(result.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [Test]

        [Description("Getgetsubcategorylist")]
        public void TestGetsubcategorylist_success()
        {
            try
            {
                var result = _manager.GetAllSubcategories();
                Assert.NotNull(result);
                Assert.Greater(result.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        // [TestCase)]  //setup teardown order
        [Test]
        [Description("to test the mock data")]
        public void AddMockCategory()
        {
            try
            {
                var cId = 55;
                var cName = "books";
                var CDetail = "all books";
                var cat = new CategoryModel { Cid = cId, Cname = cName, Cdetails = CDetail };
                var mock = new Mock<IManager>();
                mock.Setup(x => x.AddCategory(cat));
                var result = mock.Setup(x => x.getCategoryid(cat.Cid));
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }


        }
        //Testing Update category
        [Test]
        [Description("update Category")]
        public async Task UpdateCategory()
        {
            try
            {
                CategoryModel cat = _manager.getCategoryid(2);
                cat.Cdetails = "Buy best of best";
                await _manager.updatecategory(cat);
                CategoryModel cat1 = _manager.getCategoryid(2);
                Assert.AreSame(cat, cat1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        //Testing update subcategory
        [Test]
        [TestCase(1, 2, "def", "pen", 4)]
        [TestCase(3, 1, "dsa", "butter", 3)]
        [Description("update subCategory")]
        public async Task UpdateSubCategory(int Subid, int Cid, string Sdetails, string Subname, int Gst)
        {
            try
            {
                SubCategoryModel subcat = _manager.getsubcategorybyid(Subid);
                subcat.Subid = Subid;
                subcat.Subname = Subname;
                subcat.Sdetails = Sdetails;
                subcat.Gst = Gst;
                await _manager.updatesubcategory(subcat);
                SubCategoryModel subcat1 = _manager.getsubcategorybyid(Subid);
                Assert.AreSame(subcat, subcat1);


            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        [Test]
        [Description("testing buyer update category")]
        public async Task updatecategory_Successfull()
        {
            try
            {
                CategoryModel cat = new CategoryModel() { Cid = 2};
                var mock = new Mock<IAdminRepository>();
                mock.Setup(x => x.updatecategory(cat)).ReturnsAsync(true);
                AdminManager mg = new AdminManager(mock.Object);
                var result =await mg.updatecategory(cat);
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
