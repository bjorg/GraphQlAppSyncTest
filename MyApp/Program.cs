using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LambdaSharp.App;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

namespace GraphQL.Tests.MyApp {

    public class Program {

        //--- Class Fields ---
        public static string AppSyncUrl;
        public static string AppSyncApiKey;

        //--- Class Methods ---
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // read AppSync configuration
            AppSyncUrl = builder.Configuration["AppSyncUrl"];
            AppSyncApiKey = builder.Configuration["AppSyncApiKey"];

            // initialize LambdaSharp dependencies
            builder.AddLambdaSharp<Program>();

            // initialize Blazorise dependencies
            builder.Services
                .AddBlazorise()
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            // use Blazorise dependencies
            var host = builder.Build();
            host.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            // run application
            await host.RunAsync();
        }
    }
}
