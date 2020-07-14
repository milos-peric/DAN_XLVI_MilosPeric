using DAN_XLVI_MilosPeric.Command;
using DAN_XLVI_MilosPeric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLVI_MilosPeric.ViewModel
{
    internal class LoginViewModel : ViewModelBase
    {
        Login login;
        public LoginViewModel(Login viewLogin)
        {
            login = viewLogin;
            UserList = new Dictionary<string, string>();
        }

        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private static Dictionary<string, string> userList;
        public static Dictionary<string, string> UserList
        {
            get
            {
                return userList;
            }
            set
            {
                userList = value;
            }
        }

        public string SearchDictForUserName(string username)
        {
            if (UserList.ContainsKey(username))
            {
                return username;
            }
            else
            {
                return string.Empty;
            }
        }

        public string SearchDictForPassword(string password)
        {
            if (UserList.ContainsValue(password))
            {
                return password;
            }
            else
            {
                return string.Empty;
            }
        }

        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(SubmitCommandExecute, param => CanSubmitCommandExecute());
                }
                return submit;
            }
        }

        private void SubmitCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                if (UserName.Equals("WPFadmin") && password.Equals("WPFadmin"))
                {
                    AddManager managerView = new AddManager();
                    login.Close();
                    managerView.Show();
                    return;
                }
                else if (UserName.Equals(SearchDictForUserName(UserName)) && password.Equals(SearchDictForPassword(password)))
                {
                    AddManager managerView = new AddManager();
                    login.Close();
                    managerView.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("Wrong usename or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSubmitCommandExecute()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
