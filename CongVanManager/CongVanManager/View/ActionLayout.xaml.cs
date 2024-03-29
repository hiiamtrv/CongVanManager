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
using System.Windows.Shapes;
using CongVanManager.ViewModel;

namespace CongVanManager.View
{
    /// <summary>
    /// Interaction logic for ActionLayout.xaml
    /// </summary>
    public partial class ActionLayout : Window
    {
        public ActionLayout()
        {
            InitializeComponent();
            ActionLayoutViewModel temp = ActionLayoutViewModel.instance;
            temp.layout = this;
            this.DataContext = temp;
        }
        public ActionLayout(CongVanManager.CongVan input, DocType bt)
        {
            InitializeComponent();
            ActionLayoutViewModel inst = ActionLayoutViewModel.instance;
            inst.selectedCongVan = input;
            inst.BoxType = bt;
            inst.layout = this;
            this.DataContext = inst;
        }
    }
}
