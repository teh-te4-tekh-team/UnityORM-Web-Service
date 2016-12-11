namespace Teh_te4_tekh_ORM.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains data about position. 
    /// Provides information about where the "Checkpoint" is.
    /// </summary>
    public class CheckPoint
    {
        public int Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        /// <summary>
        /// Data about points used for spawning.
        /// </summary>
        public virtual ICollection<SpawnPoint> SpawnPoints { get; set; }
    }
}
