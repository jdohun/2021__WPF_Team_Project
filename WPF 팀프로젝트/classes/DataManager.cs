using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WPF_팀프로젝트.classes;

namespace WPF_팀프로젝트 {
    class DataManager {
        // xml로부터 받아올 Customer, Record, Vaccination, Accept List들
        public static List<Customer> Customers = new List<Customer>();              // 고객
        public static List<Record> Records = new List<Record>();                    // 진료 기록
        public static List<Vaccination> Vaccinations = new List<Vaccination>();     // 백신 접종
        public static List<Accept> Accepts = new List<Accept>();                    // 접수 현황

        /*private*/
        static DataManager() {  // 생성자
            Load();
        }
        public static void Load() {
            try {
                // 고객 Customer
                string customersOutput = File.ReadAllText(@"./Customers.xml");
                XElement customersXElement = XElement.Parse(customersOutput);

                Customers = ( from item in customersXElement.Descendants("customer")
                          select new Customer() {
                              cID = item.Element("cID").Value,
                              Name = item.Element("name").Value,
                              Birth = item.Element("birth").Value,
                              Phone = item.Element("phone").Value
                          } ).ToList<Customer>();

                // 기록 Record
                string recordsOutput = File.ReadAllText(@"./Records.xml");
                XElement recordsXElement = XElement.Parse(recordsOutput);

                Records = (from item in recordsXElement.Descendants("record")
                           select new Record()
                           {
                               cID = item.Element("cID").Value,
                               Department = item.Element("department").Value,
                               Symptom = item.Element("symtom").Value,
                               Date = DateTime.Parse(item.Element("date").Value)
                           }).ToList<Record>();

                // 백신 Vaccination
                string vaccinationsOutput = File.ReadAllText(@"./Vaccinations.xml");
                XElement vaccinationsXElement = XElement.Parse(vaccinationsOutput);

                Vaccinations = ( from item in vaccinationsXElement.Descendants("vaccination")
                          select new Vaccination() {
                              Name = item.Element("name").Value,
                              Count = int.Parse(item.Element("count").Value)
                          } ).ToList<Vaccination>();

               // 접수 현황 Accept
                string acceptsOutput = File.ReadAllText(@"./Accepts.xml");
                XElement acceptsXElement = XElement.Parse(acceptsOutput);

                Accepts = (from item in acceptsXElement.Descendants("accept")
                         select new Accept()
                         {
                             Department = item.Element("department").Value,
                             Num = int.Parse(item.Element("num").Value),
                             Name = item.Element("name").Value,
                             Symptom = item.Element("symptom").Value
                         }).ToList<Accept>();
             
            }
            catch ( FileNotFoundException e ) {
                Save();
            }
        }

        public static void Save() {
            // 고객 목록
            string customersOutput = "";
            customersOutput += "<customers>\n";
            foreach ( var item in Customers ) {
               customersOutput += "<customer>\n";

                customersOutput += "<cID>" + item.cID + "</cID>\n";
                customersOutput += "<name>" + item.Name + "</name>\n";
                customersOutput += "<birth>" + item.Birth + "</birth>\n";
                customersOutput += "<phone>" + item.Phone + "</phone>\n";

                customersOutput += "</customer>\n";
            }

            customersOutput += "</customers>";

            /* 기록 목록 */
            string recordsOutput = "";
            recordsOutput += "<records>\n";
            foreach ( var item in Records ) {
                recordsOutput += "<record>\n";

                recordsOutput += "<cID>" + item.cID + "</cID>\n";
                recordsOutput += "<department>" + item.Department+ "</department>\n";
                recordsOutput += "<symptom>" + item.Symptom + "</symptom>\n";
                recordsOutput += "<date>" + item.Date.ToLongDateString() + "</date>\n";

                recordsOutput += "</record>\n";
            }
            recordsOutput += "</records>";

            // 백신 목록
            string vaccinationsOutput = "";
            vaccinationsOutput += "<vaccinations>\n";
            foreach (var item in Vaccinations)
            {
                vaccinationsOutput += "<vaccination>\n";

                vaccinationsOutput += "<name>" + item.Name + "</name>\n";
                vaccinationsOutput += "<count>" + item.Count + "</count>\n";

                vaccinationsOutput += "</vaccination>\n";
            }
            vaccinationsOutput += "</vaccinations>";


            // 접수 목록
            string acceptsOutput = "";
            acceptsOutput += "<accepts>\n";
            foreach (var item in Accepts)
            {
                acceptsOutput += "<accept>\n";

                acceptsOutput += "<dapartment>" + item.Department + "</department>\n";
                acceptsOutput += "<num>" + item.Num + "</num>\n";
                acceptsOutput += "<name>" + item.Name + "</name>\n";
                acceptsOutput += "<symptom>" + item.Symptom + "</symptom>\n";

                acceptsOutput += "</accept>\n";
            }

            acceptsOutput += "</accepts>";

            File.WriteAllText(@"./Customers.xml", customersOutput);
            File.WriteAllText(@"./Records.xml", recordsOutput);
            File.WriteAllText(@"./Vaccinations.xml", vaccinationsOutput);
            File.WriteAllText(@"./Accepts.xml", acceptsOutput);
        }
    }
}
