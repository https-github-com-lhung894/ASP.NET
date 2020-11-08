using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Areas.Admin.Data
{
    public class SeedData
    {
        public static void Initialize(MyData context)
        {
            context.Database.EnsureCreated();
            if (context.NhanViens.Any()) return;

            

            context.SaveChanges();
        }
    }
}
