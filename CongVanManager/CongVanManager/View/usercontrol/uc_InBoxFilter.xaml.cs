﻿using CongVanManager.ViewModel;
using System;
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

namespace CongVanManager.View.usercontrol
{
    /// <summary>
    /// Interaction logic for uc_InBoxFilter.xaml
    /// </summary>
    public partial class uc_InBoxFilter : Page
    {
        public uc_InBoxFilter()
        {
            InitializeComponent();
            this.DataContext = InboxLayoutViewModel.Instance;
        }
    }
}