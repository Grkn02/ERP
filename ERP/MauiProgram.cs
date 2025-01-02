using ERP.Services;
using ERP.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace ERP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // aşşağıya dependancy injection ve veritaabnı tanımlanamsı için servisleri DI Container a ekledik 
            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestingDb")); // veritabanı bağlantısı için servis eklenmesi test veritabanı eklendi
            builder.Services.AddScoped<IProductService, ProductService>(); // interface servis le implementi olan class servisi DI yapılarak ekleniyor
            builder.Services.AddScoped<IProductTransactionService, ProductTransactionService>(); // her http isteği için yeni nesne oluşturur scope ile.BU veritbanı işlemleri için gerekli
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddTransient<ViewModels.LoginViewModel>();
            builder.Services.AddTransient<Views.LoginPage>();
            builder.Services.AddTransient<ViewModels.StockViewModel>();
            builder.Services.AddTransient<Views.StockPage>();
            builder.Services.AddTransient<ViewModels.TransactionHistoryViewModel>();
            builder.Services.AddTransient<Views.TransactionHistoryPage>();
            builder.Services.AddTransient<ViewModels.StockEntryViewModel>();
            builder.Services.AddTransient<Views.StockEntryPage>();
            builder.Services.AddTransient<ViewModels.RegisterViewModel>();
            builder.Services.AddTransient<Views.RegisterPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var appDbContext = builder.Services.BuildServiceProvider().GetService<AppDbContext>();
            AppDbContext.Initialize(appDbContext); // Verileri eklemek için Initialize metodunu çağırabilirsiniz



            return builder.Build();
        }
    }
}
