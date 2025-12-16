using System;

namespace Acme.BookStore.Books
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public required string ShortBio { get; set; }
    }
}
