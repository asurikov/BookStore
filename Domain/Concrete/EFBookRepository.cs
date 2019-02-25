using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFBookRepository : IBookRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Book> Books
        {
            get { return context.Books; }
        }


        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
            {
                book.Publisher = 5;
                context.Books.Add(book);
            }
            else
            {
                
                Book dbEntry = context.Books.Find(book.BookId);
                if (dbEntry != null)
                {
                    dbEntry.Name = book.Name;
                    dbEntry.Author = book.Author;
                    dbEntry.Description = book.Description;
                    dbEntry.Genre = book.Genre;
                    dbEntry.Price = book.Price;
                    dbEntry.ISBN = book.ISBN;
                    dbEntry.Pages = book.Pages;
                    dbEntry.Year = book.Year;
                    dbEntry.Publisher = book.Publisher;


                }
            }
            context.SaveChanges();
        }
        public void Del (Book model)
        {

            context.Books.Remove(model);
            //   model.BookId = 66;
            //context.Books.Add(model);

            context.SaveChanges();

        }
        }
    }

