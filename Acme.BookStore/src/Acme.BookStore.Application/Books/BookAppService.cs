using System;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Books;

public class BookAppService :
    CrudAppService<
        Book, //The Book entity
        BookDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto>, //Used to create/update a book
    IBookAppService //implement the IBookAppService
{
    public BookAppService(IRepository<Book, Guid> repository)
        : base(repository)
    {

    }
    // in order to GET 
    // acme.bookStore.books.book.getList({}).done(function (result) { console.log(result); });

    /* in order to CREATE
        acme.bookStore.books.book.create({
            name: 'Foundation',
            type: 7,
            publishDate: '1951-05-24',
            price: 21.5
        }).then(function (result) {
            console.log('successfully created the book with id: ' + result.id);
        });
    */

    /* In order to DELETE 
     * acme.bookStore.books.book.
     * */
}
