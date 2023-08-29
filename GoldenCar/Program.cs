using Domain.ViewModel;
using GoldenCar.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add Conntection String
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfraStructure(builder.Configuration);
builder.Services.AddTransient<IAuthentication<UsersModel>, Authentication>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Store",
        Version = "v1",
        Description = ".Net 6.0 API",
        Contact = new OpenApiContact()
        {
            Email = "ahmadsharawneh99@gmail.com",
            Name = "Store Solution",
            Url = new Uri("https://www.google.com/")
        }
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {

        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "zzzzzzzzzzzzzzzzzzzzzzzzzzzz",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {

                Reference=new OpenApiReference
                {

                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }

            },
            new string[] {}


        }
    });
});



builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] + "")),
        //ClockSkew = TimeSpan.Zero

    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
