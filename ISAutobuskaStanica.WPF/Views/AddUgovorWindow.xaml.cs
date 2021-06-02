﻿using ISAutobuskaStanica.WPF.ViewModels;
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
using System.Windows.Shapes;

namespace ISAutobuskaStanica.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddUgovorWindow.xaml
    /// </summary>
    public partial class AddUgovorWindow : Window
    {
        public AddUgovorWindow()
        {
            InitializeComponent();
            DataContext = new AddUgovorViewModel() {Window = this };
        }
    }
}
