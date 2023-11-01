using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace EmployeeApp.Models
{
    public class EmployeeRepository
    {
        public List<Employee> EmployeeList { get; set; }
        public EmployeeRepository()
        {
            EmployeeList = new List<Employee>();
            EmployeeList.Add(new Employee(){Id=1, FirstName="Ahmet",LastName="Güneş"});
            EmployeeList.Add(new Employee(){Id=2, FirstName="Can",LastName="Dağ"});
            EmployeeList.Add(new Employee(){Id=3, FirstName="Merve",LastName="Yıldız"});
        }

        public Employee GetOne(int id)
        {
            /* /* foreach (var emp in EmployeeList)
            {
                if(emp.Id.Equals(id))
                {
                    return emp;
                } 
            }
            throw new Exception("Not found!"); */
        var result = EmployeeList.Where(emp=>emp.Id == id).SingleOrDefault();
        //return (result!=null?result:null); 
        if (result != null)
        {
            return result;
        }      
        else
            return null;
         }


        public int Add(Employee employee)
        {
            var result = EmployeeList.Where(emp=> emp.Id.Equals(employee.Id)).SingleOrDefault();
            if (result!=null)
                return 0;
            EmployeeList.Add(employee);
            return 1;
        }
        public int UpdateOne(int id, Employee employee){
            /* var result = EmployeeList.Where(emp=>emp.Id == id).SingleOrDefault();
            result = employee; */
            for (int i = 0; i < EmployeeList.Count; i++)
            {
             if (EmployeeList[i].Id == id)
             {
                EmployeeList[i] = employee;
                return 1;
             }   
            }
            return 0;
        }
        public int DeleteOne([FromRoute]int id){
            var result = GetOne(id);
            if (result != null)
            {
            EmployeeList.Remove(result);
            return 1;
            } 
            return 0;
        }
    }
}