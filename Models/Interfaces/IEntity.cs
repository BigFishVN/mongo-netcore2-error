// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IEntity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Models.Interfaces
{
    /// <summary>
    /// The Entity interface.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        int Age { get; set; }
    }
}