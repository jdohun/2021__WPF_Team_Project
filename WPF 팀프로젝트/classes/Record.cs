using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_팀프로젝트.classes {
    class Record {
        public string cID { get; set; } // 환자 일련번호
        public string Department { get; set; }  // 진료과
        public string Symptom { get; set; }  // 증상
        public DateTime Date { get; set; }  // 진료날짜
    }
}
/*
  일련번호
오늘날짜 + 4자리 숫자 순서대로
211201 + 01
211201 + 02
211201 + 03
211201 + 04
*/