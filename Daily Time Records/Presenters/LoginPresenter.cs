using Daily_Time_Records.Repositories;
using Daily_Time_Records.Views;
using System;
using System.Windows.Forms; // For Form navigation

namespace Daily_Time_Records.Presenters
{
    class LoginPresenter
    {
        private ILoginForm _view;
        private readonly UserRepository _userRepository;

        public LoginPresenter(ILoginForm view)
        {
            _view = view;
            _userRepository = new UserRepository();
            _view.OnLoginAttempt += HandleLoginButtonClicked;
        }

        private void HandleLoginButtonClicked(object sender, (string username, string password) credentials)
        {
            string username = credentials.username;
            string password = credentials.password;

            // Validate user credentials using UserRepository
            if (_userRepository.IsValidUser(username, password))
            {
                // Check if the user has HR role
                string role = _userRepository.getUserRole(username);
                if (role == "HR")
                {
                    // Log the successful login
                    _userRepository.LogLogin(username);

                    // Hide the login form
                    //_view.HideForm();

                    // Open the registration form
                    //RegistrationForm registrationForm = new RegistrationForm();
                    //registrationForm.FormClosed += (s, args) => _view.ShowForm(); // Show login form when registration form is closed
                    //registrationForm.Show();
                    MessageBox.Show("Loading!");
                    _view.CloseAttempt();
                }
                else
                {
                    MessageBox.Show("Access Denied: Only HR users can access the registration form.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.");
            }
        }
    }
}