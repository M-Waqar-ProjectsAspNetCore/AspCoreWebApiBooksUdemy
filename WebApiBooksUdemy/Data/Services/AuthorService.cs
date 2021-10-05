using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBooksUdemy.Data.Models;
using WebApiBooksUdemy.Data.ViewModels;

namespace WebApiBooksUdemy.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                Name = author.Name,
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorById(int id)
        {
            var _author = _context.Authors.Where(x => x.Id == id)
                .Select(x => new AuthorWithBooksVM()
                {
                    AuthorName = x.Name,
                    BookTitle = x.Book_Authors.Select(x => x.Book.Title).ToList()
                }).FirstOrDefault();

            return _author;
        }
    }
}
