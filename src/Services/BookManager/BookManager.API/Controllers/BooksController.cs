﻿using BookManager.API.Entities;
using BookManager.API.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BookManagementAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly ILogger _logger;
        public BooksController(IBooksService booksService, ILogger logger)
        {
            _booksService = booksService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {

            var books = await _booksService.GetBooks();
            _logger.Information("Books returned");
            return Ok(books);
        }

        [HttpGet("{id:length(24)}", Name = "GetBookById")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookById(string id)
        {
            var books = await _booksService.GetBookById(id);
            return Ok(books);
        }

        [Route("[action]/{author}", Name = "GetBooksByAuthor")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(string author)
        {
            var books = await _booksService.GetBooksByAuthor(author);
            return Ok(books);
        }

        [Route("[action]/{genre}", Name = "GetBooksByGenre")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByGenre(string genre)
        {
            var books = await _booksService.GetBooksByGenre(genre);
            return Ok(books);
        }

        [Route("[action]/{name}", Name = "GetBooksByName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByName(string name)
        {
            var books = await _booksService.GetBooksByName(name);
            return Ok(books);
        }
        [Route("[action]", Name = "AddBook")]
        [HttpPost]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> AddBook(Book book)
        {
            await _booksService.CreateBook(book);
            _logger.Information($"Book named: {book.Name} added to inventory");
            return Ok();
        }

        [Route("[action]", Name = "UpdateBook")]
        [HttpPut]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UpdateBook(Book book)
        {
            await _booksService.UpdateBook(book);
            _logger.Information($"Book named: {book.Name} updated");
            return Ok();
        }

        [HttpDelete("[action]/{id:length(24)}", Name = "DeleteBook")]
        public async Task<ActionResult<bool>> DeleteBook(String id)
        {
            await _booksService.DeleteBook(id);
            _logger.Information($"Book with id : {id} deleted");
            return Ok();
        }
    }

}
