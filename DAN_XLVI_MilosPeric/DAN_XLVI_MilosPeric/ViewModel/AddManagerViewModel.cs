using DAN_XLVI_MilosPeric.Command;
using DAN_XLVI_MilosPeric.Model;
using DAN_XLVI_MilosPeric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLVI_MilosPeric.ViewModel
{
    internal class AddManagerViewModel : ViewModelBase
    {
        AddManager addManager;

        public AddManagerViewModel(AddManager manager)
        {
            addManager = manager;
            ListOfManagers = new List<Manager>();
            Manager = new Manager();
        }

        private Manager manager;
        public Manager Manager
        {
            get { return manager; }
            set
            {
               manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private List<Manager> listOfManagers;
        public List<Manager> ListOfManagers
        {
            get { return listOfManagers; }
            set
            {
                listOfManagers = value;
                OnPropertyChanged("ListOfManagers");
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(param => AddCommandExecute(), param => CanAddCommandExecute());
                }
                return addCommand;
            }
        }

        private void AddCommandExecute()
        {
            try
            {
                ListOfManagers.Add(manager);
                LoginViewModel.UserList.Add(Manager.UserName, Manager.Password);
                MessageBox.Show("New Manager Added Successfully!", "Info");
                //addManager.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddCommandExecute()
        {
            if (string.IsNullOrEmpty(Manager.FirstName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (logoutCommand == null)
                {
                    logoutCommand = new RelayCommand(param => Logout());
                    return logoutCommand;
                }
                return logoutCommand;
            }
        }

        public void Logout()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        Login loginView = new Login();
                        Thread.Sleep(1000);
                        addManager.Close();
                        loginView.Show();
                        return;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
