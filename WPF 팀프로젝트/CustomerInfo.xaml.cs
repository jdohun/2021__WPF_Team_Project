using System;
using System.Collections.Generic;
using System.Data;
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
        CustomersFactory factory = new CustomersFactory();
        public CustomerInfo() {
            InitializeComponent();
            customerList.ItemsSource = factory.GetCustomers();
        }

        //신규
        private void Button_Click_1( object sender, RoutedEventArgs e ) {
            NavigationService.Navigate(new Uri("/NewCustomer.xaml", UriKind.Relative));
        }

        //접수
        private void Button_Click( object sender, RoutedEventArgs e ) {
            if ( txtcID.Text.Trim() == "" ) { MessageBox.Show("접수하려는 고객의 아이디를 입력해주세요."); return; }
            else {
                if ( !DataManager.Customers.Exists(x => x.cID == txtcID.Text) ) { MessageBox.Show("존재하지 않는 고객입니다."); }
                else {
                    string cID = txtcID.Text;
                    NavigationService.Navigate(new Acceptance(cID));
                }
            }
        }

        //백신
        private void Button_Click_2( object sender, RoutedEventArgs e ) {
            if ( txtcID.Text.Trim() == "" ) { MessageBox.Show("백신예약하려는 고객의 아이디를 입력해주세요."); return; }
            else { //선택되었다면
                if ( !DataManager.Customers.Exists(x => x.cID == txtcID.Text) ) { MessageBox.Show("존재하지 않는 고객입니다."); }
                else {
                    string cID = txtcID.Text;
                    NavigationService.Navigate(new Vaccine(cID));
                }
            }
        }

        // 기록
        private void Button_Click_3( object sender, RoutedEventArgs e ) {
            if ( txtcID.Text.Trim() == "" ) { MessageBox.Show("기록을 확인하려는 고객의 아이디를 입력해주세요."); return; }
            else { //선택되었다면
                if ( !DataManager.Customers.Exists(x => x.cID == txtcID.Text) ) { MessageBox.Show("존재하지 않는 고객입니다."); }
                else {
                    string cID = txtcID.Text;
                    NavigationService.Navigate(new CustomerRecord(cID));
                }
            }
        }

        //검색
        private void TextBox_TextChanged( object sender, TextChangedEventArgs e ) {
            try {
                customerList.ItemsSource = factory.FindCustomers(searchBox.Text);
            }
            catch ( Exception ex ) {
                Console.WriteLine(ex.ToString());
            }
        }

        //삭제 버튼
        private void Button_Click_4( object sender, RoutedEventArgs e ) {
            if ( txtcID.Text.Trim() == "" ) { MessageBox.Show("삭제하려는 고객의 아이디를 입력해주세요."); return; }

            Customer customer;
            if ( !DataManager.Customers.Exists(x => x.cID == txtcID.Text) ) { MessageBox.Show("존재하지 않는 고객입니다."); }
            else {
                customer = DataManager.Customers.Single(x => x.cID == txtcID.Text);
                DataManager.Customers.Remove(customer);
                MessageBox.Show(customer.Name + " 님의 정보가 삭제되었습니다.");
                DataManager.Save();
                customerList.ItemsSource = null;
                customerList.ItemsSource = DataManager.Customers;
            }
        }

        //수정 버튼
        private void Button_Click_5( object sender, RoutedEventArgs e ) {
            Customer customer;
            if ( !DataManager.Customers.Exists(x => x.cID == txtcID.Text) ) { MessageBox.Show("존재하지 않는 고객입니다."); }
            else {
                customer = DataManager.Customers.Single(x => x.cID == txtcID.Text);
                customer.Name = txtName.Text;
                customer.Birth = txtBirth.Text;
                customer.Phone = txtPhone.Text;

                MessageBox.Show(customer.Name + " 님의 정보가 수정되었습니다.");

                DataManager.Save();
                customerList.ItemsSource = null;
                customerList.ItemsSource = DataManager.Customers;

            }
        }

        private void Button_Click_6( object sender, RoutedEventArgs e ) {
            NavigationService.Navigate(new Uri("/AcceptanceList.xaml", UriKind.Relative));
        }
    }
}
