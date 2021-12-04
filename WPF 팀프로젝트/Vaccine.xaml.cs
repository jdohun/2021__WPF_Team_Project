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
        public int pfizerC, ModernaC, AZC, JanssenC;

        public Vaccine() {
            InitializeComponent();
            this.DataContext = new Customer();
            Load();
        }

        public Vaccine(string cID)
        {
            InitializeComponent();

            //위에 정보 뜨기
            Customer customer;

            customer = DataManager.Customers.Single(x => x.cID == cID);

            cIDBox.Text = customer.cID;
            nameBox.Text = customer.Name;
            birthBox.Text = customer.Birth;
            phoneBox.Text = customer.Phone;
          
        }

        public void Load()
        {
            List<Vaccination> vaccinations = DataManager.Vaccinations;
            pfizerC = vaccinations.Single(x => x.Name == "화이자").Count;
            ModernaC = vaccinations.Single(x => x.Name == "모더나").Count;
            AZC = vaccinations.Single(x => x.Name == "AZ").Count;
            JanssenC = vaccinations.Single(x => x.Name == "얀센").Count;

            pfizer.Text = pfizerC.ToString();
            Moderna.Text = ModernaC.ToString();
            AZ.Text = AZC.ToString();
            Janssen.Text = JanssenC.ToString();
        }

        long Firsttime = 0;   // 첫번째 클릭시간

        bool button1_clicked = false;
        bool button2_clicked = false;
        bool button3_clicked = false;
        bool button4_clicked = false;

        private void PreviewMouseUp( object sender, MouseButtonEventArgs e ) {
            DateTime dt = (DateTime)calendar.SelectedDate;
            textblock5.Text = dt.ToString("dd");
            textblock7.Text = dt.ToString("dd");
        }

        private void button1_Click( object sender, RoutedEventArgs e ) {
            if (button1_clicked == false)
            {
                textblock6.Text = "화이자";
                int count = Convert.ToInt32(pfizer.Text) - 1;
                pfizer.Text = count.ToString();
                pfizer.Foreground = Brushes.Red;
                
                button1_clicked = true;
                button2_clicked = false;
                button3_clicked = false;
                button4_clicked = false;
            }
            else
            {
                MessageBox.Show("이미 선택한 백신입니다.");
            }
        }

        private void button2_Click( object sender, RoutedEventArgs e ) {
            if (button2_clicked == false)
            {
                textblock6.Text = "모더나";
                int count = Convert.ToInt32(Moderna.Text) - 1;
                Moderna.Text = count.ToString();
                Moderna.Foreground = Brushes.Red;
                
                button2_clicked = true;
                button1_clicked = false;
                button3_clicked = false;
                button4_clicked = false;
            }
            else
            {
                MessageBox.Show("이미 선택한 백신입니다.");
            }
        }

        private void button3_Click( object sender, RoutedEventArgs e ) {
            if (button3_clicked == false)
            {
                textblock6.Text = "AZ";
                int count = Convert.ToInt32(AZ.Text) - 1;
                AZ.Text = count.ToString();
                AZ.Foreground = Brushes.Red;
                
                button3_clicked = true;
                button1_clicked = false;
                button2_clicked = false;
                button4_clicked = false;
            }
            else
            {
                MessageBox.Show("이미 선택한 백신입니다.");
            }
        }

        private void button4_Click( object sender, RoutedEventArgs e ) {
            if (button4_clicked == false)
            {
                textblock6.Text = "얀센";
                int count = Convert.ToInt32(Janssen.Text) - 1;
                Janssen.Text = count.ToString();
                Janssen.Foreground = Brushes.Red;
                
                button4_clicked = true;
                button1_clicked = false;
                button2_clicked = false;
                button3_clicked = false;
            }
            else
            {
                MessageBox.Show("이미 선택한 백신입니다.");
            }
        }

        private void button5_Click( object sender, RoutedEventArgs e ) // 예약하기
        {
            if (textblock5.Text == "")
            {
                MessageBox.Show("날짜를 선택하세요.");
                return;
            }
            else if (textblock6.Text == "")
            {
                MessageBox.Show("백신 종류를 선택하세요.");
                return;
            }
            else
            {

                //int cnt = 0;
                //if (DataManager.Accepts.Where(x => x.Name == textblock2.Text).Count() == 0)
                //{
                //    cnt = 1;
                //}
                //else { cnt = DataManager.Accepts.Where(x => x.Name == textblock2.Text).Count() + 1; }

//                Record record = new Record();
//                record.cID = textblock1.Text;
            
//.               record.Department = "백신";



//                DataManager.Records.Add(record);
//                DataManager.Save();
        
//                MessageBox.Show(textblock2.Text + "님 " + textblock6.Text + " 백신이 예약되었습니다.");
//                NavigationService.Navigate(new Uri("Menu.xaml", UriKind.Relative));
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e) // 취소하기
        {
            if (textblock5.Text == "")
            {
                MessageBox.Show("날짜를 선택하세요.");
                return;
            }
            else if (textblock6.Text == "")
            {
                MessageBox.Show("백신 종류를 선택하세요.");
                return;
            }
            /*
            else
            {
                
                int cnt = 0;
                if (DataManager.Accepts.Where(x => x.Name == textblock2.Text).Count() == 0)
                {
                    cnt = 0;
                }
                else { cnt = DataManager.Accepts.Where(x => x.Name == textblock2.Text).Count() - 1; }

                Accept accept = new Accept();
                accept.cID = textblock1.Text;
                accept.Name = textblock2.Text;
                accept.Num = cnt;
                
                // 백신 값 되돌리기 실패

                //DataManager.Accepts.Remove(accept);
                DataManager.Save();
                MessageBox.Show(textblock2.Text + "님 " + textblock6.Text + " 백신이 취소되었습니다.");
                NavigationService.Navigate(new Uri("Menu.xaml", UriKind.Relative));
            }
            */

        }
        }
    }
