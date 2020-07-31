using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinAppTemplate.Services;

namespace XamarinAppTemplate.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isBusy = false;
        private string _title;
        private FlowDirection _flowDirection;
        private Localization _langugaeManager;
        private string _languageText;
        protected NavigationService _navService;

        public FlowDirection FlowDirection { get => _flowDirection; set => SetProperty(ref _flowDirection, value); }
        
        public string Title { get => _title; set => SetProperty(ref _title, value); }
        
        public bool IsBusy { get { return _isBusy; } set { SetProperty(ref _isBusy, value); OnPropertyChanged(nameof(IsNotBusy)); } }
        
        public bool IsNotBusy { get => !_isBusy; }

        public string LanguageText { get => _languageText; set => SetProperty(ref _languageText, value); }

        public bool IsInitialized { get; set; }

        public ICommand SwitchDirectionCommand => new Command(()=> SwitchDirection());

        public ICommand CloseModalCommand => new Command(async () => await _navService.CloseModal());

        public bool IsEnglish => Localization.IsEnglish;

        public BaseViewModel()
        {
            _navService = AppServiceLocator.Current.GetService<NavigationService>();
            _langugaeManager = AppServiceLocator.Current.GetService<Localization>();

            FlowDirection = Localization.CurrentFlowDirection;


            if (Localization.IsEnglish)
                LanguageText = "عربي";
            else
                LanguageText = "En";
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);

        public virtual Task OnAppearing() => Task.FromResult(false);

        public virtual Task OnDisappearing() => Task.FromResult(false);

        public void SwitchDirection()
        {
            if (Localization.IsEnglish)
                SwitchDirection(LanguageDirection.Rtl);
            else
                SwitchDirection(LanguageDirection.Ltr);
        }

        protected virtual void OnDirectionChanged(object sender,LanguageDirection dir)
        {
            
        }

        protected Task ShowSuccessModal()
        {
            return _navService.ShowModal<SuccessModalViewModel>();
        }

        protected Task ShowSuccessModal(string title)
        {
            return _navService.ShowModal<SuccessModalViewModel>(title);
        }

        protected Task ShowErrorModal(string error)
        {
            return _navService.ShowModal<ErrorModalViewModel>(error);
        }

        private void SwitchDirection(LanguageDirection dir)
        {
            var shellBinding = Shell.Current.BindingContext as BaseViewModel;

            _langugaeManager.ChangeDirection(dir);

            if (dir == LanguageDirection.Rtl)
            {
                FlowDirection = FlowDirection.RightToLeft;
                shellBinding.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                FlowDirection = FlowDirection.LeftToRight;
                shellBinding.FlowDirection = FlowDirection.LeftToRight;
            }

            shellBinding.OnDirectionChanged(this, dir);
        }

        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
