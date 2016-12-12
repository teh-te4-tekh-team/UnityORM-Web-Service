namespace Orm.Models.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Previously known as ApplicationUser.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}