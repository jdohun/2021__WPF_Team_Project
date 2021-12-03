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

            //textblock1.Text = DataManager.Customers

            //Customer customer = DataManager.Customers.Single(x => x.cID == textblock1.Text);
            //Vaccination vaccinations = DataManager.Vaccinations.Single(x => x.Count.ToString() == textblock9.Text); // 수량을 string..?

            //customer.cID = textblock1.Text;
            //            customer.Name = textblock2.Text;
            //            customer.Birth = textblock3.Text;
            //            customer.Phone = textblock4.Text;

            //            DataManager.Save();
            /*
            private void PreviewMouseUp(object sender, MouseButtonEventArgs e) // 날짜 누르면 텍스트 블럭에 날짜 뜨게
            {
                DateTime dt = (DateTime)calendar.SelectedDate;
                textblock5.Text = dt.ToString("dd");
                textblock7.Text = dt.ToString("dd");
            }

            private void button1_Click(object sender, RoutedEventArgs e) // 화이자 버튼 클릭 시 텍스트 블럭에 화이자 뜨게
            {
                textblock6.Text = "화이자";

            }

            private void button2_Click(object sender, RoutedEventArgs e) // 모더나 버튼 클릭 시 텍스트 블럭에 모더나 뜨게
            {
                textblock6.Text = "모더나";
            }

            private void button3_Click(object sender, RoutedEventArgs e) // AZ 버튼 클릭 시 텍스트 블럭에 AZ 뜨게
            {
                textblock6.Text = "AZ";
            }

            private void button4_Click(object sender, RoutedEventArgs e) // 얀센 버튼 클릭 시 텍스트 블럭에 얀센 뜨게
            {
                textblock6.Text = "얀센";
            }

            private void button5_Click(object sender, RoutedEventArgs e) // 예약하기
            {


                }

            }

            private void button6_Click(object sender, RoutedEventArgs e) // 취소하기
            {

            */
        }
    }
}
