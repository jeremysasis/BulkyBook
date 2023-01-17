using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public bool AccountStatus { get; set; }

    }
}
