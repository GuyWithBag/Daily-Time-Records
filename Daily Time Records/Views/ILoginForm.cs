using System;
using System.Collections.Generic;
using System.Text;

namespace Daily_Time_Records.Views
{
    public interface ILoginForm
    {
        event EventHandler<(string username, string password)> OnLoginAttempt;
        //void ShowMessage(string message);
        //void HideForm();
        //void ShowForm();
        public void CloseAttempt();
    }
}
