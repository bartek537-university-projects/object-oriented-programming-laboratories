using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Employees.Interfaces;
using Laboratory_20260323.Application.Employees.Validators;
using Laboratory_20260323.Infrastructure.Repositories;
using Laboratory_20260323.Presentation;

namespace Laboratory_20260323
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            IEmployeeRepository employeeRepository = new InMemoryEmployeeRepository();

            IValidator<IEmployeeData> employeeDataValidator = new EmployeeDataValidator();

            IAddEmployeeHandler addEmployeeHandler = new AddEmployee.Handler(employeeDataValidator, employeeRepository);
            IGetEmployeesHandler getEmployeesHandler = new GetEmployees.Handler(employeeRepository);
            IUpdateEmployeeHandler updateEmployeeHandler = new UpdateEmployee.Handler(employeeDataValidator, employeeRepository);
            IDeleteEmployeeHandler deleteEmployeeHandler = new DeleteEmployee.Handler(employeeRepository);

            WindowService windowService = new(addEmployeeHandler, getEmployeesHandler, updateEmployeeHandler, deleteEmployeeHandler);

            System.Windows.Forms.Application
                .Run(windowService.CreateMainWindow());
        }
    }
}