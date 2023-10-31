using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBootcamp.Server.Service
{
	public interface IFileUpload
	{
		Task<string> UploadFile(IBrowserFile file);
		bool DeleteFile(string filePath);

	}
}
