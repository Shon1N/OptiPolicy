using Microsoft.AspNetCore.Components;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services.Interfaces;

namespace OptiPolicy.Ui.Pages.Admin.User
{
    public partial class User : ComponentBase
    {
        [Inject] private IUserService userService { get; set; }
        [Inject] private IStateService stateService { get; set; }
        [Inject] private IUserGroupService userGroupService { get; set; }
        
        protected IEnumerable<UserDto> Users { get; set; } = Enumerable.Empty<UserDto>();
        protected bool IsCreateWindowVisible { get; set; }
        protected bool IsEditWindowVisible { get; set; }
        private int SelectedUserId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetUsers();
            await InvokeAsync(StateHasChanged);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task GetUsers()
        {
            var envelope = await userService.GetAllAsync();
            if(envelope.Result == nameof(StatusDescriptionEnum.Passed))
            {
                Users = envelope.Response;
            }
        }

        protected async Task DeleteUser(UserDto user)
        {
            user.DeletionUserId = stateService.User.UserId;
            await userService.DeleteAsync(user);

            foreach(var userGroup in user.UserGroups)
            {
                userGroup.DeletionUserId = user.DeletionUserId;
                await userGroupService.DeleteAsync(userGroup);
            }

            await GetUsers();
            await InvokeAsync(StateHasChanged);
        }

        protected void OpenCreateWindow()
        {
            IsCreateWindowVisible = true;
            IsEditWindowVisible = false;
        }
        protected async void OpenEditWindow(int id)
        {
            SelectedUserId = id;
            IsEditWindowVisible = true;
            IsCreateWindowVisible = false;
            await InvokeAsync(StateHasChanged);
        }

        public async void OnCreateWindowVisibilityChanged(bool isWindowVisible)
        {
            IsCreateWindowVisible = false;
        }

        public async void OnEditWindowVisibilityChanged(bool isWindowVisible)
        {
            IsEditWindowVisible = false;
        }

        public async Task OnSuccessfulCompletion(bool completedSuccessfully)
        {
            if (completedSuccessfully)
            {
                await GetUsers();
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}