using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IEmployeeRepository
    {
        void DeleteEmployee(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _db;
        public EmployeeRepository()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
