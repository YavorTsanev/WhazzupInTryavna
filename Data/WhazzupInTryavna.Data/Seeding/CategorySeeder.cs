namespace WhazzupInTryavna.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Data.Models.Activities;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Basketball",
                Image = "https://awfulannouncing.com/wp-content/uploads/sites/94/2016/01/458391810.jpg",
            });
            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Biking",
                Image = "https://static01.nyt.com/images/2019/11/19/well/physed-bike/physed-bike-superJumbo.jpg",
            });
            await dbContext.Categories.AddAsync(new Category
            {
                Name = "BBQ",
                Image = "https://molekule.science/wp-content/uploads/2019/06/is-bbq-smoke-bad-1200x580.jpg",
            });
            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Sea",
                Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/Paracas_National_Reserve%2C_Ica%2C_Peru-3April2011.jpg/450px-Paracas_National_Reserve%2C_Ica%2C_Peru-3April2011.jpg",
            });
            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Trekking",
                Image = "https://content.thriveglobal.com/wp-content/uploads/2018/03/Top_10_Best_Trekking_Routes_in_the_World.jpg",
            });
            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Snowboarding",
                Image = "https://cdn.vox-cdn.com/thumbor/b84VL231kPAvbEnqhCZQ-PWi26E=/0x457:4032x2568/fit-in/1200x630/cdn.vox-cdn.com/uploads/chorus_asset/file/19780173/Snowboards_top_photo.jpg",
            });
            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Drinking",
                Image = "https://akm-img-a-in.tosshub.com/indiatoday/images/story/202103/Liquor-1_1200x768.jpeg",
            });
            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Other",
                Image = "https://pngimage.net/wp-content/uploads/2018/06/other-png-4.png",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
