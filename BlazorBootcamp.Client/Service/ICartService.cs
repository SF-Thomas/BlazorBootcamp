using BlazorBootcamp.Client.ViewModels;

namespace BlazorBootcamp.Client.Service
{
	public interface ICartService
	{
		public event Action OnChange;
		Task DecrementCart(ShoppingCart shoppingCart);
		Task IncrementCart(ShoppingCart shoppingCart);
	}
}
