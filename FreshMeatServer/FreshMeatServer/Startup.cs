using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FreshMeatServer.Models;
using FreshMeatServer.Services;
using FreshMeatServer.DataModel;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using FreshMeatServer.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FreshMeatServer.Logics;
using FluentValidation.AspNetCore;
using FluentValidation;
using FreshMeatServer.Logics.Validators;
using FreshMeatServer.Hubs;

namespace FreshMeatServer
{
    public class Startup
    {
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddSingleton<IJwtFactory, JwtFactory>();

            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Configuration["JwtIssuerOptions:JwtClaimIdentifiers:Rol"], Configuration["JwtIssuerOptions:JwtClaims:ApiAccess"]));
            });



            services.AddCors();

            // Add application Repositories.
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IChildAttributeRepository, ChildAttributeRepository>();
            services.AddScoped<IChildAttributeSelectionRepository, ChildAttributeSelectionRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IMatcherRepository, MatcherRepository>();
            services.AddScoped<IParentAttributeRepository, ParentAttributeRepository>();
            services.AddScoped<IParentAttributeSelectionRepository, ParentAttributeSelectionRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IChildAttributeService, ChildAttributeService>();
            services.AddScoped<IChildAttributeSelectionService, ChildAttributeSelectionService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IMatcherService, MatcherService>();
            services.AddScoped<IParentAttributeService, ParentAttributeService>();
            services.AddScoped<IParentAttributeSelectionService, ParentAttributeSelectionService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IStatusService, StatusService>();

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver
                        = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                })
                .AddFluentValidation();
            var assembly = AssemblyScanner.FindValidatorsInAssemblyContaining<CharacterValidator>();
            assembly.ForEach(a => services.AddTransient(a.InterfaceType, a.ValidatorType));
            services.AddAutoMapper(map => { map.AddProfile<FreshMeatServerMappings>(); });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<LobbyHub>("/lobbyHub");
                routes.MapHub<MatchHub>("/matchHub");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
