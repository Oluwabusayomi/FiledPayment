using Filed.PaymentProcessor.Core.Payments;
using FluentValidation;
using System;

namespace Filed.PaymentProcessor.DomainServices.Validations
{
    public class PaymentRequestValidator : AbstractValidator<PaymentRequest>
    {
        public PaymentRequestValidator()
        {
            RuleFor(x => x.CardHolder).NotNull().NotEmpty();

            RuleFor(x => x.SecurityCode).MaximumLength(3);

            RuleFor(x => x.CreditCardNumber).NotNull()
                .NotEmpty().CreditCard();

            RuleFor(x => x.ExpirationDate).NotNull()
                .NotEmpty().GreaterThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.Amount).NotNull().NotEmpty()
                .GreaterThanOrEqualTo(0);
        }
    }
}
