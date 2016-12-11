namespace Teh_te4_tekh_ORM.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Previosly known as GameUser.
    /// </summary>
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
    }
}