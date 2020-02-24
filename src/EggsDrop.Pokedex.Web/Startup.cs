using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EggsDrop.Pokedex.Web
{
    /// <summary>
    /// Startup configuration class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // This is needed by SwaggerGen

            // Register Swagger generation
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v0",
                    new OpenApiInfo
                    {
                        Title = "EggsDrop Pokedex API",
                        Version = "v0",
                        Contact = new OpenApiContact
                        {
                            Name = "EggsDrop"
                        }
                    });

                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = $"{System.IO.Path.Combine(System.AppContext.BaseDirectory)}\\{xmlFile}";
            ;
                s.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Configure the application middleware.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            
                ConfigureSwagger(app);
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            // TODO: we will address CORS later
            //app.UseCors();

            // TODO: we will address auth later
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }

        /// <summary>
        /// Setup Swagger middleware
        /// </summary>
        private void ConfigureSwagger(IApplicationBuilder app)
        {
            // Enable Swagger middleware
            app.UseSwagger();

            // Enable Swagger UI middleware
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v0/swagger.json", "EggsDrop Pokedex API");
            });
        }
    }
}
