using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_팀프로젝트.Model;

namespace WPF_팀프로젝트.ViewModel {
    class AcceptanceViewModel : Notifier{
        private ObservableCollection<Symptom_Model> symptoms;

        public ObservableCollection<Symptom_Model> Symptoms {
            get { return symptoms; }
            set { symptoms = value; }
        }

        private string symptom;

        public string Symptom {
            get { return symptom; }
            set { symptom = value; }
        }

        public AcceptanceViewModel() {
            Symptoms = new ObservableCollection<Symptom_Model>() {
                
            };
        }
    }
}
