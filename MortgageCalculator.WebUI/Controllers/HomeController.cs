using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MortgageCalculator.DAL.Data;
using MortgageCalculator.DAL.Repositories;
using MortgageCalculator.Contracts.Repositories;
using MortgageCalculator.Model;
using MortgageCalculator.Service;

namespace MortgageCalculator.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Mortgage> mortgages;

        public HomeController(IRepositoryBase<Mortgage> mortgages)
        {
            this.mortgages = mortgages;
        }

        public ActionResult Index()
        {
            Mortgage model = new Mortgage();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Mortgage mortgage, FormCollection formCollection)
        {
            mortgage.insertedIn = DateTime.Now;
            mortgage.monthlypayment = Decimal.Parse(formCollection["monthlypayment"]);
            mortgages.Insert(mortgage);
            mortgages.Commit();

            return RedirectToAction("CheckOutput", "Home", new { id = mortgage.mortgageId });
        }

        public ActionResult CheckOutput(int id)
        {
            Mortgage mortgage = mortgages.GetById(id);
            return View(mortgage);
        }

        [HttpPost]
        public ActionResult SendEmail(FormCollection formCollection)
        {
            string email = formCollection["email"];
            int mortgageId = 0;

            if (Int32.TryParse(formCollection["mortgageId"], out mortgageId))
            {
                Mortgage mortgage = mortgages.GetById(mortgageId);
                mortgage.email = email;
                /*
                 * Call Email Service
                 * if Successfully sent: 
                 *  set mortgage.sent = true  
                 *  update mortgage Object on Database
                 */

                mortgage.sent = true;
                mortgages.Update(mortgage);
                mortgages.Commit();
            }
            TempData["message"] = "OK";
            //return RedirectToAction("SentEmail","Home");
            return RedirectToAction("CheckOutput", "Home", new { id = mortgageId });
        }

        public ActionResult SentEmail()
        {
            return View();
        }
    }
}