using IshchenkoKMAPractice4.Tools;
using IshchenkoKMAPractice4.Tools.Managers;

namespace IshchenkoKMAPractice4.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel, ILoaderOwner
    {
        private bool _isControlEnabled = true;

        public bool IsControlEnabled
        {
            get => _isControlEnabled;
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
    }
}