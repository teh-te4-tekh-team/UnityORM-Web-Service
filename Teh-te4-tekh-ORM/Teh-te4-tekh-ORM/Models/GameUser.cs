namespace Teh_te4_tekh_ORM.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GameUser
    {
        [Key]
        public int GameUserID { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        
    }
}