using Thoughtful.Dal;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication ConfigureApplication(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();



            app.MapGet("/api/authors", async (ThoughtfulDbContext ctx) =>
            {
                return await ctx.Authors.ToListAsync();
            });

            app.MapPost("/api/authors", async (ThoughtfulDbContext ctx, AuthorDto authorDto) =>
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

            return app;
        }
        internal record AuthorDto(string FirstName, string LastName, string Bio, DateTime DateBirth);
    }
}
