﻿using Microsoft.Extensions.Logging;
using System.IO; // For Path.Combine
using System; // For Environment
using Microsoft.Extensions.DependencyInjection;
using GymManagement.Data; // Updated namespace to use the new MemberService

namespace MauiApp29
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Set path to the SQLite database (it will be created if it does not exist)
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GymMembers.db");

            // Register MemberService and the SQLite database
            builder.Services.AddSingleton<MemberService>(
                s => ActivatorUtilities.CreateInstance<MemberService>(s, dbPath));

            return builder.Build();
        }
    }
}
