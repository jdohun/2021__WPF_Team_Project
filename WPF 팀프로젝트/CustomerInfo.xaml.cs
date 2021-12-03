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
using System.Xml.Linq;
namespace WPF_팀프로젝트 {

    /// <summary>
    /// CustomerInfo.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CustomerInfo : Page {
        //CustomerInfoViewModel ViewModel;

        Customer customer = new Customer();
        public CustomerInfo() {
            InitializeComponent();
            // ViewModel = new CustomerInfoViewModel();
            //this.DataContext = ViewModel;

        }


        private void Button_Click_1( object sender, RoutedEventArgs e ) {
            NavigationService.Navigate(new Uri("/NewCustomer.xaml", UriKind.Relative));
        }

        private void Button_Click( object sender, RoutedEventArgs e ) {
            NavigationService.Navigate(new Uri("/Acceptance.xaml", UriKind.Relative));
        }

        private void Button_Click_2( object sender, RoutedEventArgs e ) {
            NavigationService.Navigate(new Uri("/Vaccine.xaml", UriKind.Relative));
        }

        private void Button_Click_3( object sender, RoutedEventArgs e ) {
            NavigationService.Navigate(new Uri("/CustomerRecord.xaml", UriKind.Relative));

        }

        private void TextBox_TextChanged( object sender, TextChangedEventArgs e ) {
            customerList.ItemsSource = customer.FindCustomers(searchBox.Text);
        }

        private void Button_Click_4( object sender, RoutedEventArgs e ) {
            try {
                Customer customer = DataManager.Customers.Single((x) => x.cID == txtcID.Text);//수정할 책 찾기
                customer.Name = txtName.Text;
                customer.Birth = txtBirth.Text;
                customer.Phone = txtPhone.Text;

                customerList.ItemsSource = null;
                customerList.ItemsSource = DataManager.Customers;
                DataManager.Save();
                //MessageBox.Show("수정되었습니다.");
            }
            catch ( Exception ex ) {

            }
        }

    }
}
