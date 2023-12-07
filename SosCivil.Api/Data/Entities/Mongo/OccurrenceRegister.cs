using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SosCivil.Api.Data.Entities.Mongo
{
    public class OccurrenceRegister
    {
        [BsonElement("_id")]
        [JsonProperty("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("occurrence_id")]
        public long OccurrenceId { get; set; }

        [BsonElement("documents")]
        public List<OccurrenceDocuments>? Documents = new();
    }
}
