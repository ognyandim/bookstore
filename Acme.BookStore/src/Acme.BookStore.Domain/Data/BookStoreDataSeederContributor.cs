using Acme.BookStore.Books;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

using Volo.Abp.MultiTenancy;

namespace Acme.BookStore.Data
{
    internal class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;
        private readonly IRepository<Author, Guid> _authorRepository;

        public BookStoreDataSeederContributor(
            IRepository<Book, Guid> bookRepository,
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant,
            IRepository<Author, Guid> authorRepository)
        {
            _bookRepository = bookRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
            _authorRepository = authorRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var orwell = new Author("George Orwell", new DateTime(1903, 6, 25), "Bio");
            var douglasAdams = new Author("Douglas Adams", new DateTime(1952, 3, 11), "Bio");

            if (await _authorRepository.GetCountAsync() <= 0)
            {

                await _authorRepository.InsertAsync(orwell);
                await _authorRepository.InsertAsync(douglasAdams);
            }

            //using (_currentTenant.Change(context?.TenantId))
            //{
            if (await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(
                    new Book("1984", new DateTime(1949, 6, 8), BookType.Dystopia, new[] { orwell })
                    {
                        Price = 19.84f,
                    },
                    autoSave: true
                );

                await _bookRepository.InsertAsync(
                    new Book("The Hitchhiker's Guide to the Galaxy", new DateTime(1995, 9, 27), BookType.ScienceFiction, new[] { douglasAdams })
                    {
                        Price = 42.0f
                    },
                    autoSave: true
                );
            }
        }
    }
}
