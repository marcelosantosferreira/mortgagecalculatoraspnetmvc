//using MortgageCalculator.Contracts.Repositories;
using MortgageCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageCalculator.WebUI.Controllers;
using System.Web.Mvc;
using MortgageCalculator.DAL.Data;
using MortgageCalculator.DAL.Repositories;

namespace MortgageCalculator.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        
        /*
         * Test if the Repository Object inserts a Mortgage correctly in the Database
         */
        [TestMethod]
        public void Home_IndexPost_ShouldInsertAMortgageCorrectly()
        {
            MortgageRepository mortgages = new MortgageRepository(new DataContext());

            Mortgage mortgage = new Mortgage()
            {
                amount = 700000,
                interest = 7,
                period = 10,
                monthlypayment = 0,
                sent = false,
                email = "trackthisrecord@test.com"
            };
                        
            HomeController controller = new HomeController(mortgages);

            FormCollection formCollection = new FormCollection();
            formCollection.Add("monthlypayment", "777");

            var mortgagesCountBefore = mortgages.GetAll().Count();

            RedirectToRouteResult result = (RedirectToRouteResult)controller.Index(mortgage, formCollection) as RedirectToRouteResult;

            var mortgagesCountAfter = mortgages.GetAll().Count();

            var viewModel = controller.ViewData.Model as Mortgage;

            Assert.IsNotNull(result);
            Assert.AreEqual(777, mortgage.monthlypayment);
            Assert.AreEqual(777, mortgages.GetById(mortgage.mortgageId).monthlypayment);
            Assert.AreNotEqual(mortgagesCountBefore, mortgagesCountAfter);
            Assert.AreEqual(mortgagesCountBefore + 1, mortgagesCountAfter);
        }

    }
}
