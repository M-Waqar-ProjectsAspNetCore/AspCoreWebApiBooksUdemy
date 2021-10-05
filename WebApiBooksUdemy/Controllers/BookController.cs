using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBooksUdemy.Data.Models;
using WebApiBooksUdemy.Data.Services;
using WebApiBooksUdemy.Data.ViewModels;

namespace WebApiBooksUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            List<Book> booklist = _bookService.GetAllBooks();
            return Ok(booklist);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            BookWithAuthorsVM book = _bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("add-book-with-author")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBookWithAuthor(book);
            return Ok();
        }

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookVM book)
        {
            var _book = _bookService.UpdateBookById(id,book);
            return Ok(_book);
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBookById(id);
            return Ok();
        }
    }
}
