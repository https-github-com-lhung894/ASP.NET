using Application.Interfaces;
using Application.Services;
using Domain.IActions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Actions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddRazorPages();

            services.AddDbContext<MyData>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("QLNS")));

            services.AddScoped<IAccountAc, AccountAc>();
            services.AddScoped<IPhongBanAc, PhongBanAc>();
            services.AddScoped<ICongViecAc, CongViecAc>();
            services.AddScoped<ITrangThaiChamCongAc, TrangThaiChamCongAc>();
            services.AddScoped<IDuAnAc, DuAnAc>();
            services.AddScoped<IChucVuAc, ChucVuAc>();
            services.AddScoped<IPhuCapAc, PhuCapAc>();
            services.AddScoped<INhanVienAc, NhanVienAc>();
            services.AddScoped<INhanVienCongViecAc, NhanVienCongViecAc>();
            services.AddScoped<IHopDongAc, HopDongAc>();
            services.AddScoped<IChiTietNhanVienAc, ChiTietNhanVienAc>();
            services.AddScoped<INhanVienDuAnAc, NhanVienDuAnAc>();
            services.AddScoped<IBangChamCongAc, BangChamCongAc>();
            services.AddScoped<INhanVienPhuCapAc, NhanVienPhuCapAc>();
            services.AddScoped<ILuongThangAc, LuongThangAc>();
            services.AddScoped<IThongTinDuLieuCuoiAc, ThongTinDuLieuCuoiAc>();
            services.AddScoped<IThuongLeAc, ThuongLeAc>();

            services.AddScoped<ILoginSv, LoginSv>();
            services.AddScoped<IAccountSv, AccountSv>();
            services.AddScoped<IPhongBanSv, PhongBanSv>();
            services.AddScoped<ICongViecSv, CongViecSv>();
            services.AddScoped<ITrangThaiChamCongSv, TrangThaiChamCongSv>();
            services.AddScoped<IDuAnSv, DuAnSv>();
            services.AddScoped<IChucVuSv, ChucVuSv>();
            services.AddScoped<IPhuCapSv, PhuCapSv>();
            services.AddScoped<INhanVienSv, NhanVienSv>();
            services.AddScoped<INhanVienCongViecSv, NhanVienCongViecSv>();
            services.AddScoped<IHopDongSv, HopDongSv>();
            services.AddScoped<IChiTietNhanVienSv, ChiTietNhanVienSv>();
            services.AddScoped<INhanVienDuAnSv, NhanVienDuAnSv>();
            services.AddScoped<IBangChamCongSv, BangChamCongSv>();
            services.AddScoped<INhanVienPhuCapSv, NhanVienPhuCapSv>();
            services.AddScoped<ILuongThangSv, LuongThangSv>();
            services.AddScoped<IThuongLeSv, ThuongLeSv>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: default,
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );
            });
        }
    }
}
