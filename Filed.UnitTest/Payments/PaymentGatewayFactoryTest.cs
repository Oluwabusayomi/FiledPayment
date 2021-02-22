using System;
using Xunit;
using Autofac.Extras.Moq;
using Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGatewayFactory;
using Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGateways;



namespace Filed.UnitTest.Payments
{
    public class PaymentGatewayFactoryTest
    {
        [Fact]
        public void Is_Cheap_Payment_Gateway_Should_Be_True_If_Amount_Is_Btw_1_And_20_Pounds()
        {
            var amount = GenerateRandomAmount(1, 21);

            using (var mock = AutoMock.GetLoose())
            {
                var factory = mock.Create<PaymentGatewayFactory>();

                var gatewayType = factory.CreatePaymentGatewayService(amount);
                
                Assert.True(gatewayType is ICheapPaymentGateway);
            }

        }

        [Fact]
        public void Is_Cheap_Payment_Gateway_Should_Be_False_If_Amount_Is_Greater_Than_20_Pounds()
        {
            var amount = GenerateRandomAmount(21, int.MaxValue);

            using (var mock = AutoMock.GetLoose())
            {
                var factory = mock.Create<PaymentGatewayFactory>();

                var gatewayType = factory.CreatePaymentGatewayService(amount);
                
                Assert.False(gatewayType is ICheapPaymentGateway);
            }

        }

        [Fact]
        public void Is_Expensive_Payment_Gateway_Should_Be_true_If_Amount_Is_Btw_21_And_500_Pounds()
        {
            var amount = GenerateRandomAmount(21, 501);

            using (var mock = AutoMock.GetLoose())
            {
                var factory = mock.Create<PaymentGatewayFactory>();

                var gatewayType = factory.CreatePaymentGatewayService(amount);

                Assert.True(gatewayType is IExpensivePaymentGateway);
            }

        }

        [Fact]
        public void Is_Expensive_Payment_Gateway_Should_Be_False_If_Amount_Is_Greater_Than_500_Pounds()
        {
            var amount = GenerateRandomAmount(501, int.MaxValue);

            using (var mock = AutoMock.GetLoose())
            {
                var factory = mock.Create<PaymentGatewayFactory>();

                var gatewayType = factory.CreatePaymentGatewayService(amount);

                Assert.False(gatewayType is IExpensivePaymentGateway);
            }

        }

        [Fact]
        public void Payment_Gateway_Type_Is_Premium_Should_Be_False_If_Amount_Is_Less_Than_501_Pounds()
        {
            var amount = GenerateRandomAmount(1, 501);

            using (var mock = AutoMock.GetLoose())
            {
                var factory = mock.Create<PaymentGatewayFactory>();

                var gatewayType = factory.CreatePaymentGatewayService(amount);

                Assert.False(gatewayType is IPremiumPaymentGateway);
            }

        }

        [Fact]
        public void Payment_Gateway_Type_Is_Premium_Should_Be_True_If_Amount_Is_Greater_Than_500_Pounds()
        {
            var amount = GenerateRandomAmount(501, int.MaxValue);

            using (var mock = AutoMock.GetLoose())
            {
                var factory = mock.Create<PaymentGatewayFactory>();

                var gatewayType = factory.CreatePaymentGatewayService(amount);

                Assert.True(gatewayType is IPremiumPaymentGateway);
            }

        }


        private decimal GenerateRandomAmount(int min, int max)
        {
            var _random = new Random();

            return _random.Next(min, max);
        }

    }
}
