namespace Teh_te4_tekh_ORM.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Previously known as ApplicationUser.
    /// </summary>
    public class User
    {
        [Key]
        public int User { get; set; }

        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}