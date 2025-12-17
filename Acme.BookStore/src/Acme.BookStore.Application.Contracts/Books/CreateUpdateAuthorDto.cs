using System;

namespace Acme.BookStore.Books
{
    public class CreateUpdateAuthorDto
    {
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public required string ShortBio { get; set; }
    }
}
