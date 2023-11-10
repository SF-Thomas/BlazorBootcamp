using BlazorBootcamp.Models;

namespace BlazorBootcamp.Business.Repository
{
    public interface IOrderRepository
    {
        Task<OrderDTO> Get(int id);
        Task<IEnumerable<OrderDTO>> GetAll(string? userId = null, string? status = null);
        Task<OrderDTO> Create(OrderDTO objDTO);
        Task<int> Delete(int id);

        Task<OrderHeaderDTO> UpdateHeader(OrderHeaderDTO objDTO);

        Task<OrderHeaderDTO> MarkPaymentSuccessful(int id);
        Task<bool> UpdateOrderStatus(int orderId, string status);

        Task<OrderHeaderDTO> CancelOrder(int id);
    }
}