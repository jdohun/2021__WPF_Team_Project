using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_팀프로젝트.classes {
    class Accept {
        public string Department { get; set; } // 진료과
        public int Num { get; set; }    // 대기순번
        public string cID { get; set; } // 환자 일련번호
        public string Name { get; set; } // 환자명
        public string Symptom { get; set; } // 환자 증상

    }
}
