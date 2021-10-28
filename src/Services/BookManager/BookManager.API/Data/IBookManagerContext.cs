using BookManager.API.Entities;
using MongoDB.Driver;

namespace BookManager.API.Data
{
    public interface IBookManagerContext
    {
        IMongoCollection<Book> Books { get; }
    }
}
