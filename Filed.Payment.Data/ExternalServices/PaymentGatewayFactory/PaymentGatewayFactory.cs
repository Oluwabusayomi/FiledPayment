using System;
using Filed.PaymentProcessor.Core.PaymentGateway;
using Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGateways;

namespace Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGatewayFactory
{
    public class PaymentGatewayFactory : IPaymentGatewayFactory
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway  _expensivePaymentGateway;
        private readonly IPremiumPaymentGateway _premiumPaymentGateway;

        public PaymentGatewayFactory(
            ICheapPaymentGateway cheapPaymentGateway, 
            IExpensivePaymentGateway expensivePaymentGateway,
            IPremiumPaymentGateway premiumPaymentGateway)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentGateway = premiumPaymentGateway;
        }

        public IPaymentGateway CreatePaymentGatewayService(decimal amount)
        {
            IPaymentGateway paymentGateway = null;

            switch (true)
            {
                case true when amount <= 20:
                    paymentGateway = _cheapPaymentGateway;
                    break;

                case true when amount > 20 && amount <= 500:
                    paymentGateway = _expensivePaymentGateway;
                    break;

                case true when amount > 500:
                    paymentGateway = _premiumPaymentGateway;
                    break;

                default:
                    throw new ApplicationException(string.Format("Unknown payment gateway service provider."));

            }
            return paymentGateway;
        }

    }
}
