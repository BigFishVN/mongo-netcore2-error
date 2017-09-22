// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseDbBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the BaseDbBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Contract.DbBuilder
{
    using Contract.Interfaces;

    /// <inheritdoc />
    public class BaseDbBuilder : IDbBuilder
    {
        /// <inheritdoc />
        public virtual string GetDatabaseName()
        {
            return "db_school";
        }

        /// <inheritdoc />
        public virtual string GetConnectionString()
        {
            return "mongodb://localhost:27017";
        }
    }
}