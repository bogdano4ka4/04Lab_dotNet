﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practice7UserList.Tools.Navigation;
using Practice7UserList.ViewModels;

namespace Practice7UserList.Views
{
    public partial class MainView : UserControl, INavigatable
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
