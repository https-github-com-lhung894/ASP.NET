using Application.Interfaces;
using Application.Services;
using Domain.IActions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Actions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

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
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hft4GJ7YF3Gdseg7dejo4"))
                };
            });
            

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
            services.AddScoped<IQuanLyNhanVienSv, QuanLyNhanVienSv>();
            services.AddScoped<IQuanLyHopDongSv, QuanLyHopDongSv>();
            services.AddScoped<IQuanLyNhanVienDuAnSv, QuanLyNhanVienDuAnSv>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            //Add JWToken to all incoming HTTP Request Header
            app.Use(async (context, next) =>
            {
                var JWToken = context.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }
                await next();
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
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
