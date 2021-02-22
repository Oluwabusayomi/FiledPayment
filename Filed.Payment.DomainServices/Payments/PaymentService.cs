using System;
using AutoMapper;
using System.Threading.Tasks;
using Filed.PaymentProcessor.Core.Data;
using Filed.PaymentProcessor.Core.PaymentGateway;
using Filed.PaymentProcessor.Core.Payments;
using Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGatewayFactory;

namespace Filed.PaymentProcessor.DomainServices.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentGatewayFactory _paymentGatewayFactory;

        private readonly IMapper _mapper;


        public PaymentService(IPaymentRepository paymentRepository,
            IMapper mapper, IPaymentGatewayFactory paymentGatewayFactory)
        {
            _paymentRepository = paymentRepository;
            _paymentGatewayFactory = paymentGatewayFactory;
            _mapper = mapper;
        }
        public async Task ProcessPayment(PaymentRequest request)
        {
            var gateway = _paymentGatewayFactory.CreatePaymentGatewayService(request.Amount);

            var response = await gateway.ProcessPayment(request);

            var model = _mapper.Map<Payment>(request);

            model.Id = Guid.NewGuid();

            model.CreatedDate = DateTime.Now;

            model.PaymentState = GetPaymentState(response);

           await _paymentRepository.SavePaymentAsync(model);
        }

        private static PaymentState GetPaymentState(PaymentStatus response)
        {
            return new PaymentState
            {
                Id = Guid.NewGuid(),
                State =
                response == PaymentStatus.Unavailable ? State.Failed.ToString() 
                : ((State)response).ToString(),
                CreatedDate = DateTime.Now
            };
        }

    }
}
