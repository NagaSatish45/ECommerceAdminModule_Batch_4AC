using AdminCategoryService.Entities;
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
    [TestFixture]
    class TestAdminRepository
    {
        AdminRepositoty _repo;
        [SetUp]
        public void setup()
        {
            _repo = new AdminRepositoty(new EmartDBContext());

        }
        [TearDown]
        public void Teardown()
        {
            _repo = null;
        }


        //Testing Add Category Success
        [Test]
        [Description("Add category")]
        [TestCase(352, "HomeNeeds", "All home needies")]
        [TestCase(353, "HomeNeeds", "All home needies")]
        public async Task TestAddCategory_success(int cid, string cname, string cdetails)
        {
            try
            {
                CategoryModel cat = new CategoryModel();
                cat.Cid = cid;
                cat.Cname = cname;
                cat.Cdetails = cdetails;

                await _repo.AddCategory(cat);
                var x = _repo.getCategoryid(cid);
                Assert.NotNull(x);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }


        }






        [Test]
        [Description("Add Subcategory")]
        [TestCase(703, 2, "def", "pens", 4)]
        [TestCase(704, 1, "lkj", "cello", 5)]
        [TestCase(705, 1, "dsa", "butterflow", 3)]
        public async Task TestAddsubcategory(int Subid, int Cid, string Sdetails, string Subname, int Gst)
        {
            try
            {
                SubCategoryModel sub = new SubCategoryModel();

                sub.Subid = Subid;
                sub.Cid = Cid;
                sub.Sdetails = Sdetails;
                sub.Subname = Subname;
                sub.Gst = Gst;
                await _repo.AddSubcategory(sub);

                var result = _repo.getsubcategorybyid(Subid);
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        [Test]
        [Description("Testing Getby id for category")]
        [TestCase(2)]
        [TestCase(1)]
        public void TestGetbycategory_success(int cid)
        {
            try
            {
                CategoryModel result = _repo.getCategoryid(cid);
                Assert.IsNotNull(result, "test passed");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        //Failure Test Cases
        [Test]
        [TestCase(1)]
        public void TestGetbycategory_Failure(int Cid)
        {

            var result = _repo.getCategoryid(Cid);
            Assert.AreNotEqual(result,null);
        }



        //Success TestCase
        [Test]
        [Description("Testing get by id for  Subcategory")]
        [TestCase(1)]
        [TestCase(3)]
        public void TestGetbysubcategory_success(int subid)
        {
            try
            {
                var result = _repo.getsubcategorybyid(subid);
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
        [TestCase(3)]
        
        public void TestGetbysubcategory_Failure(int subid)
        {
            try
            {
                var result = _repo.getsubcategorybyid(subid);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        //Testing Delete Category
        [Test]
        [Description("Testing delete by id for  category")]
        [TestCase(33)]
        [TestCase(34)]
        public void TestDelete_Success(int Cid)
        {
            try
            {
                _repo.DeletCategory(Cid);
                var result = _repo.getCategoryid(Cid);
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
        [TestCase(703)]
        [TestCase(704)]
        public void TestDeleteSubcategory_Success(int subid)
        {
            try
            {
                _repo.DeletSubCategory(subid);
                var result = _repo.getsubcategorybyid(subid);
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
                var result = _repo.GetAllCategories();
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
        public void TestGetUsersList()
        {
            try
            {
                var result = _repo.GetAllUsers();
                Assert.NotNull(result);
                Assert.Greater(result.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        [Test]
        [Description("GetSellerslist")]
        public void TestGetSellersList()
        {
            try
            {
                var result = _repo.GetAllSellers();
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
                var result = _repo.GetAllSubcategories();
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
                var cId = 556;
                var cName = "books";
                var CDetail = "all books";
                var cat = new CategoryModel{ Cid = cId, Cname = cName, Cdetails = CDetail };
                var mock = new Mock<IAdminRepository>();
                mock.Setup(x => x.AddCategory(cat));
                var result = mock.Setup(x => x.getCategoryid(cat.Cid));
                Assert.IsNotNull(result);
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
                CategoryModel cat = _repo.getCategoryid(2);
                cat.Cdetails = "Buy  best";
                await _repo.updatecategory(cat);
                CategoryModel cat1 = _repo.getCategoryid(2);
                Assert.AreSame(cat, cat1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        //Testing update subcategory
        [Test]
       // [TestCase(10, 2, "def", "pen", 4)]
        [TestCase(11, 1, "lkj", "cellopens", 5)]
        [TestCase(12, 1, "dsa", "butter", 3)]
        [Description("update subCategory")]
        public async Task UpdateSubCategory(int Subid, int Cid, string Sdetails, string Subname, int Gst)
        {
            try
            {
                SubCategoryModel subcat = _repo.getsubcategorybyid(Subid);
                subcat.Subid = Subid;
                subcat.Subname = Subname;
                subcat.Sdetails = Sdetails;
                subcat.Gst = Gst;
                await _repo.updatesubcategory(subcat);
                SubCategoryModel subcat1 = _repo.getsubcategorybyid(Subid);
                Assert.AreSame(subcat, subcat1);


            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        //Mock Testing of Updatesubcategory
        [Test]
        public async Task UpdateSubCategory_mockTest()
        {
            try
            {
                SubCategoryModel sub = new SubCategoryModel() {   Subid=1,Subname = "pen", Cid = 1, Gst = 4, Sdetails = "def" };
                var mock = new Mock<IAdminRepository>();
                mock.Setup(x => x.updatesubcategory(sub)).ReturnsAsync(true);
                var result = await _repo.updatesubcategory(sub);
                Assert.AreEqual(true,result);

            }
            catch(Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        //Mock Testing of Updatesubcategory
        [Test]
        public async Task UpdateCategory_mockTest()
        {
            try
            {
                CategoryModel cat = new CategoryModel() {   Cid= 1, Cname= "fashion",  Cdetails = "menfashion" };
                var mock = new Mock<IAdminRepository>();
                mock.Setup(x => x.updatecategory(cat)).ReturnsAsync(true);
                var result = await _repo.updatecategory(cat);
                Assert.AreEqual(true, result);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


    }
}
