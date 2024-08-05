using Product.Application.Features.CQRS.Handlers.CategoryHandlers;
using Product.Application.Features.CQRS.Handlers.ProductHandlers;

namespace Product.WebUI.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServiceHandlers(this IServiceCollection services) //extension metodumuz (program.cs te kod kalabalığından bizi kurtarır.
        {
            services.AddScoped<CreateCategoryCommandHandle>();  //Handlerları controllerda kullanabilmemiz için registration işlemi yapılır
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandle>();
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();



            services.AddScoped<GetProductQueryHandler>();
            services.AddScoped<GetProductByIdQueryHandler>();
            services.AddScoped<CreateProductCommandHandler>();
            services.AddScoped<UpdateProductCommandHandler>();
            services.AddScoped<RemoveProductCommandHandler>();
        }
    }
}
