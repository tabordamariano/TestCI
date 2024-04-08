using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository ?? new EmployeeRepository();
        }

        public ActionResult DeleteEmployee(int id)
        {
            _repository.DeleteEmployee(id);
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}