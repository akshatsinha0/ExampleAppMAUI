using ExampleAppMAUI.Services;
using ExampleAppMAUI.Todos;
using ExampleAppMAUI.Shared.Services;
using ExampleAppMAUI.Shared.Todos;
using Microsoft.Extensions.Logging;

namespace ExampleAppMAUI
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

            // Add device-specific services used by the ExampleAppMAUI.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            builder.Services.AddSingleton<ITodoStore>(_ =>
                JsonTodoStore.CreateForFile(Path.Combine(FileSystem.AppDataDirectory, TodoStorageNames.FileName)));

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
