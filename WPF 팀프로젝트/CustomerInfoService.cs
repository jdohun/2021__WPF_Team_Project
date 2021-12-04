using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_팀프로젝트.classes;

namespace WPF_팀프로젝트
{
    public class CustomerInfoService
    {
        private static List<Customer> CustomersList;

        /*public CustomerInfoService()
        {
            CustomersList = new List<Customer>()
            {
                //new Customer { cID="2021", Name="lee", Birth="20000224", Phone="01099888237"}
                //DataManager.Customers
            };
        }*/

        public List<Customer> GetAll()
        {
            return CustomersList;
        }
        
        /*public bool Add(Customer newCustomer)
       {
           //중복되는 사람있으면 처리하기 넣기
           CustomersList.Add(newCustomer);
           return true;
       }*/

        //수정
        /*public bool Update(Customer customerUpdate)
        {
            bool IsUpdated = false;
            for (int index = 0; index < CustomersList.Count; index++)
            {
                if (CustomersList[index].Name == customerUpdate.Name)
                {
                    CustomersList[index].Birth = customerUpdate.Birth;
                    CustomersList[index].Phone = customerUpdate.Phone;
                    IsUpdated = true;
                    break;
                }
            }
            return IsUpdated;
        }

        //삭제
        public bool Delete(string name)
        {
            bool isDeleted = false;
            for (int index = 0; index < CustomersList.Count; index++)
            {
                if (CustomersList[index].Name == name)
                {
                    CustomersList.RemoveAt(index);
                    isDeleted = true;
                    break;
                }
            }
            return isDeleted;
        }

        /*internal object Update(string cID)
        {
            throw new NotImplementedException();
        }

        //검색
        public Customer Search(string name)
        {
            return CustomersList.FirstOrDefault(e => e.Name == name);
        }*/
        
    }
}
