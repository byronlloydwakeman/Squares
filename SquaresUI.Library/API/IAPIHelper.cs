using SquaresUI.Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SquaresUI.Library.API
{
    public interface IAPIHelper
    {
        HttpClient _apiClient { get; set; }
        IAuthenticatedUser _authenticatedUser { get; set; }
        Task Login(string username, string password);
        Task Register(string email, string password, string confirmPassword);
    }
}