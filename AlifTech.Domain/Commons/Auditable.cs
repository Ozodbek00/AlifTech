using System.Text.Json.Serialization;

namespace AlifTech.Domain.Commons
{
    public abstract class Auditable
    {
        /// <summary>
        /// Gets && sets Id of an entity.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets && sets Created Time of an entity.
        /// </summary>
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets && sets Updated Time of an entity.
        /// </summary>
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }
    }
}
