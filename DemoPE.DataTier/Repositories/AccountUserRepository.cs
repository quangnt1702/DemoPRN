using DemoEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPE.DataTier.Repositories
{
    public class AccountUserRepository : IRepository<AccountUser>
    {
        private readonly BookPublisherContext dbContext;

        public AccountUserRepository(BookPublisherContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(AccountUser entity)
        {
            dbContext.AccountUsers.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var accountUser = dbContext.AccountUsers.SingleOrDefault(x => x.UserId == id);
            if (accountUser is not null)
            {
                dbContext.AccountUsers.Remove(accountUser);
                dbContext.SaveChanges();
            }
        }

        public List<AccountUser> Get()
        {
            return dbContext.AccountUsers.ToList();
        }

        public AccountUser GetById(Guid id)
        {
            return dbContext.AccountUsers.SingleOrDefault(x => x.UserId == id);
        }

        public void Update(AccountUser entity)
        {
            var accountUser = dbContext.AccountUsers.SingleOrDefault(x => x.UserId == entity.UserId);
            if (accountUser is not null)
            {
                dbContext.AccountUsers.Update(accountUser);
                dbContext.SaveChanges();
            }
        }
    }
}
