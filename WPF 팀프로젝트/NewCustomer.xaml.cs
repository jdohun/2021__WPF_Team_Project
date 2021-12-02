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

namespace WPF_팀프로젝트 {
    /// <summary>
    /// NewCustomer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewCustomer : Page {
        Customer customer = new Customer();
        Customer lastCustomer;
        string fmt = "00";
        string sLastNum;
        int iLastNum;
        public NewCustomer() {
            InitializeComponent();
            nameBox.Focus();
        }
        private void Button_Click( object sender, RoutedEventArgs e ) { // 신규 등록
            if(DataManager.Customers.Exists(x => (x.Name == nameBox.Text && x.Birth == birthBox.Text)) ) { // 이름, 생년월일이 같으면 
                MessageBox.Show("이미 등록된 고객입니다.");
                nameBox.Text = "";
                birthBox.Text = "";
                phoneBox.Text = "";
                nameBox.Focus();
                return;
            }
            string today = DateTime.Now.ToString("yy-MM-dd"); // 일련번호 앞부분에 들어갈 오늘 날짜 추출
            today = today.Replace("-", "");
           
            if ( DataManager.Customers.Count<Customer>() == 0 ) { sLastNum = "01"; } // 최초 고객 등록일 경우에 일련번호 뒷부분에 들어갈 번호
            else {
                lastCustomer = DataManager.Customers.Last<Customer>();
                if(today != lastCustomer.cID.Substring(0, 6) ) { sLastNum = "01"; } // 오늘 날짜 최초 등록일 경우 
                else {
                    string lastNum = lastCustomer.cID.Substring(6); // 오늘날짜를 제외한 일련번호 추출
                    iLastNum = Convert.ToInt32(lastNum) + 1;        // 추출한 번호 +1
                    sLastNum = iLastNum.ToString(fmt);

                }
            }
            
            customer.cID = today + sLastNum;
            customer.Name = nameBox.Text;
            customer.Birth = birthBox.Text;
            customer.Phone = phoneBox.Text;
            
            DataManager.Customers.Add(customer);
            DataManager.Save();
            MessageBox.Show("등록이 완료되었습니다.");
            
            nameBox.Text = "";
            birthBox.Text = "";
            phoneBox.Text = "";
            nameBox.Focus();
        }
    }
}
