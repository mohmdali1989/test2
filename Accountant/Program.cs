using Accountant.Data;
using Accountant.Models.MySharedService;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DataContextDB>(option => { option.UseSqlServer(builder.Configuration.GetConnectionString("Data_Base")); });
            builder.Services.AddSession();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<MySharedService>(); // هاي الطريق تسمى بعد الترجمه الخدمه المشتركة هو عباره عن اكلاس يمكن ان يراه كل التطبيق
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=ScreenLogin}/{id?}");

            app.Run();
        
    
 
