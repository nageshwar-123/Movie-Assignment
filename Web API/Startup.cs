using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoventureApi.Authorization;
using MoventureApi.Entities;
using MoventureApi.Helpers;
using MoventureApi.Services;
using System;
using Moventureapi.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MoventureApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // add services to the DI container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddCors();
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
               

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMovieListService, MovieListService>();
            services.AddScoped<ICastService, CastService>();
            services.AddScoped<IThumbnailService, ThumbnailService>();
            services.AddScoped<IMovieDetailService, MovieDetailService>();
            
        }

        // configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            createTestData(context);

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
            //app.UseAuthentication();
            //app.UseAuthentication();            
            app.UseEndpoints(x => x.MapControllers());
        }

        #region Commented
        /*
        private void createTestData(DataContext context)
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


            var Movie1 = new Movie
            {
                MovieId = 1,
                MovieName = "Movie01",                               
            };
            context.Add(Movie1);

            var Movie2 = new Movie
            {
                MovieId = 2,
                MovieName = "Movie02",
            };
            context.Add(Movie2);

            var MovieDetails1 = new MovieDetail {
                MovieDetailId = 1,
                MovieId = 2,
                Description = "dadadddadadddadads",
                DurationInMinutes = 181,
                Release = DateTime.Now

            };
            context.Add(MovieDetails1);

            var MovieDetails2 = new MovieDetail
            {
                MovieDetailId = 2,
                MovieId = 1,
                Description = "qeqeqeqeqeqeqeqeqeqeqe",
                DurationInMinutes = 171,
                Release = DateTime.Now

            };
            context.Add(MovieDetails1);

            var cast1 = new Cast {
                CastId = 1,
                CastName="xxxx"
            };
            context.Add(cast1);

            var cast2 = new Cast
            {
                CastId = 2,
                CastName = "QQQQ"
            };
            context.Add(cast2);

            var cast3 = new Cast
            {
                CastId = 3,
                CastName = "wwww"
            };
            context.Add(cast3);


            var moviecast1 = new MovieCast {
                Id =1,
                CastId=1,
                MovieId=1,
                Character ="AAAAA"
            };
            context.Add(moviecast1);

            var moviecast2 = new MovieCast
            {
                Id = 2,
                CastId =2,
                MovieId = 2,
                Character = "YYYY"
            };
            context.Add(moviecast2);


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
                IsCover=false,
                ThumbnailPath = "c:\\test2.jpg"
            };
            context.Thumbnails.Add(t2);

            context.SaveChanges();
        }
    */
        #endregion

        public void createTestData(DataContext context)
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




            // DurationInMinutes = 181,
            // Release = DateTime.Now,
            var t1 = new Thumbnail
            {
                ThumbnailId = 1,
                ParentId = 1,
                ParentType = 1,
                IsCover = true,
                ThumbnailPath = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSNPj2bgqy8zGbvRUZPOpXvF58dwGwGk_1-GX1P_m7yHnj-8Ebd"
            };
            context.Thumbnails.Add(t1);

            // Release = DateTime.Now,
            var t2 = new Thumbnail
            {
                ThumbnailId = 2,
                ParentId = 2,
                ParentType = 1,
                IsCover = true,
                ThumbnailPath = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTh6DdPBhzs5OuDYGiYTqRh6YyLWQV8bUOuL7d0TBD8o9zk15fq"
            };
            context.Thumbnails.Add(t2);
            var t3 = new Thumbnail
            {
                ThumbnailId = 3,
                ParentId = 3,
                ParentType = 1,
                IsCover = true,
                ThumbnailPath = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSaB4uEmVrC_YTHxGJI1TgrP1rQ3XDO6yd26lUKmJM_5f2NrpTY"
            };
            context.Thumbnails.Add(t3);

            var t4 = new Thumbnail
            {
                ThumbnailId = 4,
                ParentId = 4,
                ParentType = 1,
                IsCover = true,
                ThumbnailPath = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSFjKwkEgropMVZAIFXUlImtxT2_lKjTzp1dMhQvlAhd9Hf0moa"
            };
            context.Thumbnails.Add(t4);

            var t5 = new Thumbnail
            {
                ThumbnailId = 5,
                ParentId = 5,
                ParentType = 1,
                IsCover = true,
                ThumbnailPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSNeRdetiE_STQKG2S5StE4bh_aYLT7kQGNmtQUQWvNxxEY8lE"
            };
            context.Thumbnails.Add(t5);


            var t6 = new Thumbnail
            {
                ThumbnailId = 6,
                ParentId = 6,
                ParentType = 1,
                IsCover = true,
                ThumbnailPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSNeRdetiE_STQKG2S5StE4bh_aYLT7kQGNmtQUQWvNxxEY8lE"
            };
            context.Thumbnails.Add(t6);

            var Movie1 = new Movie
            {
                MovieId = 1,
                MovieName = "Godzilla vs. Kong",
                category="Action",
                Thumbnails = new List<Thumbnail>() { t1}
            };
            context.MoviesList.Add(Movie1);

            var Movie2 = new Movie
            {
                MovieId = 2,
                MovieName = "Wonder Woman 1984",
                category = "Action",
                Thumbnails = new List<Thumbnail>() { t2 },

            };
            context.MoviesList.Add(Movie2);
            //context.MoviesList.Add(Movie2);


            var Movie3 = new Movie
            {
                MovieId = 3,
                MovieName = "Monster Hunter",
                category = "Action",
                Thumbnails = new List<Thumbnail>() { t3 },

            };
            context.MoviesList.Add(Movie3);

            var Movie4 = new Movie
            {
                MovieId = 4,
                MovieName = "Tenet",
                category = "Action",
                Thumbnails = new List<Thumbnail>() { t4 },

            };
            context.MoviesList.Add(Movie4);

            var Movie5 = new Movie
            {
                MovieId = 5,
                MovieName = "Karnan",
                category = "Horror",
                Thumbnails = new List<Thumbnail>() { t5 },

            };
            context.MoviesList.Add(Movie5);

            var t7 = new Thumbnail
            {
                ThumbnailId = 7,
                ParentId = 1,
                ParentType = 1,
                IsCover = false,
                ThumbnailPath = "https://www.thewrap.com/wp-content/uploads/2017/05/peter-quill-chris-pratt-star-lord-guardians-of-the-galaxy-vol-2.jpg"
            };
            context.Thumbnails.Add(t7);
            var t12 = new Thumbnail
            {
                ThumbnailId = 12,
                ParentId = 2,
                ParentType = 1,
                IsCover = false,
                ThumbnailPath = "https://www.thewrap.com/wp-content/uploads/2016/11/Chris-Evans-Captain-America-Trilogy.jpg"
            };
            var t13 = new Thumbnail
            {
                ThumbnailId = 13,
                ParentId = 2,
                ParentType = 1,
                IsCover = false,
                ThumbnailPath = "https://www.thewrap.com/wp-content/uploads/2016/11/Chris-Evans-Captain-America-Trilogy.jpg"
            };
            var c1 = new Cast
            {
                CastId = 1,
                CastName = "Chris Pratt ",
                Thumbnails = new List<Thumbnail>() { t12  },
                Movies = new List<MovieDetail>()

            };
            context.CastList.Add(c1);

            var t8 = new Thumbnail
            {
                ThumbnailId = 8,
                ParentId = 2,
                ParentType = 1,
                IsCover = false,
                ThumbnailPath = "https://www.thewrap.com/wp-content/uploads/2016/11/Chris-Evans-Captain-America-Trilogy.jpg"
            };
            var t11 = new Thumbnail
            {
                ThumbnailId = 11,
                ParentId = 2,
                ParentType = 1,
                IsCover = false,
                ThumbnailPath = "https://www.thewrap.com/wp-content/uploads/2016/11/Chris-Evans-Captain-America-Trilogy.jpg"
            };
            context.Thumbnails.Add(t8);

            var c2 = new Cast
            {
                CastId = 2,
                CastName = " Chris Evans ",
                Thumbnails = new List<Thumbnail>() { t11},
                Movies = new List<MovieDetail>()

            };
            context.CastList.Add(c2);


            var t9 = new Thumbnail
            {
                ThumbnailId = 9,
                ParentId = 3,
                ParentType = 1,
                IsCover = false,
                ThumbnailPath = "https://www.thewrap.com/wp-content/uploads/2016/08/tom.jpg"
            };
            context.Thumbnails.Add(t9);
            var c3 = new Cast
            {
                CastId = 3,
                CastName = " Tom Cruise ",
                Thumbnails = new List<Thumbnail>() { t9 },
                Movies = new List<MovieDetail>()

            };
            context.CastList.Add(c3);

            var c4 = new Cast
            {
                CastId = 4,
                CastName = " Tom ",
                Thumbnails = new List<Thumbnail>() { t8 },
                Movies = new List<MovieDetail>()

            };
            context.CastList.Add(c4);

            var c5 = new Cast
            {
                CastId = 5,
                CastName = " Pavan ",
                Thumbnails = new List<Thumbnail>() { t7 },
                Movies = new List<MovieDetail>()

            };
            context.CastList.Add(c5);

            var md1 = new MovieDetail
            {
                MovieDetailId = 1,
                MovieId = 1,
                Genre ="Action",
                MovieTypeDesc = "md1 type desc",
                Description = "A hardened mercenary's mission becomes a soul-searching race to survive when he's sent into Bangladesh to rescue a drug lord's kidnapped son.",
                DurationInMinutes = 120,
                Release = System.DateTime.Today,
                Casts = new List<Cast> { c1,c2 }
            };
            context.MovieDetail.Add(md1);

            var md2 = new MovieDetail
            {
                MovieDetailId = 2,
                MovieId = 2,
                Genre = "Drama",
                MovieTypeDesc = "md1 type desc",
                Description = "When rogue scientists set out to reset the balance of humanity by awakening the world's monsters, Godzilla must rise to fend off these chaotic titans.",
                DurationInMinutes = 120,
                Release = System.DateTime.Today,
                Casts = new List<Cast> { c2,c2 }
            };
            context.MovieDetail.Add(md2);

            var md3 = new MovieDetail
            {
                MovieDetailId = 3,
                MovieId = 3,
                Genre = "Action",
                MovieTypeDesc = "md1 type desc",
                Description = "The owners of a dinosaur theme park try to attract tourists with a thrilling new exhibit, but a deadly giant breaks loose and terrorizes the island.",
                DurationInMinutes = 120,
                Release = System.DateTime.Today,
                Casts = new List<Cast> { c3,c2}
            };
            context.MovieDetail.Add(md3);

            var md4 = new MovieDetail
            {
                MovieDetailId = 4,
                MovieId = 4,
                Genre = "Fantacy",
                MovieTypeDesc = "md1 type desc",
                Description = "When Chris and his son are evicted, they face trying times as a desperate Chris accepts an unpaid internship at a stock brokerage firm.",
                DurationInMinutes = 120,
                Release = System.DateTime.Today,
                Casts = new List<Cast> { c4,c3 }
            };
            context.MovieDetail.Add(md4);

            var md5 = new MovieDetail
            {
                MovieDetailId = 5,
                MovieId = 5,
                Genre = "Horror",
                MovieTypeDesc = "md1 type desc",
                Description = "A boy stands on a station platform as a train is about to leave. Should he go with his mother or stay with his father? Infinite possibilities arise from this decision. As long as he doesn't choose, anything is possible.",
                DurationInMinutes = 120,
                Release = System.DateTime.Today,
                Casts = new List<Cast> { c5,c4 }
            };
            context.MovieDetail.Add(md5);

            var moviecast1 = new MovieCast
            {
                Id = 1,
                CastId = 1,
                MovieId = 1,
                Character = "Action"
            };
            context.Add(moviecast1);

            var moviecast2 = new MovieCast
            {
                Id = 2,
                CastId = 2,
                MovieId = 2,
                Character = "fantaci"
            };
            context.Add(moviecast2);

            var moviecast3 = new MovieCast
            {
                Id = 3,
                CastId = 3,
                MovieId = 3,
                Character = "Romance"
            };
            context.Add(moviecast3);

            var moviecast4 = new MovieCast
            {
                Id = 4,
                CastId = 4,
                MovieId = 4,
                Character = "Thirllr"
            };
            context.Add(moviecast4);

            var moviecast5 = new MovieCast
            {
                Id = 5,
                CastId = 5,
                MovieId = 5,
                Character = "Hero5"
            };
            context.Add(moviecast5);

            var moviecast6 = new MovieCast
            {
                Id = 6,
                CastId = 2,
                MovieId = 1,
                Character = "Hero4"
            };
            context.Add(moviecast6);

            var moviecast7 = new MovieCast
            {
                Id = 7,
                CastId = 3,
                MovieId = 2,
                Character = "Hero3"
            };
            context.Add(moviecast7);

            var moviecast8 = new MovieCast
            {
                Id = 8,
                CastId = 4,
                MovieId = 3,
                Character = "Hero2"
            };
            context.Add(moviecast8);

            var moviecast9 = new MovieCast
            {
                Id = 9,
                CastId = 5,
                MovieId = 4,
                Character = "Hero1"
            };
            context.Add(moviecast9);

            var moviecast10 = new MovieCast
            {
                Id = 10,
                CastId = 1,
                MovieId = 5,
                Character = "Hero"
            };
            context.Add(moviecast10);

            // context.MoviesList.Add(Movie2);
            //context.CastList.Add(c1);



            context.SaveChanges();
        }

    }
}
