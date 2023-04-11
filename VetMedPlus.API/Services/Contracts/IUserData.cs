using VetMedPlus.API.Models;

namespace VetMedPlus.API.Services.Contracts
{
    public interface IUserData
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task AddUser(User user);
        Task AddUserAddress(UserClientModel userClientModel);
        Task DeleteUser(int id);
        Task UpdateUser(User user);

    }
}
