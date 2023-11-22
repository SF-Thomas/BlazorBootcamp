using BlazorBootcamp.Models;

namespace BlazorBootcamp.Client.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAll(string? userId);
        Task<OrderDTO> Get(int orderId);

        Task<OrderDTO> Create(StripePaymentDTO paymentDTO);
        
        Task<OrderHeaderDTO> MarkPaymentSuccessful(OrderHeaderDTO orderHeader);
    }
}