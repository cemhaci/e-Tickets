using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace e_Tickets.Models
{
    public class Actor
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Profile Picture")]
        [StringLength(500, ErrorMessage = "Profile Picture must be max 100 chars")]
        public string ProfilePictureUrl { get; set; } = "user1.jpg";
        [Required]
        [DisplayName("Full Name")]
        [StringLength(30,MinimumLength =6,ErrorMessage ="Full Name must be between 6 and 30 chars")]
        public string? FullName { get; set; }
        [Required]
        [DisplayName("Biography")]
        [StringLength(500, ErrorMessage = "Biography must be max 500 chars")]
        public string? Bio { get; set; }
        public List<Actor_Movie>? Actor_Movie { get; set; }

    }
}
