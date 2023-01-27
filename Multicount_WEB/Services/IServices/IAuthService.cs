using Microsoft.AspNetCore.Mvc;
using Multicount_WEB.Models.Dto;

namespace Multicount_WEB.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO objToCreate);
        Task<T> RegisterAsync<T>(RegistrationRequestDTO objToCreate);
    }
}
