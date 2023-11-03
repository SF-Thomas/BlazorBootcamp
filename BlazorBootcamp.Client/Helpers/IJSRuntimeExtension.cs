using Microsoft.JSInterop;

namespace BlazorBootcamp.Client.Helpers
{
	public static class IJSRuntimeExtension
	{
		public static async ValueTask ToastrSuccessAsync(this IJSRuntime js, string message) 
		{
			await js.InvokeVoidAsync("ShowToastr", "success", message);
		}

		public static async ValueTask ToastrErrorAsync(this IJSRuntime js, string message)
		{
			await js.InvokeVoidAsync("ShowToastr", "error", message);
		}
	}
}