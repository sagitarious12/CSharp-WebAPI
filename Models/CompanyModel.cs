using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Web_API_Test.Models
{
    public class Company
    {
        // mongoDB Object ID
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }


        // name of the company
        [BsonElement("name")]
        public string Name { get; set; }


        // company id. can be used for various purposes.
        [BsonElement("id")]
        public string Id { get; set; }


        // this is the mongo db version
        [BsonElement("__v")]
        public int __v { get; set; }
    }
}
