﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Practice7UserList.Tools;
using Practice7UserList.Tools.Interfaces;
using Practice7UserList.Tools.Managers;
using Practice7UserList.Tools.Navigation;

namespace Practice7UserList.ViewModels
{
    internal class CreateUserViewModel : BaseViewModel
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _birth;

        #region Commands
        private ICommand _signUpCommand;
        private ICommand _toSignInCommand;
        #endregion
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Birth
        {
            get { return _birth; }
            set
            {
                _birth = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public ICommand CreatePersonCommand =>
            _signUpCommand ?? (_signUpCommand =
                new RelayCommand<object>(CreatePersonImplementation, CanSignUpExecute));

        public ICommand BackCommand => _toSignInCommand ?? (_toSignInCommand = new RelayCommand<object>(BackImplementation));

        #endregion
        #endregion
        private bool CanSignUpExecute(object obj)
        {
            return !String.IsNullOrEmpty(Name) &&
                   !String.IsNullOrEmpty(Surname) &&
                   !String.IsNullOrEmpty(Email) &&
                   !String.IsNullOrEmpty(Birth.ToString());

        }

        private async void CreatePersonImplementation(object obj)
        {
            DateTime birth = (DateTime)Birth;
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {

                    if (!new EmailAddressAttribute().IsValid(Email))
                    {
                        throw new IllegalEmailException(Email);
                    }
                    GoodBirthday(birth);
                }
                catch (IllegalEmailException ex)
                {
                    MessageBox.Show($"Operation failed.Reason:{Environment.NewLine} {ex.Message}");
                    return false;
                }
                catch (IllegalDateException ex1)
                {
                    MessageBox.Show($"Operation failed.Reason:{Environment.NewLine} {ex1.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Procced was failed. Reason:{Environment.NewLine} {ex.Message}");
                    return false;
                }
                try
                {
                    var user = new Person(Name, Surname, _email, (DateTime)Birth);
                    StationManager.DataStorage.AddUser(user);
                    StationManager.CurrentUser = user;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign Up failed fo person {Name}. Reason:{Environment.NewLine} {ex.Message}");
                    return false;
                }
                MessageBox.Show($"Person {Name} was successfully created.");
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
                NavigationManager.Instance.Navigate(ViewType.Main);
        }


        private bool GoodBirthday(DateTime birth)
        {
            DateTime today = DateTime.Today;
            int year = 0;

            if (birth.Month > today.Month || (today.Month == birth.Month && today.Day < birth.Day))
                year = today.Year - birth.Year - 1;
            else
                year = today.Year - birth.Year;
            if (year < 0 || year > 135)
            {
                throw new IllegalDateException(birth + "");
            }

            return true;
        }

        private void IsBirthday()
        {
            DateTime birth = (DateTime)Birth;
            if (birth.Day == DateTime.Today.Day
                && birth.Month == DateTime.Today.Month)
                MessageBox.Show("Happy Birthday!");
        }

        private void BackImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Main);
        }
        
    }
}
