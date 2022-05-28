using System.Threading.Tasks;
using LFC.BLL.Models;
using LFC.DAL.Models;

namespace LFC.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<User> LoginAsync(LoginDto model);
        Task RegisterAsync(RegisterDto model);

    }
}