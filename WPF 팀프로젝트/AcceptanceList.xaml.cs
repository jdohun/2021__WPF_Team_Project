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
    /// AcceptanceList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AcceptanceList : Page {
        public AcceptanceList() {
            InitializeComponent();

            DataGridView.DataSource = DataManager.Accepts;
            DataGridView.CurrentCellChanged += DataGridView_CurrentCellChanged;

        }


            private void Button_Click(object sender, RoutedEventArgs e) // 입장
            {
                try
                {
                    DataGridView.DataSource = null;
                    DataGridView.DataSource = DataManager.Accepts;
                    DataManager.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("입장에 실패하셨습니다........");
                }
            }
            private void Ibiinhugwa_Selected(object sender, RoutedEventArgs e) // 콤보 박스에 이비인후과 선택 시
            {
                DataGridView
            }

        private void DataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            Acceptance acceptance = DataGridView.DataBoundItem as Acceptance;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DepartmentBox.SelectedItem.ToString() == "이비인후과") { DataGridView.ItemsSource = DataManager.Accepts.Where(x => x.Department == "이비인후과").ToList(); }
            if (DepartmentBox.SelectedItem.ToString() == "정형외과") { DataGridView.ItemsSource = DataManager.Accepts.Where(x => x.Department == "정형외과").ToList(); }
            if (DepartmentBox.SelectedItem.ToString() == "내과") { DataGridView.ItemsSource = DataManager.Accepts.Where(x => x.Department == "내과").ToList(); }
        }
    }
    }

