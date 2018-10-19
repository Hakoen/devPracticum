using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ticketSystem
{
    class Program
    {
        public static Company getCompany(string companyName)
        {
            using (var db = new ticketSystemContext())
            {
                var companyQuery = from c in db.Company select c;

                foreach (Company item in companyQuery)
                {
                    if(item.Name == companyName)
                    {
                        return item;
                    }
                    
                }
                return null;
            }
        }
        public static Employee getEmployee(string employeeName)
        {
            using (var db = new ticketSystemContext())
            {
                var employeeQuery = from e in db.Employee select e;

                foreach (Employee item in employeeQuery)
                {
                    if(item.Name == employeeName)
                    {
                        return item;
                    }
                    
                }
                return null;
            }
        }

        public static void worksAt(Employee employee, Company bedrijf)
        {
            using (var db = new ticketSystemContext())
            {
                var employeeQuery = from e in db.Employee select e;
                foreach(Employee staffMember in employeeQuery)
                {
                    if (staffMember.ID == employee.ID)
                    {
                        staffMember.CompanyID = bedrijf.ID;
                        Console.WriteLine("Je hebt " + staffMember.Name + " bij " + bedrijf.Name + " laten werken.");
                    }
                }
                db.SaveChanges();
            }
        }
        static void Main(string[] args)
        {
            using(var db = new ticketSystemContext())
            {
                Company Initworks = new Company
                    {
                        Name = "Initworks bv",
                        Address = "Lloydstraat 5, Rotterdam",
                        Employees = new System.Collections.Generic.List<Employee>
                        {
                            new Employee
                            {
                                Name = "Richard Auguspurgert",
                                SSN = "0632159735"
                            },
                            new Employee
                            {
                                Name = "Wim",
                                SSN = "2498637105"
                            },
                            new Employee
                            {
                                Name = "Jordy Leffers",
                                SSN = "83125146054"
                            }

                        }
                    };

                    Company hoppinger = new Company
                    {
                        Name = "Hoppinger",
                        Address = "Lloydstraat 114, Rotterdam",
                        Employees = new System.Collections.Generic.List<Employee>
                        {
                            new Employee
                            {
                                Name = "Guiseppi",
                                SSN = "8654983215"
                            },
                            new Employee
                            {
                                Name = "Allon de Veen",
                                SSN = "0197536485"
                            }
                        }
                    };
                db.Company.Add(Initworks);
                db.Company.Add(hoppinger);
                db.SaveChanges();
            }
        }
    }
}
