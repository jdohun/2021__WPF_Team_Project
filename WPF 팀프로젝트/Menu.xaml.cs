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

namespace WPF_팀프로젝트 {
    /// <summary>
    /// Menu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Menu : Page {
        public Menu() {
            InitializeComponent();
        }

        private void Button_Click( object sender, RoutedEventArgs e ) {     // 고객 정보
            NavigationService.Navigate(new Uri("/CustomerInfo.xaml", UriKind.Relative));
        }

        private void Button_Click_1( object sender, RoutedEventArgs e ) {   // 접수 현황
            NavigationService.Navigate(new Uri("/AcceptanceList.xaml", UriKind.Relative));
        }
    }
}