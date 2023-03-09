using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Tickets.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activate = table.Column<bool>(type: "bit", nullable: false),
                    ProfileImageFile = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieCategory = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actors_Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors_Movies", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Actors_Movies_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actors_Movies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegesterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Movieid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Movies_Movieid",
                        column: x => x.Movieid,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Movieid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_likes_Movies_Movieid",
                        column: x => x.Movieid,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_likes_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movie_Producers",
                columns: table => new
                {
                    Producerid = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie_Producers", x => new { x.MovieId, x.Producerid });
                    table.ForeignKey(
                        name: "FK_movie_Producers_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movie_Producers_Producers_Producerid",
                        column: x => x.Producerid,
                        principalTable: "Producers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "id", "Bio", "FullName", "ProfilePictureUrl" },
                values: new object[,]
                {
                    { 1, "This is the bio of the actor", "Orlando Bloom", "https://www.hollywoodreporter.com/wp-content/uploads/2013/08/orlando_bloom_cannes_a_p.jpg?w=2000&h=1126&crop=1" },
                    { 2, "This is the bio of the actor", "Johnney Depp", "https://m.media-amazon.com/images/M/MV5BOTBhMTI1NDQtYmU4Mi00MjYyLTk5MjEtZjllMDkxOWY3ZGRhXkEyXkFqcGdeQXVyNzI1NzMxNzM@._V1_UY1200_CR92,0,630,1200_AL_.jpg" },
                    { 3, "This is the bio of the actor", "Mortensen Viggo", "http://images6.fanpop.com/image/photos/40800000/Viggo-Mortensen-viggo-mortensen-40837689-400-600.jpg" },
                    { 4, "This is the bio of the actor", "Tom Hanks", "https://media.bantmag.com/wp-content/uploads/t/tom-hanks-1040cs013013.jpg" },
                    { 5, "This is the bio of the actor", "Morgan Freeman", "http://images6.fanpop.com/image/photos/43400000/Morgan-Freeman-morgan-freeman-43437800-1024-768.png" },
                    { 6, "This is the bio of the actor", "Cem Yılmaz", "https://m.media-amazon.com/images/M/MV5BMTU5NzYxMDM3N15BMl5BanBnXkFtZTgwMDEzMTE4MTE@._V1_.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "id", "Description", "Name", "logo" },
                values: new object[,]
                {
                    { 1, "this is description", "Cinema 1", "https://image.tmdb.org/t/p/w500/dXyIK3s8ZN7FH3AoaeyaBqX0eoJ.jpg" },
                    { 2, "this is description", "Cinema 2", "https://tr.web.img4.acsta.net/r_1280_720/medias/nmedia/18/35/14/33/18363640.jpg" },
                    { 3, "this is description", "Cinema 3", "https://www.4kfilmizlesene.xyz/wp-content/uploads/2020/12/Pirates-of-the-Caribbean-At-Worlds-End-2007.png" },
                    { 4, "this is description", "Cinema 4", "https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_.jpg" },
                    { 5, "this is description", "Cinema 5", "https://m.media-amazon.com/images/M/MV5BZjgxY2JkNjEtZmQ2NC00YWM4LWE5ZjEtYzg5MjY2Yjc5Y2ZmXkEyXkFqcGdeQXVyMjExNjgyMTc@._V1_.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "id", "Bio", "FullName", "ProfilePictureUrl" },
                values: new object[,]
                {
                    { 1, "This is the bio of the producer", "Cem Yılmaz", "https://m.media-amazon.com/images/M/MV5BMTU5NzYxMDM3N15BMl5BanBnXkFtZTgwMDEzMTE4MTE@._V1_.jpg" },
                    { 2, "This is the bio of the producer", "Jerry Bruckheimer", "https://media-cldnry.s-nbcnews.com/image/upload/rockcms/2022-05/220517-jerry-bruckheimer-mjf-1443-094576.jpg" },
                    { 3, "This is the bio of the producer", "Niki Marvin", "https://images.mubicdn.net/images/cast_member/23718/cache-209048-1489646455/image-w856.jpg" },
                    { 4, "This is the bio of the producer", "Peter Jackson", "https://m.media-amazon.com/images/M/MV5BYjFjOThjMjgtYzM5ZS00Yjc0LTk5OTAtYWE4Y2IzMDYyZTI5XkEyXkFqcGdeQXVyMTMxMTIwMTE0._V1_QL75_UY207_CR74,0,140,207_.jpg" },
                    { 5, "This is the bio of the producer", "Fran Walsh", "https://static.wikia.nocookie.net/lotr/images/5/58/Fran_Walsh.jpg/revision/latest?cb=20070425223838" },
                    { 6, "This is the bio of the producer", "Barrie M. Osborne", "https://crewlist.s3.amazonaws.com/images/profile/full/1519507379454710.jpg" },
                    { 7, "This is the bio of the producer", "Frank Darabont", "https://www.hollywoodreporter.com/wp-content/uploads/2014/06/frank_darabont.jpg" },
                    { 8, "This is the bio of the producer", "David Valdes", "https://pbs.twimg.com/profile_images/1475815608906391554/vYs2cEB6_400x400.jpg" },
                    { 9, "This is the bio of the producer", "David Valdes", "https://pbs.twimg.com/profile_images/1475815608906391554/vYs2cEB6_400x400.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "CinemaId", "Description", "EndDate", "MovieCategory", "Name", "Price", "StartDate", "imageUrl" },
                values: new object[,]
                {
                    { 1, 5, "This is the Arog movie description", new DateTime(2023, 2, 4, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7024), 1, "AROG", 45.0, new DateTime(2023, 1, 28, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(6940), "https://m.media-amazon.com/images/M/MV5BZjgxY2JkNjEtZmQ2NC00YWM4LWE5ZjEtYzg5MjY2Yjc5Y2ZmXkEyXkFqcGdeQXVyMjExNjgyMTc@._V1_.jpg" },
                    { 2, 3, "This is the Arog movie description", new DateTime(2023, 2, 1, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7031), 5, "PARİTES OF THE CERİBBEAN at World's End", 60.0, new DateTime(2023, 1, 28, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7031), "https://www.4kfilmizlesene.xyz/wp-content/uploads/2020/12/Pirates-of-the-Caribbean-At-Worlds-End-2007.png" },
                    { 3, 1, "This is the Arog movie description", new DateTime(2023, 1, 31, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7033), 2, "ESARETİN BEDELİ", 60.0, new DateTime(2023, 1, 28, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7033), "https://image.tmdb.org/t/p/w500/dXyIK3s8ZN7FH3AoaeyaBqX0eoJ.jpg" },
                    { 4, 4, "This is the Arog movie description", new DateTime(2023, 2, 7, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7035), 2, "THE GREEN MİLE", 60.0, new DateTime(2023, 1, 28, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7035), "https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_.jpg" },
                    { 5, 2, "This is the Arog movie description", new DateTime(2023, 2, 7, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7037), 4, "THE LORD OF THE RİNGS The Return Of The King", 60.0, new DateTime(2023, 1, 28, 17, 0, 52, 740, DateTimeKind.Local).AddTicks(7037), "https://moviesmedia.ign.com/movies/image/object/487/487665/lotr_the-return-of-the-king_poster.jpg?width=300" }
                });

            migrationBuilder.InsertData(
                table: "Actors_Movies",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 2 },
                    { 3, 5 },
                    { 4, 4 },
                    { 5, 3 },
                    { 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "movie_Producers",
                columns: new[] { "MovieId", "Producerid" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 7 },
                    { 4, 8 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_Movies_MovieId",
                table: "Actors_Movies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Movieid",
                table: "Comments",
                column: "Movieid");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Userid",
                table: "Comments",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_likes_Movieid",
                table: "likes",
                column: "Movieid");

            migrationBuilder.CreateIndex(
                name: "IX_likes_Userid",
                table: "likes",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_movie_Producers_Producerid",
                table: "movie_Producers",
                column: "Producerid");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies",
                column: "CinemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actors_Movies");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropTable(
                name: "movie_Producers");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Cinemas");
        }
    }
}
