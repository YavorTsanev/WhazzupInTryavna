namespace WhazzupInTryavna.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        IEnumerable<T> GetAll<T>(string roleId);

        Task BanAsync(string userId);

        Task UnBanAsync(string userId);
    }
}
