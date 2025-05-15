using Microsoft.AspNetCore.Components;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services;
using OptiPolicy.Ui.Services.Interfaces;
using OptiPolicy.Ui.ViewModels;
using System.Collections.ObjectModel;

namespace OptiPolicy.Ui.Pages.Admin.User
{
    public partial class UserEdit : ComponentBase
    {
        [Parameter] public bool IsWindowVisible { get; set; }
        [Parameter] public EventCallback<bool> IsWindowVisibleChanged { get; set; }
        [Parameter] public int SelectedUserId { get; set; }
        [Parameter] public EventCallback<bool> CompletedSuccessfully { get; set; }

        [Inject] private IUserService userService { get; set; }
        [Inject] private IGroupService groupService { get; set; }
        [Inject] private IUserGroupService userGroupService { get; set; }
        [Inject] private IStateService stateService { get; set; }

        protected UserDto User { get; set; } = new();
        protected int TabIndex { get; set; }

        protected List<SelectedGroup> SelectedGroups = new();
        private IEnumerable<SelectedGroup> CurrentGroups = Enumerable.Empty<SelectedGroup>();
        private IEnumerable<SelectedGroup> NewGroups = Enumerable.Empty<SelectedGroup>();
        private IEnumerable<UserGroupDto> RemovedGroups = Enumerable.Empty<UserGroupDto>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetGroups();
            await GetUser();

            //await Task.WhenAll(new[] { t1, t2 });
            await InvokeAsync(StateHasChanged);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task GetGroups()
        {
            var envelope = await groupService.GetAllAsync();
            if (envelope.Result == nameof(StatusDescriptionEnum.Passed))
            {
                SelectedGroups = envelope.Response.Select(x => new SelectedGroup { GroupId = x.Id, Name = x.Name, IsSelected = false}).ToList();
            }
        }

        private async Task GetUser()
        {
            var envelope = await userService.GetByIdAsync(SelectedUserId);
            if(envelope.Result == nameof(StatusDescriptionEnum.Passed))
            {
                User = envelope.Response;
                CurrentGroups = User.UserGroups.Select(x => new SelectedGroup { GroupId = x.GroupId, IsSelected = true });
                foreach(var group in SelectedGroups)
                {
                    if(CurrentGroups.Any(x => x.GroupId == group.GroupId))
                    {
                        group.IsSelected = true;
                    }
                }
            }
        }

        protected async void CloseWindow()
        {
            IsWindowVisible = false;
            await IsWindowVisibleChanged.InvokeAsync(IsWindowVisible);
        }

        protected async Task OnEdit()
        {
            await EditUser();
        }

        private async Task EditUser()
        {
            if (SelectedGroups.Where(x => x.IsSelected).Count() == 0)
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
            var envelope = await userService.UpdateAsync(User);
            if (envelope.Result == nameof(StatusDescriptionEnum.Passed))
            {
                List<SelectedGroup> newGroups = new();
                foreach(var group in SelectedGroups)
                {
                    if(CurrentGroups.FirstOrDefault(x => group.IsSelected && x.GroupId == group.GroupId) == null)
                    {
                        newGroups.Add(group);
                    }
                }
                NewGroups = newGroups;

                List<UserGroupDto> removedGroups = new();
                foreach(var group in User.UserGroups)
                {
                    if(SelectedGroups.FirstOrDefault(x => !x.IsSelected && x.GroupId == group.GroupId) != null)
                    {                        
                        removedGroups.Add(group);
                    }
                }
                RemovedGroups = removedGroups;

                if (NewGroups?.Any()??false)
                {
                    await CreateUserGroups(envelope.Response);
                }
                if (RemovedGroups?.Any()??false)
                {
                    await DeleteUserGroups();
                }

                await CompletedSuccessfully.InvokeAsync(true);
                CloseWindow();
            }
        }

        private async Task CreateUserGroups(UserDto user)
        {
            foreach (var group in NewGroups.Where(x => x.IsSelected))
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

        private async Task DeleteUserGroups()
        {
            foreach (var group in RemovedGroups)
            {
                var userGroup = new UserGroupDto
                {
                    Id = group.Id,
                    DeletionUserId = stateService.User.UserId
                };
                await userGroupService.DeleteAsync(userGroup);
            }
        }

        protected async Task ChangeValueAsync()
        {
            await IsWindowVisibleChanged.InvokeAsync(IsWindowVisible);
        }
    }
}
