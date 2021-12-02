﻿using System;
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
    /// Acceptance.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Acceptance : Page {
        public Acceptance() {
            InitializeComponent();
            ComboBox();
        }

        void ComboBox() {
            foreach ( string symtom in Ibiinhugwa.Symptom ) { // 이비인후과 증상 저장
                cSymptomBox.Items.Add(symtom);
            }

            foreach ( string symtom in Jeonghyeong_oegwa.Symptom ) { // 정형외과 증상 저장
                cSymptomBox.Items.Add(symtom);
            }

            foreach ( string symtom in Naegwa.Symptom ) { // 내과 증상 저장
                cSymptomBox.Items.Add(symtom);
            }

            DepartmentBox.Items.Add("이비인후과");
            DepartmentBox.Items.Add("내과");
            DepartmentBox.Items.Add("정형외과");
        }

        private void SymptomBox_SelectionChanged( object sender, SelectionChangedEventArgs e ) { // 증상 선택
            tSymptomBox.Text = cSymptomBox.Text;
            if( Ibiinhugwa.Symptom.Contains<string>(cSymptomBox.Text) ) { DepartmentBox.Text = "이비인후과"; }
            else if( Naegwa.Symptom.Contains<string>(cSymptomBox.Text) ) { DepartmentBox.Text = "내과"; }
            else if( Jeonghyeong_oegwa.Symptom.Contains<string>(cSymptomBox.Text) ) { DepartmentBox.Text = "정형외과"; }
        }

        private void Button_Click( object sender, RoutedEventArgs e ) { // 접수
            if(tSymptomBox.Text == "" ) {
                MessageBox.Show("증상을 선택하거나 입력하세요.");
                return;
            }
            else if(DepartmentBox.Text == "" ) {
                MessageBox.Show("진료과를 선택하세요.");
                return;
            }

            int aCount = DataManager.Accepts.Where(x => x.Department == DepartmentBox.Text).Count() + 1;
            Accept accept = new Accept();
            accept.cID = cIDBox.Text;
            accept.Name = tSymptomBox.Text;
            accept.Symptom = tSymptomBox.Text;
            accept.Department = DepartmentBox.Text;
            accept.Num = aCount;

            MessageBox.Show(nameBox.Text + "님 " + DepartmentBox.Text + " 접수되었습니다.");
            NavigationService.Navigate(new Uri("Menu.xaml", UriKind.Relative));
        }
    }
}
