using Acme.BookStore.Books;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public BookStoreDataSeederContributor(
            IRepository<Book, Guid> bookRepository,
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant)
        {
            _bookRepository = bookRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            //using (_currentTenant.Change(context?.TenantId))
            //{
                if (await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "1984",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f
                    },
                    autoSave: true
                );

                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "The Hitchhiker's Guide to the Galaxy",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f
                    },
                    autoSave: true
                );
            }
        }
    }
}
