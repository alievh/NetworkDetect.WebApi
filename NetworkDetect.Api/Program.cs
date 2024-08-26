using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetworkDetect.Core.Entities;
using NetworkDetect.Data.DAL;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
			 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowOrigins",
		builder => builder.WithOrigins("http://localhost:3000").WithMethods("PUT", "DELETE", "GET"));
});

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
	option.TokenValidationParameters = new TokenValidationParameters
	{
		ValidAudience = builder.Configuration.GetSection("Jwt:audience").Value,
		ValidIssuer = builder.Configuration.GetSection("Jwt:issuer").Value,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:securityKey").Value)),
	};
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>()
	.AddEntityFrameworkStores<AppDbContext>()
	.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Lockout.MaxFailedAccessAttempts = 5;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

	options.Password.RequiredLength = 8;
	options.Password.RequireDigit = true;
	options.Password.RequireUppercase = true;
	options.Password.RequireLowercase = true;

	options.User.RequireUniqueEmail = true;
	options.SignIn.RequireConfirmedEmail = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
