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
    /// AcceptanceList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AcceptanceList : Page {
        public AcceptanceList() {
            AcceptsFactory accepts = new AcceptsFactory();
            InitializeComponent();
            GwaCombo();
        }

        void GwaCombo() {
            DepartmentBox.Items.Add("이비인후과");
            DepartmentBox.Items.Add("내과");
            DepartmentBox.Items.Add("정형외과");
            DepartmentBox.Items.Add("백신");
        }

        private void Button_Click( object sender, RoutedEventArgs e ) { // 입장
            int index = -1;
            string department = DepartmentBox.SelectedItem.ToString();
            Accept accept;
            int AcceptsCnt = DataManager.Accepts.Count();
            for ( int i = 0; i < AcceptsCnt; ++i ) {
                if ( DataManager.Accepts[i].Department == department ) {
                    index = i;
                    break;
                }
            }
            if ( index == -1 ) { MessageBox.Show("대기중인 인원이 없습니다."); return; }
            else {
                accept = DataManager.Accepts[index];
                DataManager.Accepts.Remove(accept);
            }

            Record record = new Record()
            {
                cID = accept.cID,
                Symptom = accept.Symptom,
                Department = accept.Department,
                Date = DateTime.Now
            };
            DataManager.Records.Add(record);

            DataGridView.ItemsSource = null;
            DataGridView.ItemsSource = DataManager.Accepts.Where(x => x.Department == department).ToList();

            Customer customer = DataManager.Customers.Single(x => x.cID == accept.cID);
            DataManager.Customers.Remove(customer);
            if( accept.Department == "백신" ) {
                if ( customer.VaccineReserv == "" ) { customer.VaccineReserv = "1차"; }
                else if ( customer.VaccineReserv == "1차" ) { customer.VaccineReserv = "2차"; }
            }
            DataManager.Customers.Add(customer);

            DataManager.Save();
        }

        private void ComboBox_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            string department = DepartmentBox.SelectedItem.ToString();
            DataGridView.ItemsSource = DataManager.Accepts.Where(x => x.Department == department).ToList();
        }
    }
}