using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Integrador.Models
{
    public class Comments
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        [BsonElement("content")]
        public string Content { get; set; }
        [BsonElement("idService")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        
    }
}
