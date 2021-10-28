using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BookManager.API.Entities
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Genre")]
        public string Genre { get; set; }
        [BsonElement("Author")]
        public string Author { get; set; }
        [BsonElement("ReleaseDate")]
        public DateTime ReleaseDate { get; set; }
        public int PageSize { get; set; }
        public bool isSeries { get; set; }
        public int Volume { get; set; }
        [BsonElement("SeriesId")]
        public string SeriesId { get; set; }


    }
}
