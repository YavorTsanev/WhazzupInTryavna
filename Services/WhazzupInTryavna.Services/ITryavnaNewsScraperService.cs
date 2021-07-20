namespace WhazzupInTryavna.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Services.Models;

    public interface ITryavnaNewsScraperService
    {
        Task ImportNewsAsync(int count = 10);
    }
}
