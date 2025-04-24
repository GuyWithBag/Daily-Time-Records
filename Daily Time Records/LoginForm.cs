using Daily_Time_Records.Presenters;
using Daily_Time_Records.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daily_Time_Records
{
    public partial class LoginForm : Form, ILoginForm
    {
        public event EventHandler<(string username, string password)> OnLoginAttempt;
        private LoginPresenter _presenter;

        public LoginForm()
        {
            InitializeComponent();
            _presenter = new LoginPresenter(this); 
            buttonLogin.Click += LoginAttempt; 

        }

        public void LoginAttempt(object sender, EventArgs e)
        {
            OnLoginAttempt?.Invoke(this, (textBoxIDNumber.Text, textBoxPassword.Text)); 
        }

        public void CloseAttempt()
        {
            this.DialogResult = DialogResult.OK;
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

    }
}
