using Microsoft.AspNetCore.Components;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services.Interfaces;

namespace OptiPolicy.Ui.Pages.Shared.Login
{
    public partial class Login : ComponentBase
    {
        [Inject] private IAuthService authService { get; set; }
        [Inject] private IStateService stateService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected LoginDto LoginDto { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();   
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        protected async Task OnLogin()
        {
            var envelope = await authService.LoginAsync(LoginDto);

            if(envelope.Result == nameof(StatusDescriptionEnum.Passed))
            {
                stateService.IsLoggedIn = true;
                stateService.User = envelope.Response;
                NavigationManager.NavigateTo("/Home");
            }

            await InvokeAsync(StateHasChanged);
        }
    }
}
