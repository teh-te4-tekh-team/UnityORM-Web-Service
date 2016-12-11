namespace Teh_te4_tekh_ORM.Models
{
    using System.Collections.Generic;

    public class Map
    {
        public int Id { get; set; }

        public virtual ICollection<SpawnPoint> SpawnPoints { get; set; }
    }
}
