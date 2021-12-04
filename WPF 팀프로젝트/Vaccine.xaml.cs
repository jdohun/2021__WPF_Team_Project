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

            cIDBlock.Text = customer.cID;
            nameBlock.Text = customer.Name;
            birthBlock.Text = customer.Birth;
            phoneBlock.Text = customer.Phone;
          
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

        bool button1_clicked = false;
        bool button2_clicked = false;
        bool button3_clicked = false;
        bool button4_clicked = false;

        private void PreviewMouseUp( object sender, MouseButtonEventArgs e ) {
            DateTime dt = (DateTime)calendar.SelectedDate;
            reservDay.Text = dt.ToString("dd");
            fixedDay.Text = dt.ToString("dd");
        }

        private void button1_Click( object sender, RoutedEventArgs e ) {
            if ( button1_clicked == false ) {
                fixedVaccine.Text = "화이자";
                int count = Convert.ToInt32(pfizer.Text) - 1;
                pfizer.Text = count.ToString();
                pfizer.Foreground = Brushes.Red;

                Moderna.Text = ModernaC.ToString();
                Moderna.Foreground = Brushes.Black;
                AZ.Text = AZC.ToString();
                AZ.Foreground = Brushes.Black;
                Janssen.Text = JanssenC.ToString();
                Janssen.Foreground = Brushes.Black;

                button1_clicked = true;
                button2_clicked = false;
                button3_clicked = false;
                button4_clicked = false;
            }
            else {
                MessageBox.Show("이미 선택한 백신입니다.");
            }
        }

        private void button2_Click( object sender, RoutedEventArgs e ) {
            if ( button2_clicked == false ) {
                fixedVaccine.Text = "모더나";
                int count = Convert.ToInt32(Moderna.Text) - 1;
                Moderna.Text = count.ToString();
                Moderna.Foreground = Brushes.Red;

                pfizer.Text = pfizerC.ToString();
                pfizer.Foreground = Brushes.Black;
                AZ.Text = AZC.ToString();
                AZ.Foreground = Brushes.Black;
                Janssen.Text = JanssenC.ToString();
                Janssen.Foreground = Brushes.Black;

                button2_clicked = true;
                button1_clicked = false;
                button3_clicked = false;
                button4_clicked = false;
            }
            else {
                MessageBox.Show("이미 선택한 백신입니다.");
            }
        }

        private void button3_Click( object sender, RoutedEventArgs e ) {
            if ( button3_clicked == false ) {
                fixedVaccine.Text = "AZ";
                int count = Convert.ToInt32(AZ.Text) - 1;
                AZ.Text = count.ToString();
                AZ.Foreground = Brushes.Red;

                pfizer.Text = pfizerC.ToString();
                pfizer.Foreground = Brushes.Black;
                Moderna.Text = ModernaC.ToString();
                Moderna.Foreground = Brushes.Black;
                Janssen.Text = JanssenC.ToString();
                Janssen.Foreground = Brushes.Black;

                button3_clicked = true;
                button1_clicked = false;
                button2_clicked = false;
                button4_clicked = false;
            }
            else {
                MessageBox.Show("이미 선택한 백신입니다.");
            }
        }

        private void button4_Click( object sender, RoutedEventArgs e ) {
            if ( button4_clicked == false ) {
                fixedVaccine.Text = "얀센";
                int count = Convert.ToInt32(Janssen.Text) - 1;
                Janssen.Text = count.ToString();
                Janssen.Foreground = Brushes.Red;

                pfizer.Text = pfizerC.ToString();
                pfizer.Foreground = Brushes.Black;
                Moderna.Text = ModernaC.ToString();
                Moderna.Foreground = Brushes.Black;
                AZ.Text = AZC.ToString();
                AZ.Foreground = Brushes.Black;

                button4_clicked = true;
                button1_clicked = false;
                button2_clicked = false;
                button3_clicked = false;
            }
            else {
                MessageBox.Show("이미 선택한 백신입니다.");
            }
        }

        private void button5_Click( object sender, RoutedEventArgs e ) { // 예약하기
            if ( reservDay.Text.Trim() == "text" ) {
                MessageBox.Show("날짜를 선택하세요.");
                return;
            }
            else if ( fixedVaccine.Text.Trim() == "text" ) {
                MessageBox.Show("백신 종류를 선택하세요.");
                return;
            }
            else {
                int aCount = 0;
                if ( DataManager.Accepts.Where(x => x.Department == "백신").Count() == 0 ) { aCount = 1; }
                else { aCount = DataManager.Accepts.Where(x => x.Department == "백신").Count() + 1; }

                Vaccination vaccination = DataManager.Vaccinations.Single(x => x.Name == fixedVaccine.Text);
                DataManager.Vaccinations.Remove(vaccination);
                vaccination.Count -= 1;

                DateTime dt = (DateTime)calendar.SelectedDate;
                String reservDay = dt.ToString("yy-MM-dd");

                Accept accept = new Accept(){
                    cID = cIDBlock.Text,
                    Department = "백신",
                    Name = nameBlock.Text,
                    Num = aCount,
                    Symptom = reservDay + fixedVaccine.Text
                };
                
                DataManager.Accepts.Add(accept);
                DataManager.Vaccinations.Add(vaccination);
                DataManager.Save();
                MessageBox.Show("\"" + nameBlock.Text + "\"" + "님의 " + vaccination.Name + " 예약이 완료되었습니다.");
                //NavigationService.Navigate();
            }
        }

        private void button6_Click( object sender, RoutedEventArgs e ) { // 취소하기
            List<Accept> accepts = DataManager.Accepts.Where(x => x.cID == cIDBlock.Text).ToList();
            Accept accept = accepts.Single(x => x.Department == "백신");
            DataManager.Accepts.Remove(accept);
            string vName = accept.Symptom.Substring(8);
            MessageBox.Show("\"" + accept.Name + "\"" + "님의 " + vName + " 예약이 취소되었습니다.");
            DataManager.Save();
        }
    }
}
