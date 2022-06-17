using DemoEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPE.DataTier.Repositories
{
    public class PublisherRepository : IRepository<Publisher>
    {
        private readonly BookPublisherContext dbContext;

        public PublisherRepository(BookPublisherContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Publisher entity)
        {
            dbContext.Publishers.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var publisher = dbContext.Publishers.SingleOrDefault(x => x.PublisherId == id);
            if (publisher is not null)
            {
                dbContext.Publishers.Remove(publisher);
                dbContext.SaveChanges();
            }
        }

        public List<Publisher> Get()
        {

            return dbContext.Publishers.ToList();
        }

        public Publisher GetById(Guid id)
        {
            return dbContext.Publishers.SingleOrDefault(x => x.PublisherId == id);
        }

        public void Update(Publisher entity)
        {
            var publisher = dbContext.Publishers.SingleOrDefault(x => x.PublisherId == entity.PublisherId);
            if (publisher is not null)
            {
                dbContext.Publishers.Update(publisher);
                dbContext.SaveChanges();
            }
        }
    }
}
