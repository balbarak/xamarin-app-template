using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinAppTemplate.Resx;
using XamarinAppTemplate.Validations;

namespace XamarinAppTemplate.ViewModels
{
    public class FormViewModel : BaseViewModel
    {
        private ValidatableEntry _email = new ValidatableEntry();
        private ValidatableEntry _password = new ValidatableEntry();

        public ValidatableEntry Password { get => _password; set => SetProperty(ref _password, value); }
        public ValidatableEntry Email { get => _email; set => SetProperty(ref _email, value); }

        public ICommand SubmitCommand => new Command(async () => await Submit());

        private bool _isChecked = true;

        public bool IsChecked { get => _isChecked; set => SetProperty(ref _isChecked, value); }
        


        public FormViewModel()
        {
            Title = AppResource.Demo_Forms;

            AddValidations();
        }


        private Task Submit()
        {
            var isValidEmail = Email.Validate();
            var isValidPassword = Password.Validate();

            var email = Email.Value;
            var pass = Password.Value;

            return Task.CompletedTask;
        }

        private void AddValidations()
        {
            _email.Validations.Add(new IsNotNullOrEmptyTextRule
            {
                ValidationMessage = string.Format(AppResource.Validation_Required, AppResource.Email)
            });

            _email.Validations.Add(new EmailRule
            {
                ValidationMessage = AppResource.Validation_Email
            });

            _password.Validations.Add(new IsNotNullOrEmptyTextRule
            {
                ValidationMessage = string.Format(AppResource.Validation_Required, AppResource.Password)
            });

        }
    }
}
