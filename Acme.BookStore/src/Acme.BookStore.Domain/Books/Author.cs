using System;
using System.Collections.Generic;
using System.Linq;

using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books
{
    public class Author : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get;  set; }
        public string ShortBio { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; }

        protected Author()
        {
            Books = new List<Book>();
        }

        public Author(string name, DateTime birthDate, string shortBio, IEnumerable<Book> books)
        {
            Name = name;
            BirthDate = birthDate;
            ShortBio = shortBio;

            if (books.Any())
            {
                Books = [.. books];
            }
            else
            {
                Books = new List<Book>();
            }
            
        }

        public Author(string name, DateTime birthDate, string shortBio)
        {
            Name = name;
            BirthDate = birthDate;
            ShortBio = shortBio;

            Books = new List<Book>();
        }
    }
}
