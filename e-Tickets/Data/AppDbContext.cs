using System.Xml;
using e_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId,
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actor_Movie).HasForeignKey(m => m.ActorId);


            modelBuilder.Entity<Movie_Producer>().HasKey(an => new
            {
                an.MovieId,
                an.Producerid
            });
            modelBuilder.Entity<Movie_Producer>().HasOne(n => n.Movie).WithMany(an => an.movie_Producers).HasForeignKey(n => n.MovieId);
            modelBuilder.Entity<Movie_Producer>().HasOne(n => n.producer).WithMany(an => an.Movie_Producers).HasForeignKey(n => n.Producerid);

            modelBuilder.Entity<Cinema>().HasData( 
            new Cinema()
            {
                id= 1,
            Name = "Cinema 1",
            logo = "https://image.tmdb.org/t/p/w500/dXyIK3s8ZN7FH3AoaeyaBqX0eoJ.jpg",
                Description = "this is description"
            },
             new Cinema()
             {
                 id= 2,
                 Name = "Cinema 2",
                 logo = "https://tr.web.img4.acsta.net/r_1280_720/medias/nmedia/18/35/14/33/18363640.jpg",
                 Description = "this is description"
             },
               new Cinema()
               {
                   id= 3,
                   Name = "Cinema 3",
                   logo = "https://www.4kfilmizlesene.xyz/wp-content/uploads/2020/12/Pirates-of-the-Caribbean-At-Worlds-End-2007.png",
                   Description = "this is description"
               },
                new Cinema()
                {
                    id= 4,
                    Name = "Cinema 4",
                    logo = "https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_.jpg",
                    Description = "this is description"
                },
            new Cinema()
            {
                id= 5,
                Name = "Cinema 5",
                logo = "https://m.media-amazon.com/images/M/MV5BZjgxY2JkNjEtZmQ2NC00YWM4LWE5ZjEtYzg5MjY2Yjc5Y2ZmXkEyXkFqcGdeQXVyMjExNjgyMTc@._V1_.jpg",
                Description = "this is description"
            }
            );

            modelBuilder.Entity<Actor>().HasData(new Actor()
            {
                id=1,
                FullName = "Orlando Bloom",
                Bio = "This is the bio of the actor",
                ProfilePictureUrl = "https://www.hollywoodreporter.com/wp-content/uploads/2013/08/orlando_bloom_cannes_a_p.jpg?w=2000&h=1126&crop=1"
            },
                new Actor()
                {
                    id=2,
                    FullName = "Johnney Depp",
                    Bio = "This is the bio of the actor",
                    ProfilePictureUrl = "https://m.media-amazon.com/images/M/MV5BOTBhMTI1NDQtYmU4Mi00MjYyLTk5MjEtZjllMDkxOWY3ZGRhXkEyXkFqcGdeQXVyNzI1NzMxNzM@._V1_UY1200_CR92,0,630,1200_AL_.jpg"
                },
                new Actor()
                {
                    id=3,
                    FullName = "Mortensen Viggo",
                    Bio = "This is the bio of the actor",
                    ProfilePictureUrl = "http://images6.fanpop.com/image/photos/40800000/Viggo-Mortensen-viggo-mortensen-40837689-400-600.jpg"
                },
                new Actor()
                {
                    id=4,
                    FullName = "Tom Hanks",
                    Bio = "This is the bio of the actor",
                    ProfilePictureUrl = "https://media.bantmag.com/wp-content/uploads/t/tom-hanks-1040cs013013.jpg"
                },
                new Actor()
                {
                    id=5,
                    FullName = "Morgan Freeman",
                    Bio = "This is the bio of the actor",
                    ProfilePictureUrl = "http://images6.fanpop.com/image/photos/43400000/Morgan-Freeman-morgan-freeman-43437800-1024-768.png"
                },
                new Actor()
                {
                    id=6,
                    FullName = "Cem Yılmaz",
                    Bio = "This is the bio of the actor",
                    ProfilePictureUrl = "https://m.media-amazon.com/images/M/MV5BMTU5NzYxMDM3N15BMl5BanBnXkFtZTgwMDEzMTE4MTE@._V1_.jpg"
                });
            modelBuilder.Entity<Producer>().HasData(new Producer()
            {
                id=1,
                FullName = "Cem Yılmaz",
                Bio = "This is the bio of the producer",
                ProfilePictureUrl = "https://m.media-amazon.com/images/M/MV5BMTU5NzYxMDM3N15BMl5BanBnXkFtZTgwMDEzMTE4MTE@._V1_.jpg"
            },
                new Producer()
                {id=2,
                    FullName = "Jerry Bruckheimer",
                    Bio = "This is the bio of the producer",
                    ProfilePictureUrl = "https://media-cldnry.s-nbcnews.com/image/upload/rockcms/2022-05/220517-jerry-bruckheimer-mjf-1443-094576.jpg"
                },
                new Producer()
                {id=3,
                    FullName = "Niki Marvin",
                    Bio = "This is the bio of the producer",
                    ProfilePictureUrl = "https://images.mubicdn.net/images/cast_member/23718/cache-209048-1489646455/image-w856.jpg"
                },
                new Producer()
                {
                    id=4,
                    FullName = "Peter Jackson",
                    Bio = "This is the bio of the producer",
                    ProfilePictureUrl = "https://m.media-amazon.com/images/M/MV5BYjFjOThjMjgtYzM5ZS00Yjc0LTk5OTAtYWE4Y2IzMDYyZTI5XkEyXkFqcGdeQXVyMTMxMTIwMTE0._V1_QL75_UY207_CR74,0,140,207_.jpg"
                },
                new Producer()
                {
                    id=5,
                    FullName = "Fran Walsh",
                    Bio = "This is the bio of the producer",
                    ProfilePictureUrl = "https://static.wikia.nocookie.net/lotr/images/5/58/Fran_Walsh.jpg/revision/latest?cb=20070425223838"
                },
                new Producer()
                {
                    id=6,   
                    FullName = "Barrie M. Osborne",
                    Bio = "This is the bio of the producer",
                    ProfilePictureUrl = "https://crewlist.s3.amazonaws.com/images/profile/full/1519507379454710.jpg"
                },
                 new Producer()
                 {
                     id=7,
                     FullName = "Frank Darabont",
                     Bio = "This is the bio of the producer",
                     ProfilePictureUrl = "https://www.hollywoodreporter.com/wp-content/uploads/2014/06/frank_darabont.jpg"
                 },
                     new Producer()
                     {
                         id=8,
                         FullName = "David Valdes",
                         Bio = "This is the bio of the producer",
                         ProfilePictureUrl = "https://pbs.twimg.com/profile_images/1475815608906391554/vYs2cEB6_400x400.jpg"
                     },
                new Producer()
                {
                    id=9,
                    FullName = "David Valdes",
                    Bio = "This is the bio of the producer",
                    ProfilePictureUrl = "https://pbs.twimg.com/profile_images/1475815608906391554/vYs2cEB6_400x400.jpg"
                });
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                id=1,
                Name = "AROG",
                Description = "This is the Arog movie description",
                Price = 45,
                imageUrl = "https://m.media-amazon.com/images/M/MV5BZjgxY2JkNjEtZmQ2NC00YWM4LWE5ZjEtYzg5MjY2Yjc5Y2ZmXkEyXkFqcGdeQXVyMjExNjgyMTc@._V1_.jpg",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                CinemaId = 5,
                MovieCategory = Enum.MovieCategory.Comedy
            },
                  new Movie()
                  {
                      id=2,
                      Name = "PARİTES OF THE CERİBBEAN at World's End",
                      Description = "This is the Arog movie description",
                      Price = 60,
                      imageUrl = "https://www.4kfilmizlesene.xyz/wp-content/uploads/2020/12/Pirates-of-the-Caribbean-At-Worlds-End-2007.png",
                      StartDate = DateTime.Now,
                      EndDate = DateTime.Now.AddDays(4),
                      CinemaId = 3,
                      MovieCategory = Enum.MovieCategory.Fantastic
                  },
                  new Movie()
                  {
                      id=3,
                      Name = "ESARETİN BEDELİ",
                      Description = "This is the Arog movie description",
                      Price = 60,
                      imageUrl = "https://image.tmdb.org/t/p/w500/dXyIK3s8ZN7FH3AoaeyaBqX0eoJ.jpg",
                      StartDate = DateTime.Now,
                      EndDate = DateTime.Now.AddDays(3),
                      CinemaId = 1,
                      MovieCategory = Enum.MovieCategory.Drama
                  },
                    new Movie()
                    {
                        id=4,
                        Name = "THE GREEN MİLE",
                        Description = "This is the Arog movie description",
                        Price = 60,
                        imageUrl = "https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_.jpg",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(10),
                        CinemaId = 4,
                        MovieCategory = Enum.MovieCategory.Drama
                    },
                  new Movie()
                  {
                      id=5,
                      Name = "THE LORD OF THE RİNGS The Return Of The King",
                      Description = "This is the Arog movie description",
                      Price = 60,
                      imageUrl = "https://moviesmedia.ign.com/movies/image/object/487/487665/lotr_the-return-of-the-king_poster.jpg?width=300",
                      StartDate = DateTime.Now,
                      EndDate = DateTime.Now.AddDays(10),
                      CinemaId = 2,
                      MovieCategory = Enum.MovieCategory.ScienceFiction
                  });
            modelBuilder.Entity<Actor_Movie>().HasData(
                new Actor_Movie()
            {
                ActorId = 1,
                MovieId = 5
            },
                new Actor_Movie()
                {
                    ActorId = 2,
                    MovieId = 2
                },
                new Actor_Movie()
                {
                    ActorId = 3,
                    MovieId = 5
                },
                new Actor_Movie()
                {
                    ActorId = 4,
                    MovieId = 4,
                },
                new Actor_Movie()
                {
                    ActorId = 5,
                    MovieId = 3,
                },
                new Actor_Movie()
                {
                    ActorId = 6,
                    MovieId = 1,
                });
            modelBuilder.Entity<Movie_Producer>().HasData(new Movie_Producer()
            {
                MovieId = 1,
                Producerid = 1,
            },
                new Movie_Producer()
                {
                    MovieId = 2,
                    Producerid = 2
                },
                new Movie_Producer()
                {
                    MovieId = 3,
                    Producerid = 3
                },
                new Movie_Producer()
                {
                    MovieId = 4,
                    Producerid = 7
                },
                 new Movie_Producer()
                 {
                     MovieId = 4,
                     Producerid = 8
                 },
                 new Movie_Producer()
                 {
                     MovieId = 5,
                     Producerid = 4
                 },
                  new Movie_Producer()
                  {
                      MovieId = 5,
                      Producerid = 5
                  },
                   new Movie_Producer()
                   {
                       MovieId = 5,
                       Producerid = 6
                   });

            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Movie_Producer> movie_Producers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> likes { get;set;}
    }
}
