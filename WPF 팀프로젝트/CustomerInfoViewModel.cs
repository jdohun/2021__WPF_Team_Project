using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WPF_팀프로젝트.classes;
using System.Collections.ObjectModel;
namespace WPF_팀프로젝트
{
    public class CustomerInfoViewModel : Notifier
    {
        CustomerInfoService customerInfoService;
        public CustomerInfoViewModel()
        {
            customerInfoService = new CustomerInfoService();
            LoadData();
            //currentCustomer = new Customer();
            //updateCommand = new Command(Update);
           
        }

        private ObservableCollection<Customer> customersList;

        public ObservableCollection<Customer> CustomersList
        {
            get { return customersList; }
            set { 
                customersList = value;
                OnPropertyChanged("CustomersList");
            }
        }
        private void LoadData()
        {
            CustomersList = new ObservableCollection<Customer>(customerInfoService.GetAll());
        }
        private Customer currentCustomer;

        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set { 
                currentCustomer = value;
                OnPropertyChanged("CurrentCustomer");    
            }
        }


        /*private string messageBox;

        public string MessageBox
        {
            get { return messageBox; }
            set { messageBox = value; }
        }



        private Command updateCommand;

        public Command UpdateCommand
        {
            get { return updateCommand; }
           
        }
        public void Update()
        {
            try
            {
                var isUpdated = customerInfoService.Update(CurrentCustomer.cID);
                if(isUpdated)
                {
                    //Message = "Customer Updated";
                 
                    LoadData();
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private bool CanExecute(object arg)
        {
            return true;
        }

        private Command deleteCommand;

        public Command DeleteCommand
        {
            get { return deleteCommand; }
        
        }
        public void Delete()
        {
            try
            {
                var IsDelete = customerInfoService.Delete(CurrentCustomer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        */


    }
}
