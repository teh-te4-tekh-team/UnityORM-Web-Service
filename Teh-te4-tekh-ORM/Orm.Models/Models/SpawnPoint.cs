namespace Orm.Models.Models
{
    /// <summary>
    /// Simple point data structure.
    /// </summary>
    public class SpawnPoint
    {
        public int Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public virtual CheckPoint CheckPoint { get; set; }
    }
}