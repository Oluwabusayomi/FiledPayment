using Filed.PaymentProcessor.Core.Payments;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Filed.PaymentProcessor.Payment.UIApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment(PaymentRequest request)
        {
            await _paymentService.ProcessPayment(request);

            return StatusCode((int)HttpStatusCode.OK);
        }
    }
}
