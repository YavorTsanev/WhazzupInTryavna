namespace WhazzupInTryavna.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models;
    using WhazzupInTryavna.Services.Mapping;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(IDeletableEntityRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public IEnumerable<T> GetAll<T>(string roleId)
        {
            return this.userRepository.AllWithDeleted().Where(x => x.Roles.All(x => x.RoleId != roleId)).To<T>();
        }

        public async Task BanAsync(string userId)
        {
            var user = this.userRepository.AllWithDeleted().FirstOrDefault(x => x.Id == userId);

            user.IsDeleted = true;
            await this.userRepository.SaveChangesAsync();
            await this.userManager.UpdateSecurityStampAsync(user);
        }

        public async Task UnBanAsync(string userId)
        {
            var user = this.userRepository.AllWithDeleted().FirstOrDefault(x => x.Id == userId);

            user.IsDeleted = false;
            await this.userRepository.SaveChangesAsync();
        }
    }
}
