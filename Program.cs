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
            worksAt(getEmployee("Jordy Leffers"), getCompany("Initworks bv"));
            Console.WriteLine("You ran the program!");
        }
    }
}
