namespace e_Tickets.Models
{
    public class Movie_Producer
    {
        public int Producerid { get; set; }
        public Producer producer { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }


    }
}
