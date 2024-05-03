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
using Traveloka.ViewModel;

namespace Traveloka.views.admin
{
    /// <summary>
    /// Interaction logic for QuanLyKhachSan.xaml
    /// </summary>
    public partial class QuanLyKhachSan : Window
    {
        public QuanLyKhachSan()
        {
            InitializeComponent();
            DataContext = new KhachSanModel();
        }
    }

}