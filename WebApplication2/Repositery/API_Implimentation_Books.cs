using AutoMapper;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Repositery
{
    public static class API_Implimentation_Books
    {
        public static void Books(this IEndpointRouteBuilder app)
        {

            app.MapGet("/Books", async (HttpContext httpContext) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<BookRepository>();
                var books = await repository.GetAllBooksAsync();
                return Results.Ok(books);
            });

            app.MapGet("/Books/{id}", async (HttpContext httpContext, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<BookRepository>();
                var book = await repository.GetBookByIdAsync(id);
                return book is not null ? Results.Ok(book) : Results.NotFound("Book Not Found");
            });
            app.MapPost("Add/Book", async (HttpContext httpContext, BookDTO inputDTO) =>
            {
                var mapper = httpContext.RequestServices.GetRequiredService<IMapper>();
                var repository = httpContext.RequestServices.GetRequiredService<IBookRepositery>();

                var book = mapper.Map<Books>(inputDTO);

                await repository.AddBookAsync(book);

                var outputDTO = mapper.Map<BookDTO>(book);
                return Results.Ok(outputDTO);
            });

            app.MapPut("/Book/{id}", async (HttpContext httpContext, BookDTO inputDTO, int id) =>
            {
                var mapper = httpContext.RequestServices.GetRequiredService<IMapper>();
                var repository = httpContext.RequestServices.GetRequiredService<IBookRepositery>();

                var existingBook = await repository.GetBookByIdAsync(id);
                if (existingBook == null)
                {
                    return Results.NotFound("Book not found");
                }

                mapper.Map(inputDTO, existingBook);

                await repository.UpdateBookAsync(id, existingBook);

                var outputDTO = mapper.Map<BookDTO>(existingBook);
                return Results.Ok(outputDTO);
            });



            app.MapDelete("/Book/{id}", async (HttpContext httpContext, int id) =>
            {
                var repository = httpContext.RequestServices.GetRequiredService<BookRepository>();
                await repository.DeleteBookAsync(id);
                return Results.Ok(await repository.GetAllBooksAsync());
            });
        }
    
    }
}
