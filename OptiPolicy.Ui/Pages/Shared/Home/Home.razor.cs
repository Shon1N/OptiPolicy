using Microsoft.AspNetCore.Components;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services.Interfaces;

namespace OptiPolicy.Ui.Pages.Shared.Home
{
    public partial class Home : ComponentBase
    {
        [Inject] IUserService userService { get; set; }

        protected int UsersCount { get; set; }
        protected int GroupAdminCount { get; set; }
        protected int GroupUserCount { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetCounts();
            await InvokeAsync(StateHasChanged);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task GetCounts()
        {
            var t1 = userService.GetUserCountAsync();
            var t2 = userService.GetUserCountByGroupId((int)GroupEnum.Admin);
            var t3 = userService.GetUserCountByGroupId((int)GroupEnum.User);

            await Task.WhenAll(new[] { t1, t2, t3 });

            UsersCount = t1.Result.Response;
            GroupAdminCount = t2.Result.Response;
            GroupUserCount = t3.Result.Response;
        }
    }
}