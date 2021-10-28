
using BookManager.API.Data;
using BookManager.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.API.Service
{
    public class BooksService : IBooksService
    {
        private readonly IBookManagerContext _context;
        public BooksService(IBookManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.Find(b => true).ToListAsync();
        }
        public async Task<Book> GetBookById(string id)
        {
            return await _context.Books.Find(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByName(string bookName)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.Name, bookName);
            return await _context.Books.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByGenre(string genreName)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.Genre, genreName);
            return await _context.Books.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(string authorName)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(p => p.Author, authorName);
            return await _context.Books.Find(filter).ToListAsync();
        }

        public async Task CreateBook(Book book)
        {
            await _context.Books.InsertOneAsync(book);
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var updateResult = await _context.Books.ReplaceOneAsync(filter: b => b.Id == book.Id, replacement: book);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteBook(string id)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(b => b.Id, id);
            var deleteResult = await _context.Books.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }

}
