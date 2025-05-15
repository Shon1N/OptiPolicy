using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using OptiPolicy.Ui.Authorization;
using OptiPolicy.Ui.Services;
using OptiPolicy.Ui.Services.Interfaces;

namespace OptiPolicy.Ui;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7182/") });
        builder.Services.AddSingleton<IStateService, StateService>();
        builder.Services.AddScoped<IRequestTokenService, RequestTokenService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IGroupService, GroupService>();
        builder.Services.AddScoped<IUserGroupService, UserGroupService>();
        builder.Services.AddScoped<IPermissionService, PermissionService>();
        builder.Services.AddScoped<IGroupPermissionService, GroupPermissionService>();
        //In order to authenticate to IS4:
        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("Local", options.ProviderOptions);
        });
        builder.Services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("LoggedIn", policy =>
                policy.AddRequirements(new LoggedInRequirement()));
        });
        builder.Services.AddSingleton<IAuthorizationHandler, LoggedInRequirementHandler>();
        builder.Services.AddMudServices();

        await builder.Build().RunAsync();
    }
}