using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Models;
using WebApplication2.Repositery;
using WebApplication2.Service;

namespace WebApplication2.Endpoints_Routs_Api
{
    public static class API_Implementation_Product
    {
        public static void Product(this IEndpointRouteBuilder app)
        {
            app.MapGet("/product", async (HttpContext httpContext) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IProductRepositery>();
                var books = await repository.GetAllProductsAsync();
                return Results.Ok(books);
            });


            app.MapGet("/product/{id}", async (HttpContext httpContext, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IProductRepositery>();
                var product = await repository.GetProducByIdAsync(id);
                return product is not null ? Results.Ok(product) : Results.NotFound("product Not Found");
            });
            app.MapPost("Add/product", async (HttpContext httpContext, ProductDTO inputDTO) =>
            {
                var mapper = httpContext.RequestServices.GetRequiredService<IMapper>();
                var repository = httpContext.RequestServices.GetRequiredService<IProductRepositery>();
                var repository1 = httpContext.RequestServices.GetRequiredService<IProductService>();

                /*var product = mapper.Map<Product>(inputDTO);

                await repository.AddProductAsync(product);

                var outputDTO = mapper.Map<ProductDTO>(product);
                return Results.Ok(outputDTO);*/
                repository1.Create(inputDTO);

                return Results.Ok(inputDTO);

            });

            app.MapPut("/product/{id}", async (HttpContext httpContext, ProductDTO inputDTO, int id) =>
            {
                var mapper = httpContext.RequestServices.GetRequiredService<IMapper>();
                var repository = httpContext.RequestServices.GetRequiredService<IProductRepositery>();
                var repository1 = httpContext.RequestServices.GetRequiredService<IProductService>();

                var existingproduct = await repository.GetProducByIdAsync(id);
                if (existingproduct == null)
                {
                    return Results.NotFound("product not found");
                }

               /* mapper.Map(inputDTO, existingproduct);

                await repository.UpdateProductAsync(id, existingproduct);

                var outputDTO = mapper.Map<ProductDTO>(existingproduct);
                return Results.Ok(outputDTO);*/

                repository1.Update(id, inputDTO);

                return Results.Ok(inputDTO);    
            });




            app.MapDelete("/product/{id}", async (HttpContext httpContext, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<IProductRepositery>();
                await repository.DeleteProductAsync(id);
                return Results.Ok(await repository.GetAllProductsAsync());
            });



        }
    }
}
