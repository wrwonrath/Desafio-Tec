using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Plugins.DataStore.InMemory;
using System.Text;
using UseCases;
using UseCases.DataStorePluginInterfaces;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value);
builder.Services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(key, builder.Configuration));

builder.Services.AddScoped<ICardRepository, CardInMemoryRepository>().AddDbContext<CardContext>(opt => opt.UseInMemoryDatabase("teste"));

// Dependency Injection for Use Cases and Repositories
builder.Services.AddTransient<IViewCardsUseCase, ViewCardUseCase>();
builder.Services.AddTransient<IAddCardUseCase, AddCardUseCase>();
builder.Services.AddTransient<IEditCardUseCase, EditCardUseCase>();
builder.Services.AddTransient<IGetCardByIdUseCase, GetCardByIdUseCase>();
builder.Services.AddTransient<IDeleteCardUseCase, DeleteCardUseCase>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
