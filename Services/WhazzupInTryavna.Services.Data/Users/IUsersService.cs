using System.Threading.Tasks;

namespace WhazzupInTryavna.Services.Data.Users
{
    using System.Collections.Generic;

    public interface IUsersService
    {
        IEnumerable<T> GetAll<T>();

        Task BanAsync(string userId);

        Task UnBanAsync(string userId);
    }
}
