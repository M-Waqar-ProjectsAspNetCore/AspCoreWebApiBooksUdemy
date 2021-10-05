using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBooksUdemy.Data.Services;
using WebApiBooksUdemy.Data.ViewModels;

namespace WebApiBooksUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody]AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var _author = _authorService.GetAuthorById(id);
            return Ok(_author);
        }
    }
}
