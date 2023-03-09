using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Tickets.Models
{
    public class Producer
    {
        [Key]
        public int id { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public List<Movie_Producer> Movie_Producers { get; set; }
    }
}
