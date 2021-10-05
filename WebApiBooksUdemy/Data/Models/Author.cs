using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBooksUdemy.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public List<Book_Author> Book_Authors { get; set; }
    }
}
