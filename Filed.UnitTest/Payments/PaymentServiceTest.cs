using Moq;
using System;
using Xunit;
using AutoMapper;
using Autofac.Extras.Moq;
using System.Threading.Tasks;
using Filed.PaymentProcessor.Core.Data;
using Filed.PaymentProcessor.Core.PaymentGateway;
using Filed.PaymentProcessor.Core.Payments;
using Filed.PaymentProcessor.DomainServices.Payments;
using Filed.PaymentProcessor.Infrastructure.ExternalServices;
using Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGatewayFactory;
using Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGateways;


namespace Filed.UnitTest.Payments
{
    public class PaymentServiceTest
    {
        [Fact]
        public async Task Payment_Gateway_Should_Call_Process_payment_Once_If_Cheap_Payment_Gateway_Is_Used()
        {
            var request = GetPaymentRequest();

            var payment = ToPaymentModel(request);

            using var mock = AutoMock.GetLoose();

            var gateway = mock.Mock<ICheapPaymentGateway>();

            mock.Mock<IPaymentGatewayResponse>().Setup(x => x.GetResponse())
                .Returns(PaymentStatus.Unavailable);


            mock.Mock<IPaymentGatewayFactory>().Setup(x => x.CreatePaymentGatewayService(It.IsAny<decimal>()))
                .Returns(gateway.Object);

            mock.Mock<IMapper>().Setup(x => x.Map<Payment>(It.IsAny<PaymentRequest>()))
                .Returns(payment);


            var service = mock.Create<PaymentService>();

            await service.ProcessPayment(request);

            gateway.Verify(x => x.ProcessPayment(request), Times.Once);

            mock.Mock<IPaymentRepository>().Verify(x => x.SavePaymentAsync(payment), Times.Once);


        }



        private PaymentRequest GetPaymentRequest()
        {
            return new PaymentRequest
            {
                CardHolder = "Adelaje Shittu",
                CreditCardNumber = "5399237052078256",
                ExpirationDate
                = DateTime.Now.AddYears(4),
                SecurityCode = "048",
                Amount = 20
            };
        }

        private Payment ToPaymentModel(PaymentRequest request)
        {
            return new Payment
            {
                CardHolder = request.CardHolder,
                CreditCardNumber = request.CreditCardNumber,
                SecurityCode = request.SecurityCode,
                ExpirationDate = request.ExpirationDate,
                Amount = request.Amount
            };
        }

    }
}
