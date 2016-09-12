using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MortgageCalculator.DAL.Data;
using MortgageCalculator.Model;
using System.Data.Entity;

namespace MortgageCalculator.DAL.Repositories
{
    public class MortgageRepository : RepositoryBase<Mortgage>
    {
        public MortgageRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override void Delete(Mortgage entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Mortgages.Attach(entity);
            }

            context.Mortgages.Remove(entity);
        }

        public override IQueryable<Mortgage> GetAll()
        {
            return context.Mortgages;
        }

        public override Mortgage GetById(object id) 
        {
            return context.Mortgages.Find(id);
        }

        public override void Insert(Mortgage entity)
        {
            context.Mortgages.Add(entity);
        }

        public override void Update(Mortgage entity)
        {
            context.Mortgages.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
