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
    cfg.RegisterServicesFromAssemblyContaining<GetCustomerQueryHandler>(); // mediatR da baþka katmanda olduðu için assembly ile okuyamýyor o nedenle webUI katmanýnda deðilse eðer böyle yaparak Handlerlarý görmesini saðlýyoruz.
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Automapper



builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();



builder.Services.AddServiceHandlers();  // extension metodumuz aracýlýðý ile tüm handlerlarýmýzý dahil etmiþ olduk artýk controllerda handlerlarý kullanabilicez.
//AddMediaR, AddAutoMapper gibi metotlar da aslýnda extension metotlardýr.


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
