using Microsoft.AspNetCore.Components;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services.Interfaces;
using OptiPolicy.Ui.ViewModels;

namespace OptiPolicy.Ui.Pages.Admin.User
{
    public partial class UserCreate : ComponentBase
    {
        [Parameter] public bool IsWindowVisible { get; set; }
        [Parameter] public EventCallback<bool> IsWindowVisibleChanged { get; set; }
        [Parameter] public EventCallback<bool> CompletedSuccessfully { get; set; }

        [Inject] private IUserService userService { get; set; }
        [Inject] private IGroupService groupService { get; set; }
        [Inject] private IUserGroupService userGroupService { get; set; }
        [Inject] private IStateService stateService { get; set; }
        protected UserDto User { get; set; } = new();
        protected int TabIndex { get; set; }

        protected List<SelectedGroup> SelectedGroups = new();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetGroups();
            await InvokeAsync(StateHasChanged);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task GetGroups()
        {
            var envelope = await groupService.GetAllAsync();
            if(envelope.Result == nameof(StatusDescriptionEnum.Passed))
            {
                SelectedGroups = envelope.Response.Select(x => new SelectedGroup { GroupId = x.Id, Name = x.Name, IsSelected = false }).ToList();
            }
        }

        protected async void CloseWindow()
        {
            IsWindowVisible = false;
            await IsWindowVisibleChanged.InvokeAsync(IsWindowVisible);
        }

        protected async Task OnCreate()
        {
            await CreateUser();
        }

        private async Task CreateUser()
        {
            if(SelectedGroups.Where(x => x.IsSelected).Count() == 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(User.Username))
            {
                return;
            }
            if (string.IsNullOrEmpty(User.Password))
            {
                return;
            }
            if (string.IsNullOrEmpty(User.Firstname))
            {
                return;
            }
            if (string.IsNullOrEmpty(User.Lastname))
            {
                return;
            }

            User.CreationUserId = stateService.User.UserId;
            var envelope = await userService.CreateAsync(User);
            if(envelope.Result == nameof(StatusDescriptionEnum.Passed))
            {
                await CreateUserGroups(envelope.Response);
            }

            await CompletedSuccessfully.InvokeAsync(true);
            CloseWindow();
        }

        private async Task CreateUserGroups(UserDto user)
        {
            foreach(var group in SelectedGroups.Where(x =>x.IsSelected == true))
            {
                var userGroup = new UserGroupDto
                {
                    UserId = user.Id,
                    GroupId = group.GroupId,
                    CreationUserId = user.CreationUserId
                };
                await userGroupService.CreateAsync(userGroup);
            }
        }

        protected async Task ChangeValueAsync()
        {
            await IsWindowVisibleChanged.InvokeAsync(IsWindowVisible);
        }
    }
}
