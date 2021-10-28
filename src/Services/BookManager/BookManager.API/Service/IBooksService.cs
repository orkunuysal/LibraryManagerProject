
using BookManager.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManager.API.Service
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(string id);
        Task<IEnumerable<Book>> GetBooksByName(string bookName);
        Task<IEnumerable<Book>> GetBooksByGenre(string genreName);
        Task<IEnumerable<Book>> GetBooksByAuthor(string authorName);
        Task CreateBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(string id);

    }
}
