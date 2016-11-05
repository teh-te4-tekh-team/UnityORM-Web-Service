namespace Teh_te4_tekh_ORM.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser
    {
        [Key]
        public int ApplicationUserID { get; set; }

        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}