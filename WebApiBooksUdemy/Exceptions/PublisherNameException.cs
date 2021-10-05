using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBooksUdemy.Exceptions
{
    public class PublisherNameException : Exception
    {
        public string PublisherName { get; set; }
        public PublisherNameException()
        {
        }
        public PublisherNameException(string message) : base(message)
        {
        }
        public PublisherNameException(string message, Exception ex) : base(message, ex)
        {
        }
        public PublisherNameException(string message, string publisherName) : this(message)
        {
            PublisherName = publisherName;
        }


    }
}
