using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; } = string.Empty;

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        // Navigation property for many-to-many relationship with Author
        public ICollection<Author> Authors { get; set; }

        public Book(string name, DateTime publishDate, BookType type, IEnumerable<Author> authors)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Book name is required.", nameof(name));
            Name = name;
            PublishDate = publishDate;
            Type = type;
            Authors = authors?.ToList() ?? throw new ArgumentNullException(nameof(authors));
            if (!Authors.Any())
                throw new ArgumentException("A book must have at least one author.", nameof(authors));
        }

        public void AddAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));
            if (Authors.Any(a => a.Id == author.Id))
                throw new InvalidOperationException("This author is already added to the book.");
            Authors.Add(author);
        }

        protected Book()
        {
            Authors = new List<Author>();
        }
    }
}
