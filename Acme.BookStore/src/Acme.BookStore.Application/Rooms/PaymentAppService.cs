using System;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.Hotel.Rooms
{
    public class PaymentAppService :
        CrudAppService<
            Payment, PaymentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePaymentDto>,
        IPaymentAppService
    {
        public PaymentAppService(IRepository<Payment, Guid> repository)
            : base(repository)
        {
        }
    }
}
