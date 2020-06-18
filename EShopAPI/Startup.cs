using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EShopAPI.Contracts;
using EShopAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using EShopAPI.Context;

namespace EShopAPI
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
            services.AddSwaggerGen(swagger =>
            {
                //swagger.SwaggerDoc("v1", new Info
                //{
                //    Title = "My First Swagger"
                //});
               // swagger.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(), @"bin\Debug\netcoreapp2.1", "EShopAPI.xml"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<EShopAPI_DBContext>(options =>  options.UseSqlServer(Configuration.GetConnectionString("EShopAPI_DBContext")) );
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IAsyncGenericRepository<>), typeof( AsyncGenericRepository<>));

            services.AddResponseCaching();
            services.AddMemoryCache();
            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        //samte server etebarsanji beshavad
                        ValidateIssuer = true,
                        //samte client etebarsanji beshavad
                        ValidateAudience = false,
                        //bare token enqeza bezaram 
                        ValidateLifetime = true,
                        //on tokene etebarsanji beshavad
                        ValidateIssuerSigningKey = true,
                        //server valid
                        ValidIssuer = "http://localhost:6480",
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("OurVrifyWebApi"))
                    };
                });

            services.AddCors(options => {

                options.AddPolicy("EnableCourse", builder =>

                {
                    //baghiye dastresi dashtebashan ya na 
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                             //dar hameye methodha check beshe 
                             .AllowAnyMethod()
                             .AllowCredentials()
                             .Build();
                });

            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //tarif midleWare
            app.UseCors("EnableCourse");
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            { c.SwaggerEndpoint("/swagger/V1/swagger.json", "myfirstswagger"); }
            );
            app.UseResponseCaching();
            //app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Users}/{action=Index}/{id?}");
            });

        }
    }
}
