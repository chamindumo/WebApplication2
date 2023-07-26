using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Repositery
{
    public static class API_Implementation_Product
    {
        public static void Product(this IEndpointRouteBuilder app)
        {
            app.MapGet("/product", async (HttpContext httpContext) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<ProductRepositery>();
                var books = await repository.GetAllProductsAsync();
                return Results.Ok(books);
            });


            app.MapGet("/product/{id}", async (HttpContext httpContext, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<ProductRepositery>();
                var product = await repository.GetProducByIdAsync(id);
                return product is not null ? Results.Ok(product) : Results.NotFound("product Not Found");
            });
            app.MapPost("Add/product", async (HttpContext httpContext, ProductDTO inputDTO) =>
            {
                var mapper = httpContext.RequestServices.GetRequiredService<IMapper>();
                var repository = httpContext.RequestServices.GetRequiredService<IProductService>();

               

                await repository.Create(inputDTO);

                return Results.Ok(inputDTO);
            });

            app.MapPut("/product/{id}", async (HttpContext httpContext, ProductDTO inputDTO, int id) =>
            {
                var mapper = httpContext.RequestServices.GetRequiredService<IMapper>();
                var repository1 = httpContext.RequestServices.GetRequiredService<IProductRepositery>();
                var repository2 = httpContext.RequestServices.GetRequiredService<IProductService>();

                var existingproduct = await repository1.GetProducByIdAsync(id);
                if (existingproduct == null)
                {
                    return Results.NotFound("product not found");
                }

                mapper.Map(inputDTO, existingproduct);

                await repository2.Update(id, inputDTO);

                return Results.Ok(inputDTO);
            });



            app.MapDelete("/product/{id}", async (HttpContext httpContext, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<ProductRepositery>();
                await repository.DeleteProductAsync(id);
                return Results.Ok(await repository.GetAllProductsAsync());
            });



        }
    }
}
