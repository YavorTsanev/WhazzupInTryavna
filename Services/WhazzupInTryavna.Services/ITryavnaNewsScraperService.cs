namespace WhazzupInTryavna.Services
{
    using System.Threading.Tasks;

    public interface ITryavnaNewsScraperService
    {
        Task ImportNewsAsync(int count = 10);
    }
}
