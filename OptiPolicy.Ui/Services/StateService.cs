using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Ui.Services.Interfaces;

namespace OptiPolicy.Ui.Services
{
    public class StateService : IStateService
    {
        public AuthDto User { get; set; }

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                if (_isLoggedIn != value)
                {
                    _isLoggedIn = value;
                    NotifyIsLoggedInStateChanged();
                }
            }
        }

        public event Action OnIsLoggedInChange;

        private void NotifyIsLoggedInStateChanged() => OnIsLoggedInChange?.Invoke();
    }
}