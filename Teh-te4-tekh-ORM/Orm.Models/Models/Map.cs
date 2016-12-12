namespace Orm.Models.Models
{
    using System.Collections.Generic;

    public class Map
    {
        public Map()
        {
            this.SpawnPoints = new List<CheckPoint>();
        }

        public int Id { get; set; }

        public virtual ICollection<CheckPoint> SpawnPoints { get; set; }
    }
}