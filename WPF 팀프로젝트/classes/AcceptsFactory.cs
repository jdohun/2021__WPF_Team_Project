using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WPF_팀프로젝트.classes;

namespace WPF_팀프로젝트 {
    public class AcceptsFactory {
        static IList<Accept> accepts;
        static AcceptsFactory() {   // 생성자에서 접수 목록 가져옴
            accepts = DataManager.Accepts;
        }

        public IEnumerable<Accept> GetAccepts() { // 접수 목록 반환
            return accepts;
        }
    }

    public class Accept : Notifier {
        public string Department { get; set; } // 진료과
        public int Num { get; set; }    // 대기순번
        public string cID { get; set; } // 환자 일련번호
        public string Name { get; set; } // 환자명
        public string Symptom { get; set; } // 환자 증상
    }
}
