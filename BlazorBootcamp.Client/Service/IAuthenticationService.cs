using BlazorBootcamp.Client.Service;
using BlazorBootcamp.Common;
using BlazorBootcamp.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BlazorBootcamp.Client.Service
{
	public interface IAuthenticationService
	{
		Task<SignUpResponseDTO> RegisterUser(SignUpRequestDTO signUpRequestDTO);
		Task<SignInResponseDTO> Login(SignInRequestDTO signInRequestDTO);
		Task Logout();
	}
}