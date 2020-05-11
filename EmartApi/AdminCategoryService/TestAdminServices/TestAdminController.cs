using AdminCategoryService.Controllers;
using AdminCategoryService.Entities;
using AdminCategoryService.Manager;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestAdminServices
{
    [TestFixture]
    class TestAdminController
    {
        private AdminServiceController controller;
         Mock<IManager> manager;
        [SetUp]
        public void SetUp()
        {
            var logger = new Mock<ILogger<AdminServiceController>>();
           manager = new Mock<IManager>();
            controller = new AdminServiceController(manager.Object, logger.Object);


        }
        [Test]
        [TestCase(589, "HomeNeeds", "All home needies")]
        public async Task TestAddcategory(int cid, string cname, string cdetails)
        {
            try
            {
                Category cat = new Category() { Cid = cid, Cname = cname, Cdetails = cdetails };
                var mock = new Mock<IManager>();
                mock.Setup(x => x.AddCategory(cat)).ReturnsAsync(true);
                var res = await controller.Addcategory(cat);
                Assert.AreNotEqual(mock,res);
               



            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        [Test]
        [TestCase(612, "HomeNeeds",1, "All",4)]
        public async Task TestAddSubcategory(int subid, string subname,int cid, string sdetails,int gst)
        {
            try
            {
                SubCategory subcat = new SubCategory() {Subid=subid,Subname=subname,Cid = cid,Sdetails=sdetails,Gst=gst};
                var res = await controller.Addsubcategory(subcat);
                Assert.AreEqual(null,res);

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
                var result = controller.getcategory(cid);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        [Test]
        [Description("Testing Getby id for subcategory")]
        [TestCase(2)]
        [TestCase(1)]
        public void TestGetbysubcategory_success(int subcid)
        {
            try
            {
                var result = controller.getcategory(subcid);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
    }

}