namespace Teh_te4_tekh_ORM.Models
{
    public class SpawnPoint
    {
        public int Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public virtual CheckPoint CheckPoint { get; set; }
    }
}
