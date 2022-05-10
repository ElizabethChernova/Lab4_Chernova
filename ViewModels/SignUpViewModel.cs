using System;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Managers;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Models;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Navigation;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Services;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Tools;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.ViewModels
{
    class SignUpViewModel : INavigatable<AuthNavigationTypes>
    {
        #region Fields
        private RegistrationUser _registrationUser = new RegistrationUser();
        private RelayCommand<object> _gotoSignInCommand;
        private RelayCommand<object> _signUpCommand;
        private RelayCommand<object> _cancelCommand;
        private Action _gotoSignIn;

        public SignUpViewModel(Action gotoSignIn)
        {
            _gotoSignIn = gotoSignIn;
        }

        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _registrationUser.Name;
            }
            set
            {
                _registrationUser.Name = value;
            }
        }
        public string Login
        {
            get
            {
                return _registrationUser.Login;
            }
            set
            {
                _registrationUser.Login = value;
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return _registrationUser.DateOfBirth;
            }
            set
            {
                _registrationUser.DateOfBirth = value;
            }
        }
        public int Age
        {
            get
            {
           /*     int age = 0;
                try
                {
                    age = user.Age;
                }


                catch (PersonException ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}. Невірне значення: {ex.Value}");
                }
                catch (DeadPersonException ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}. Невірне значення: {ex.Value}");
                }*/
                return _registrationUser.Age;
            }

            set { _registrationUser.Age = 1; }// = value; }
        }
        /*public string Password
        {
            get
            {
                return _registrationUser.Password;
            }
            set
            {
                _registrationUser.Password = value;
            }
        }*/

        public RelayCommand<object> GotoSignInCommand
        {
            get
            {
                return _gotoSignInCommand ??= new RelayCommand<object>(_ => GotoSignIn());
            }
        }

        public RelayCommand<object> SignUpCommand
        {
            get
            {
                return _signUpCommand ??= new RelayCommand<object>(_ => SignUp(), CanExecute);
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ??= new RelayCommand<object>(_ => Environment.Exit(0));
            }
        }

        public AuthNavigationTypes ViewType
        {
            get
            {
                return AuthNavigationTypes.SignUp;
            }
        }
        #endregion

        private void GotoSignIn()
        {
           _gotoSignIn.Invoke();
        }

        private async void SignUp()
        {
            if (String.IsNullOrWhiteSpace(_registrationUser.Login)  || String.IsNullOrWhiteSpace(_registrationUser.Name))//|| String.IsNullOrWhiteSpace(_registrationUser.Password)
                MessageBox.Show("Login or password is empty.");
            else
            {
                var authService = new AuthenticationService();
                try
                {
                    LoaderManager.Instance.ShowLoader();
                    await Task.Run(() => authService.RegisterUser(_registrationUser));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign Up failed: {ex.Message}");
                    return;
                }
                finally
                {
                    LoaderManager.Instance.HideLoader();
                }

                MessageBox.Show($"User successfully registered, please Sign In");
                _gotoSignIn.Invoke();
            }
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_registrationUser.Login)  && !String.IsNullOrWhiteSpace(_registrationUser.Name);//&& !String.IsNullOrWhiteSpace(_registrationUser.Password)
        }
    }
}
