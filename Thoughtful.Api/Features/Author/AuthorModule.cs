using Thoughtful.Dal;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class AuthorModule : IModule
    {
        public IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet("/api/authors", async (ThoughtfulDbContext ctx) =>
            {
                return await ctx.Authors.ToListAsync();
            });

            endpoints.MapPost("/api/authors", async (ThoughtfulDbContext ctx, AuthorDto authorDto) =>
            {
                var author = new Author();
                author.FirstName = authorDto.FirstName;
                author.LastName = authorDto.LastName;
                author.Bio = authorDto.Bio;
                author.DateBirth = authorDto.DateBirth;

                ctx.Authors.Add(author);
                await ctx.SaveChangesAsync();
                return author;
            });
            return endpoints;
        }

        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            return builder;
        }
    }
}
