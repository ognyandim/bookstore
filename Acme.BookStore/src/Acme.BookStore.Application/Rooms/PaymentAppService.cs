using System;
using System.Threading.Tasks;
using Marten;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Acme.Hotel.Rooms.Events;

namespace Acme.Hotel.Rooms
{
    public class PaymentAppService :
        CrudAppService<
            Payment, PaymentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePaymentDto>,
        IPaymentAppService
    {
        private readonly IDocumentSession _documentSession;

        public PaymentAppService(IRepository<Payment, Guid> repository, IDocumentSession documentSession)
            : base(repository)
        {
            _documentSession = documentSession;
        }

        public async Task<PaymentDto> PayAsync(CreateUpdatePaymentDto input)
        {
            var payment = new Payment
            {
                BookingId = input.BookingId,
                Amount = input.Amount,
                PaymentDate = DateTime.UtcNow,
                Status = PaymentStatus.Requested
            };
            await Repository.InsertAsync(payment);
            var @event = new PaymentRequestedEvent(payment.Id, payment.BookingId, payment.Amount);
            _documentSession.Events.StartStream(payment.Id, @event);
            await _documentSession.SaveChangesAsync();
            return ObjectMapper.Map<Payment, PaymentDto>(payment);
        }

        public async Task<PaymentDto> ProcessPaymentAsync(Guid paymentId, bool success)
        {
            var payment = await Repository.GetAsync(paymentId);
            payment.Status = success ? PaymentStatus.Succeeded : PaymentStatus.Failed;
            var @event = new PaymentProcessedEvent(payment.Id, payment.BookingId, success);
            _documentSession.Events.Append(payment.Id, @event);
            await _documentSession.SaveChangesAsync();
            return ObjectMapper.Map<Payment, PaymentDto>(payment);
        }
    }
}
