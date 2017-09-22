namespace Models.Model
{
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class ReferenceView
    {
        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public string Code { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public string ReferenceType { get; set; }
    }
}