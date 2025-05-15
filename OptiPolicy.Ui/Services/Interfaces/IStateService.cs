using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Ui.Services.Interfaces
{
    public interface IStateService
    {
        public AuthDto User { get; set; }
        public bool IsLoggedIn { get; set; }
        public event Action OnIsLoggedInChange;
    }
}