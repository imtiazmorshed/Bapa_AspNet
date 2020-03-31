using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{
    public interface IEmployeeFacade
    {
        List<HRM_Employee> GetEmployeeAll();
        HRM_Employee GetEmployeeByID(long id);

        void Dispose();
    }
    class EmployeeFacade : BaseFacade, IEmployeeFacade
    {
        public EmployeeFacade(OMSDataContext database)
            : base(database)
        {
        }

        #region IEmployeeFacade Members

        public List<HRM_Employee> GetEmployeeAll()
        {
            List<HRM_Employee> emplyeeList = new List<HRM_Employee>();
            List<HRM_Employee> employeeListNew = new List<HRM_Employee>();
            emplyeeList = Database.HRM_Employees.Where(i => i.IsRemoved == 0).ToList();
            foreach (HRM_Employee employee in emplyeeList)
            { 
                
                employeeListNew.Add(employee);
            }
            return employeeListNew;
        }

        public HRM_Employee GetEmployeeByID(long id)
        {
            HRM_Employee employee = new HRM_Employee();
            employee = Database.HRM_Employees.Single(i => i.IID == id && i.IsRemoved == 0);
            
            return employee;
        }

        #endregion
    }
}
