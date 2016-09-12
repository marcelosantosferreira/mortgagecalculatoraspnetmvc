using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using MortgageCalculator.WebUI;
using MortgageCalculator.WebUI.Controllers;
using MortgageCalculator.Model;
using MortgageCalculator.DAL.Repositories;
using MortgageCalculator.Contracts.Repositories;
using Moq;

namespace MortgageCalculator.Tests
{
    /* TODO: Put Mocks on Constructor() */
    [TestClass]
    public class ControllerTests
    {
        private Mock<IRepositoryBase<Mortgage>> mockRepositoryMortgage;
        private Mock<IRepositoryBase<User>> mockRespositoryUsers;

        /*
         * Check if the 1st Page receives an Empty Mortgage Object to construct the View
         */ 
        [TestMethod]
        public void Home_Index_ShouldPassAnEmptyMortgageToTheView()
        {
            mockRepositoryMortgage = new Mock<IRepositoryBase<Mortgage>>();

            HomeController controller = new HomeController(mockRepositoryMortgage.Object);

            ViewResult result = controller.Index() as ViewResult;
            Mortgage mortgage = (Mortgage)result.ViewData.Model;

            Assert.IsNotNull(result);
            Assert.IsNotNull(mortgage);
            Assert.IsNull(mortgage.email);
            Assert.AreEqual(false, mortgage.sent);
        }

        /*
         * Check if the 2nd Page loads a Valid Mortgage
         */
        [TestMethod]
        public void Home_CheckoutOutput_ShouldLoadAValidMortgage()
        {
            var mortgage = new Mortgage() { mortgageId = 9, amount = 100000, interest = 1, period = 10 };
            mockRepositoryMortgage = new Mock<IRepositoryBase<Mortgage>>();
            mockRepositoryMortgage.Setup(m => m.GetById(9)).Returns(mortgage);

            HomeController controller = new HomeController(mockRepositoryMortgage.Object);

            ViewResult result = controller.CheckOutput(9) as ViewResult;

            var viewModel = controller.ViewData.Model as Mortgage;

            Assert.IsNotNull(result);
            Assert.IsNotNull(viewModel);
            Assert.IsTrue(viewModel.mortgageId == mortgage.mortgageId);
            Assert.AreEqual(viewModel, mortgage);
            Assert.AreSame(viewModel, mortgage);
        }

        /*
         * Check if the Post works and Redirect to next Page (CheckOutput)
         */ 
        [TestMethod]
        public void Home_IndexPost_ShouldRedirectToCheckOutputRoute()
        {
            mockRepositoryMortgage = new Mock<IRepositoryBase<Mortgage>>();

            HomeController controller = new HomeController(mockRepositoryMortgage.Object);

            Mock<Mortgage> mockMortgage = new Mock<Mortgage>();

            FormCollection formCollection = new FormCollection();
            formCollection.Add("monthlypayment", "876");
            
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Index(mockMortgage.Object, formCollection) as RedirectToRouteResult;

            var viewModel = controller.ViewData.Model as Mortgage;

            Assert.IsNotNull(result);
            Assert.AreEqual("CheckOutput",result.RouteValues["Action"]);
            Assert.AreEqual("Home", result.RouteValues["Controller"]);
            Assert.AreEqual(876, mockMortgage.Object.monthlypayment); /* On the Controller this value must be updated */
        }

        /*
         * Tests if the Admin Page load all the simulated Mortgages 
         */
        [TestMethod]
        public void Admin_Index_ShouldDisplayAllMortgages()
        {
            var mortgages = new List<Mortgage> { new Mortgage { mortgageId = 1 }, new Mortgage { mortgageId = 2 } };

            mockRepositoryMortgage = new Mock<IRepositoryBase<Mortgage>>();
            mockRepositoryMortgage.Setup(m => m.GetAll()).Returns(mortgages.AsQueryable());

            mockRespositoryUsers = new Mock<IRepositoryBase<User>>();
            AdminController controller = new AdminController(mockRepositoryMortgage.Object, mockRespositoryUsers.Object);

            ViewResult result = controller.Index() as ViewResult;

            var viewModel = controller.ViewData.Model as IEnumerable<Mortgage>;

            Assert.IsNotNull(result);
            Assert.IsTrue(viewModel.Count() == mockRepositoryMortgage.Object.GetAll().Count());
        }

    }
}
