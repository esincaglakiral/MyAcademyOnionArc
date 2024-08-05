using Microsoft.EntityFrameworkCore;
using Product.Application.Features.CQRS.Handlers.CategoryHandlers;
using Product.Application.Features.Mediator.Handlers.CustomerHandlers;
using Product.Application.Interfaces;
using Product.Persistance.Context;
using Product.Persistance.Repositories;
using Product.WebUI.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cfg => //MediatR
{
    cfg.RegisterServicesFromAssemblyContaining<GetCustomerQueryHandler>(); // mediatR da ba�ka katmanda oldu�u i�in assembly ile okuyam�yor o nedenle webUI katman�nda de�ilse e�er b�yle yaparak Handlerlar� g�rmesini sa�l�yoruz.
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Automapper



builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();



builder.Services.AddServiceHandlers();  // extension metodumuz arac�l��� ile t�m handlerlar�m�z� dahil etmi� olduk art�k controllerda handlerlar� kullanabilicez.
//AddMediaR, AddAutoMapper gibi metotlar da asl�nda extension metotlard�r.


builder.Services.AddDbContext<OnionContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseSqlServer(connectionString);
});


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
