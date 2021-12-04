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
    /// CustomerRecord.xaml에 대한 상호 작용 논리
    /// </summary>
    
    public partial class CustomerRecord : Page {
        
        public CustomerRecord() {
            InitializeComponent();
            this.DataContext = new Customer();
        }
        public CustomerRecord(string cID)
        {
            InitializeComponent();
            //DataGrid
            RecordView.ItemsSource = DataManager.Records.Where(x => x.cID == cID);//.ToList();

            //위에 정보 뜨기
            Customer customer;

            customer = DataManager.Customers.Single(x => x.cID == cID);

            txtBcID.Text = customer.cID;
            txtBName.Text = customer.Name;
            txtBBirth.Text = customer.Birth;
            txtBPhone.Text = customer.Phone;

            //MessageBox.Show(txtBcID.Text);*/


        }
    }
}
