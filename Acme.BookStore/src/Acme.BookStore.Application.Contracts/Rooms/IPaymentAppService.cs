using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Hotel.Rooms
{
    public interface IPaymentAppService : ICrudAppService<
        PaymentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdatePaymentDto>
    {
        // Command: Pay
        // Command: Process Payment
    }
}
