using Thoughtful.Api.Features.AuthorFeature;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.Author
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile ()
        {
            CreateMap<AuthorDto, Author> ();
        }
    }
}
