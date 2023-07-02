using Microsoft.EntityFrameworkCore;
using MyQuestAPI.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure the database connection
var connectionString = builder.Configuration.GetConnectionString("MyQuestDb");

builder.Services.AddDbContext<MyQuestContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyQuest", builder =>
    {
        //builder.WithOrigins("http://localhost:4200")
        builder.WithOrigins("https://myquest-khaki.vercel.app/")
                //.AllowAnyHeader()
                //.AllowAnyMethod();
                .AllowAnyHeader()
                .WithMethods("GET", "POST", "PUT", "DELETE")
                .WithExposedHeaders("*");
    });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MyQuest", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyQuest v1"));
}

app.UseHttpsRedirection();

app.UseCors("MyQuest");

app.UseAuthorization();

app.MapControllers();

app.Run();