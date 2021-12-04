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
        public AcceptanceList()
        {
            AcceptsFactory accepts = new AcceptsFactory();
            InitializeComponent();
            GwaCombo();
        }

        void GwaCombo()
        {
            DepartmentBox.Items.Add("이비인후과");
            DepartmentBox.Items.Add("내과");
            DepartmentBox.Items.Add("정형외과");
        }

        private void Button_Click(object sender, RoutedEventArgs e) // 입장
        {
            int index = -1;
            string department = DepartmentBox.SelectedItem.ToString();
            Accept accept;
            int AcceptsCnt = DataManager.Accepts.Count() - 1;
            for(int i = 0; i < AcceptsCnt; ++i)
            {
                if (DataManager.Accepts[i].Department == department) {
                    index = i;
                    break;
                }
            }
            if(index == -1) { MessageBox.Show("대기중인 인원이 없습니다."); return; }
            else
            {
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

            DataManager.Save();
        }
      
        private void ComboBox_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            string department = DepartmentBox.SelectedItem.ToString();
            DataGridView.ItemsSource = DataManager.Accepts.Where(x => x.Department == department).ToList();

            //if (DepartmentBox.SelectedItem.ToString()) {  }
            //else if (DepartmentBox.SelectedItem.ToString()) {}
            //else if (DepartmentBox.SelectedItem.ToString()) {}

            /*
             * 콤보 박스 선택 -> 값을 받아옴. 그걸로 datamanager.aceept.where(x => x.department == 콤보박스에서 고른거).ToList();
             * -> 
             * 
             */


            /*
            DataGrid DataGridView = sender as DataGrid;

            List<Customer> list = new List<Customer>();
            DataGridView.ItemsSource = list;

            if (DepartmentBox.SelectedItem.ToString() == "이비인후과")
            {
                DataGridView.ItemsSource = DataManager.Accepts.Where(x => x.Department == "이비인후과").ToList();
            }
            if (DepartmentBox.SelectedItem.ToString() == "정형외과") { DataGridView.ItemsSource = DataManager.Accepts.Where(x => x.Department == "정형외과").ToList(); }
            if (DepartmentBox.SelectedItem.ToString() == "내과") { DataGridView.ItemsSource = DataManager.Accepts.Where(x => x.Department == "내과").ToList(); }
            */
        }
    }
}