using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WPF_팀프로젝트.classes;

namespace WPF_팀프로젝트
{
    public class CustomerInfoViewModel : Notifier
    {
        CustomerInfoService customerInfoService;
        public CustomerInfoViewModel()
        {
            customerInfoService = new CustomerInfoService();
            LoadData();
           
        }

        private List<Customer> customersList;

        public List<Customer> CustomersList
        {
            get { return customersList; }
            set { 
                customersList = value;
                OnPropertyChanged("CustomersList");
            }
        }
        private void LoadData()
        {
            CustomersList = customerInfoService.GetAll();
        }

       

        
    }
}
