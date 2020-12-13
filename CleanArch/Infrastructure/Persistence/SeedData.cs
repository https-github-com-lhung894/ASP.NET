using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class SeedData
    {
        public static void Initialize(MyData context)
        {
            context.Database.EnsureCreated();
            if (context.NhanViens.Any())
            {
                return;
            }

            

            context.SaveChanges();
        }
    }
}
