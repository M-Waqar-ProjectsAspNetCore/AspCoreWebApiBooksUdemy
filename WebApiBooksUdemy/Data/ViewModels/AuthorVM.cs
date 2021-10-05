using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBooksUdemy.Data.ViewModels
{
    public class AuthorVM
    {
        public string Name { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string AuthorName { get; set; }
        public List<string> BookTitle { get; set; }
    }
}
