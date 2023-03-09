using System.ComponentModel.DataAnnotations;

namespace e_Tickets.Models
{
    public class Cinema
    {
        [Key]
        public int id { get; set; }
        public string logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }


    }
}
