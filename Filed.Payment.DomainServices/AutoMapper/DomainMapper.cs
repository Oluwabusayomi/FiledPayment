using AutoMapper;
using Filed.PaymentProcessor.Core.Payments;

namespace Filed.PaymentProcessor.DomainServices.AutoMapper
{
    public class DomainMapper : Profile
    {
        public DomainMapper()
        {
            CreateMap<PaymentRequest, Payment>().ReverseMap();
        }
    }
}
