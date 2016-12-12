namespace Orm.Models.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Previosly known as GameUser.
    /// </summary>
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
    }
}