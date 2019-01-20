using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using SportApi.Models;
using System;
using System.IO;
using Newtonsoft.Json;

namespace SportApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SportContext>(opt =>
                opt.UseInMemoryDatabase("SportList"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SportContext>();
                AddTestData(context);
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void AddTestData(SportContext context)
        {
            try
            {   
                using (StreamReader sr = new StreamReader("api_data_source.txt"))
                {
                    String s = "";
                    
                    while ((s = sr.ReadLine()) != null) {
                        if (s == "Teams:") {
                            while ((s = sr.ReadLine()) != "") {
                                Team t = JsonConvert.DeserializeObject<Team>(s.TrimEnd(','));
                                context.Teams.Add(t);
                            }
                        } else if (s == "Players:") {
                            while ((s = sr.ReadLine()) != "") {
                                Player p = JsonConvert.DeserializeObject<Player>(s.TrimEnd(','));
                                context.Players.Add(p);
                            }
                        } else if (s == "Games:") {
                            while ((s = sr.ReadLine()) != "") {
                                Game g = JsonConvert.DeserializeObject<Game>(s.TrimEnd(','));
                                context.Games.Add(g);
                            }
                        } else if (s == "Player Stats:") {
                            while ((s = sr.ReadLine()) != "") {
                                PlayerStat ps = JsonConvert.DeserializeObject<PlayerStat>(s.TrimEnd(','));
                                context.PlayerStats.Add(ps);
                            }
                        } else if (s == "Game State:") {
                            while ((s = sr.ReadLine()) != "") {
                                GameState gs = JsonConvert.DeserializeObject<GameState>(s.TrimEnd(','));
                                context.GameStates.Add(gs);
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            finally {
                context.SaveChanges();
            }


            // var testUser1 = new Models.Player
            // {
            //     id = 1,
            //     name = "Jin",
            //     team_id = 1
            // };
        
            // context.Players.Add(testUser1);
        
            // var testPost1 = new Models.Team
            // {
            //     Id = "def234",
            //     UserId = testUser1.Id,
            //     Content = "What a piece of junk!"
            // };
        
            // context.Posts.Add(testPost1);
        }
    }
}
