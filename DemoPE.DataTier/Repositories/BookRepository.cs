using DemoEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPE.DataTier.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly BookPublisherContext dbContext;

        public BookRepository(BookPublisherContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Book entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var book = dbContext.Books.SingleOrDefault(x => x.BookId == id);
            if (book is not null)
            {
                dbContext.Books.Remove(book);
                dbContext.SaveChanges();
            }
        }

        public List<Book> Get()
        {
            return dbContext.Books.ToList();
        }

        public Book GetById(Guid id)
        {
            return dbContext.Books.SingleOrDefault(x => x.BookId == id);
        }

        public void Update(Book entity)
        {
            var book = dbContext.Books.SingleOrDefault(x => x.BookId == entity.BookId);
            if (book is not null)
            {
                dbContext.Books.Update(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
