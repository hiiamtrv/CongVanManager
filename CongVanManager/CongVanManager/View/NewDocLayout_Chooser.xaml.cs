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
using CongVanManager.ViewModel;

namespace CongVanManager.View
{
    /// <summary>
    /// Interaction logic for NewDocLayout_Chooser.xaml
    /// </summary>
    public partial class NewDocLayout_Chooser : Page
    {
        public NewDocLayout_Chooser()
        {
            InitializeComponent();
            DataContext = NewDocLayout_ChooserViewModel.instance;
        }
    }
}
