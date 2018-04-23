using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data;
using ECommerce.Data.Entities;
using ECommerce.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Stripe;

namespace ECommerce
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
      services.AddDbContext<EcommerceContext>(options =>
          options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

      services.AddIdentity<AppUser, AppRole>()
          .AddEntityFrameworkStores<EcommerceContext>()
          .AddDefaultTokenProviders();

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(options =>
      {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.ClaimsIssuer = Configuration["Authentication:JwtIssuer"];

        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidIssuer = Configuration["Authentication:JwtIssuer"],

          ValidateAudience = true,
          ValidAudience = Configuration["Authentication:JwtAudience"],

          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:JwtKey"])),

          RequireExpirationTime = true,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero
        };
      });

      services.AddMvc();

      services.Configure<RazorViewEngineOptions>(options =>
      {
        options.ViewLocationExpanders.Add(new FeatureLocationExpander());
      });

      var provider = services.BuildServiceProvider();
      DbContextExtensions.UserManager = provider.GetService<UserManager<AppUser>>();
      DbContextExtensions.RoleManager = provider.GetService<RoleManager<AppRole>>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
        {
          HotModuleReplacement = true
        });
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseAuthentication();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");

        routes.MapSpaFallbackRoute(
                  name: "spa-fallback",
                  defaults: new { controller = "Home", action = "Index" });
      });

      StripeConfiguration.SetApiKey("sk_test_GFKu2bTKDyJw20szsYD2vrFY");
    }
  }
}
