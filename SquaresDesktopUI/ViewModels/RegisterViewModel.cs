using Caliburn.Micro;
using SquaresUI.Library.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresDesktopUI.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private IAPIHelper _apiHelper;
        public RegisterViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set 
            {
                _email = value;
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set 
            { 
                _confirmPassword = value;
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        public bool CanRegister
        {
            get
            {
                if((Email?.Length > 0) && (Password?.Length > 0) && (ConfirmPassword?.Length > 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task Register()
        {
            try
            {
                await _apiHelper.Register(Email, Password, ConfirmPassword);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
    }
}
