
using BookManager.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BookManager.API.Data
{
    public class BookManagerContext : IBookManagerContext
    {
        public BookManagerContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("BooksDB"));
            var dbConfig = configuration.GetSection("BookManagementDatabaseSettings");
            var database = client.GetDatabase(dbConfig["DatabaseName"]);
            Books = database.GetCollection<Book>(dbConfig["CollectionName"]);
        }

        public IMongoCollection<Book> Books { get; }
    }
}
