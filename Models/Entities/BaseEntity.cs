// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseEntity.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the BaseEntity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Models.Entities
{
    using Models.Interfaces;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <inheritdoc />
    [BsonIgnoreExtraElements]
    public class BaseEntity : IEntity
    {
        /// <inheritdoc />
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <inheritdoc />
        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Code { get; set; }

        /// <inheritdoc />
        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public string Name { get; set; }

        /// <inheritdoc />
        [BsonIgnoreIfDefault]
        [BsonIgnoreIfNull]
        public int Age { get; set; }
    }
}