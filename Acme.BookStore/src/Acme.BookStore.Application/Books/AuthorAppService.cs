using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Books
{
    public class AuthorAppService :
        CrudAppService<
            Author, // The Author entity
            AuthorDto, // Used to show authors
            Guid, // Primary key of the author entity
            PagedAndSortedResultRequestDto, // Used for paging/sorting
            CreateUpdateAuthorDto>, // Used to create/update an author
        IAuthorAppService // Implement the IAuthorAppService
    {
        public AuthorAppService(IRepository<Author, Guid> repository)
            : base(repository)
        {
        }
    }
}
