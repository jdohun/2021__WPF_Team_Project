using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WPF_팀프로젝트.classes;
namespace WPF_팀프로젝트 {
    public class Customer : Notifier
    {
        //일련번호
        public string cID { get; set; }

        //이름
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        
        //생년월일
        private string birth;

        public string Birth
        {
            get { return birth; }
            set
            {
                birth = value;
                OnPropertyChanged("Birth");
            }
        }

        //전화번호
        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }
        public IEnumerable<Customer> FindCustomers(string searchString)
        {
            return customers.Where(c => c.Name.Contains(searchString));
        }
        static IList<Customer> customers;
    }
}
