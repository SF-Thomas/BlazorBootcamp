using BlazorBootcamp.Models;

namespace BlazorBootcamp.Client.Service
{
    public interface IPaymentService
    {
        public Task<SuccessModelDTO> Checkout(StripePaymentDTO model);
    }
}
