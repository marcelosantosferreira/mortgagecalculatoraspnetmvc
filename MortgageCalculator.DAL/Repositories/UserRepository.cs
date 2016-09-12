using MortgageCalculator.DAL.Data;
using MortgageCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MortgageCalculator.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override void Delete(User entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Users.Attach(entity);
            }

            context.Users.Remove(entity);
        }

        public override IQueryable<User> GetAll()
        {
            return context.Users;
        }

        public override User GetById(object id)
        {
            return context.Users.Find(id);
        }

        public override void Insert(User entity)
        {
            context.Users.Add(entity);
        }

        public override void Update(User entity)
        {
            context.Users.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
