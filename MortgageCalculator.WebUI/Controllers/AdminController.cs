using MortgageCalculator.Contracts.Repositories;
using MortgageCalculator.Model;
using MortgageCalculator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageCalculator.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IRepositoryBase<Mortgage> mortgages; // DI
        IRepositoryBase<User> users;
        LoginService loginService;

        public AdminController(IRepositoryBase<Mortgage> mortgages, IRepositoryBase<User> users)
        {
            this.mortgages = mortgages;
            this.users = users;
            loginService = new LoginService(this.users);
        }

        // GET: Admin
        public ActionResult Index()
        {
            var model = mortgages.GetAll();
            return View(model);
        }
    }
}