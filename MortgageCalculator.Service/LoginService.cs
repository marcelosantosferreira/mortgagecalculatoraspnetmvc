using MortgageCalculator.Contracts.Repositories;
using MortgageCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MortgageCalculator.Service
{
    public class LoginService
    {
        IRepositoryBase<User> user;

        //public const string MortageSessionName = "eCommerceBasket";

        public LoginService(IRepositoryBase<User> user)
        {
            this.user = user;
        }

        public bool DoLogin(HttpContextBase httpContext, string userlogin, string password)
        {
            bool success = true;
            //getById() ou método na mão pra filtrar (podia ser um filtro por login e senha só)
            return success;
        }
    }
}
