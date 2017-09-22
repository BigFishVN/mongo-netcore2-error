namespace Models.Entities
{
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class User : BaseEntity
    {
        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public string Username { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public string Password { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public string Email { get; set; }
    }
}