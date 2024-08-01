
//using Microsoft.EntityFrameworkCore;

//using School_Parent_App.Data;
 
//var builder = WebApplication.CreateBuilder(args);
 
//// Add services to the container.
 
//builder.Services.AddControllers();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ApplicationDbContext>(Options =>

//{

//    Options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolParentAppConnectionString"));

//});
 
 
 
 
//var app = builder.Build();
 
//// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())

//{

//    app.UseSwagger();

//    app.UseSwaggerUI();

//}
 
//app.UseHttpsRedirection();
 
//app.UseAuthorization();
 
//app.MapControllers();
 
//app.Run();
 
using Microsoft.EntityFrameworkCore;

using School_Parent_App.Data;

//using SchoolParentApp.Data;
 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>

{

    options.AddPolicy("AllowAll",

        builder => {

            builder.AllowAnyOrigin()

                    .AllowAnyHeader()

                    .AllowAnyMethod();

        });

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(Options =>

{

    Options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolParentAppConnectionString"));

});


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())

{

  

}

app.UseHttpsRedirection();

app.UseRouting();

// use CORS

app.UseCors("AllowAll");

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI();

//Redirect requests to the root URL to the swagger UI
app.Use(async (context, next) =>
{
    if (context.Request.Path =="/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }
    await next();
});

app.MapControllers();

app.Run();