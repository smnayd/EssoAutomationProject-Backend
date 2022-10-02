using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EssoOtomationProject.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        [Required,NotNull]
        public string FirstName { get; set; }

        [Required, NotNull]
        public string LastName { get; set; }

        [Required,NotNull]
        public string Email { get; set; }

        [Required,NotNull]
        public string UserName { get; set; }

        [Required,NotNull]
        public string Password { get; set; }
    }
}
