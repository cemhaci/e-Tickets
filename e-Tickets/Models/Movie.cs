using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using e_Tickets.Enum;

namespace e_Tickets.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string imageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public List<Actor_Movie> Actor_Movies { get; set; }
        public List<Movie_Producer> movie_Producers { get; set; }
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }
        //public int ProducerId { get; set; }
        //[ForeignKey("ProducerId")]
        //public Producer Prodecer { get; set; }
        
    }
}
