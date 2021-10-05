using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApiBooksUdemy.Data.Models;
using WebApiBooksUdemy.Data.ViewModels;
using WebApiBooksUdemy.Exceptions;
using WebApiBooksUdemy.PagingHelper;

namespace WebApiBooksUdemy.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public List<Publisher> GetAllPublishers() => _context.Publishers.ToList();

        public PaginationVM<Publisher> GetPublishers(string sortby, string searchstring,int? pageNumber, int? PageSize)
        {
            var allPublishers = _context.Publishers.OrderBy(p => p.Name).ToList();
            // Filtering
            if (!string.IsNullOrEmpty(searchstring))
            {
                allPublishers = allPublishers.Where(p => p.Name
                    .Contains(searchstring, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            // Sorting
            if (!string.IsNullOrEmpty(sortby))
            {
                switch (sortby)
                {
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(p => p.Name).ToList();
                        break;
                    case "id_asc":
                        allPublishers = allPublishers.OrderBy(p => p.Id).ToList();
                        break;
                    case "id_desc":
                        allPublishers = allPublishers.OrderByDescending(p => p.Id).ToList();
                        break;
                    default:
                        break;
                }
            }
            // Paging
            pageNumber = pageNumber ?? 1;
            PageSize = PageSize ?? 2;
            PaginatedList<Publisher> PublishersList = PaginatedList<Publisher>.Create(allPublishers.AsQueryable(), (int)pageNumber, (int)PageSize);

            PaginationVM<Publisher> list = new PaginationVM<Publisher>()
            {
                PageIndex = PublishersList.PageIndex,
                TotalPages = PublishersList.TotalPages,
                HasPrevious = PublishersList.HasPreviousPage,
                HasNext = PublishersList.HasPreviousPage,
                Data = PublishersList
            };

            return list;
        }

        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));

        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartsWithNumber(publisher.Name))
            {
                throw new PublisherNameException("Name Can not start with Number", publisher.Name);
            }

            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherById(int id)
        {
            return _context.Publishers.FirstOrDefault(x => x.Id == id);
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.Name).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);

            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id: {id} does not exist");
            }
        }

    }
}
