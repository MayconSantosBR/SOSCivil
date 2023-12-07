using MongoDB.Bson.Serialization.Attributes;

namespace SosCivil.Api.Data.Entities.Mongo
{
    public class OccurrenceDocuments
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }
    }
}
