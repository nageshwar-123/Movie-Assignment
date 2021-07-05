using MoventureApi.Entities;
using MoventureApi.Helpers;
using BCryptNet = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Helpers
{
    public class TestData
    {

        public void createTestData(DataContext context)
        {

            createTestUsers(context);



            // DurationInMinutes = 181,
            // Release = DateTime.Now,
            var t1 = new Thumbnail
            {
                ThumbnailId = 1,
                ParentId = 1,
                ParentType = 1,
                IsCover = true,
                ThumbnailPath = "c:\\test.jpg"
            };
            context.Thumbnails.Add(t1);

            // Release = DateTime.Now,
            var t2 = new Thumbnail
            {
                ThumbnailId = 2,
                ParentId = 1,
                ParentType = 1,
                IsCover = false,
                ThumbnailPath = "c:\\test2.jpg"
            };
            context.Thumbnails.Add(t2);
            var t3 = new Thumbnail
            {
                ThumbnailId = 3,
                ParentId = 2,
                ParentType = 1,
                IsCover = true,
                ThumbnailPath = "c:\\test3.jpg"
            };
            context.Thumbnails.Add(t3);

           

            var c1 = new Cast
            {
                CastId = 1,
                CastName = "cn1",

                Thumbnails = new List<Thumbnail>() { t3 },
                Movies = new List<MovieDetail>()

            };
            //context.CastList.Add(c1);

            //var c2 = new Cast
            //{
            //    CastId = 2,
            //    CastName = "cn2",

            //    Thumbnails = new List<Thumbnail>() { t2 },
            //    Movies = new List<MovieDetail>()

            //};
            //context.CastList.Add(c2);

            var md1 = new MovieDetail
            {
                MovieDetailId = 1,
                MovieId = 1,
                MovieTypeDesc = "md1 type desc",
                Description = "md1 desc",
                DurationInMinutes = 120,
                Release = System.DateTime.Today,

                Casts = new List<Cast> { c1 }
            };
            c1.Movies.Add(md1);
            //context.MoviesList.Add(Movie2);
            context.CastList.Add(c1);



            context.SaveChanges();
        }

        public void createMovies(DataContext context)
        {
            var Movie1 = new Movie
            {
                MovieId = 1,
                MovieName = "PROJECT POWER",
                //Thumbnails = new List<Thumbnail>() { t1, t2 }
            };
            context.MoviesList.Add(Movie1);

            var Movie2 = new Movie
            {
                MovieId = 2,
                MovieName = "WITHOUT REMORES",
                //Thumbnails = new List<Thumbnail>() { t3 },

            };
            context.MoviesList.Add(Movie2);


            var Movie3 = new Movie
            {
                MovieId = 3,
                MovieName = "SPENCER",
                //Thumbnails = new List<Thumbnail>() { t3 },

            };
            context.MoviesList.Add(Movie3);

            var Movie4 = new Movie
            {
                MovieId = 4,
                MovieName = "MORTAL ENGINTS",
               // Thumbnails = new List<Thumbnail>() { t3 },

            };
            context.MoviesList.Add(Movie4);

            var Movie5 = new Movie
            {
                MovieId = 5,
                MovieName = "GOOD WILL HUNTING",
                //Thumbnails = new List<Thumbnail>() { t3 },

            };
            context.MoviesList.Add(Movie5);
        }

        public void createTestUsers(DataContext context)
        {
            // add hardcoded test user to db on startup
            var testUser = new User
            {
                UserId = 1,
                FirstName = "Test",
                LastName = "User",
                Username = "test",
                PasswordHash = BCryptNet.HashPassword("test")
            };
            context.Users.Add(testUser);

            var testUser1 = new User
            {
                UserId = 2,
                FirstName = "Test1",
                LastName = "User",
                Username = "test1",
                PasswordHash = BCryptNet.HashPassword("test1")
            };
            context.Users.Add(testUser1);
        }
    }
}
