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
using WPF_팀프로젝트.classes;

namespace WPF_팀프로젝트 {
    /// <summary>
    /// Vaccine.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Vaccine : Page {
        public Vaccine() {
            InitializeComponent();
        }
        private void PreviewMouseUp( object sender, MouseButtonEventArgs e ) {
            DateTime dt = (DateTime)calendar.SelectedDate;
            textblock5.Text = dt.ToString("dd");
            textblock7.Text = dt.ToString("dd");
        }

        private void button1_Click( object sender, RoutedEventArgs e ) {
            textblock6.Text = "화이자";
        }

        private void button2_Click( object sender, RoutedEventArgs e ) {
            textblock6.Text = "모더나";
        }

        private void button3_Click( object sender, RoutedEventArgs e ) {
            textblock6.Text = "AZ";
        }

        private void button4_Click( object sender, RoutedEventArgs e ) {
            textblock6.Text = "얀센";
       
        }

        private void button5_Click( object sender, RoutedEventArgs e ) {

        }

        private void button6_Click( object sender, RoutedEventArgs e ) {

        }
    }
}
