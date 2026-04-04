using Laboratory_20260323.Application.Abstractions.Interfaces;
using Laboratory_20260323.Application.Abstractions.Repositories;
using Laboratory_20260323.Application.Employees;
using Laboratory_20260323.Application.Employees.Interfaces;
using Laboratory_20260323.Application.Employees.Validators;
using Laboratory_20260323.Application.Faculties;
using Laboratory_20260323.Application.Faculties.Interfaces;
using Laboratory_20260323.Application.Faculties.Validators;
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
            IFacultyRepository facultyRepository = new InMemoryFacultyRepository();

            IValidator<IEmployeeData> employeeDataValidator = new EmployeeDataValidator();
            IValidator<IFacultyData> facultyDataValidator = new FacultyDataValidator();

            IAddEmployeeHandler addEmployeeHandler = new AddEmployee.Handler(employeeDataValidator, employeeRepository);
            IGetEmployeesHandler getEmployeesHandler = new GetEmployees.Handler(employeeRepository);
            IUpdateEmployeeHandler updateEmployeeHandler = new UpdateEmployee.Handler(employeeDataValidator, employeeRepository);
            IDeleteEmployeeHandler deleteEmployeeHandler = new DeleteEmployee.Handler(employeeRepository);

            IAddFacultyHandler addFacultyHandler = new AddFaculty.Handler(facultyDataValidator, facultyRepository);
            IGetFacultiesHandler getFacultiesHandler = new GetFaculties.Handler(facultyRepository);
            IUpdateFacultyHandler updateFacultyHandler = new UpdateFaculty.Handler(facultyDataValidator, facultyRepository);
            IDeleteFacultyHandler deleteFacultyHandler = new DeleteFaculty.Handler(facultyRepository);

            WindowService windowService = new(
                addEmployeeHandler, getEmployeesHandler, updateEmployeeHandler, deleteEmployeeHandler,
                addFacultyHandler, getFacultiesHandler, updateFacultyHandler, deleteFacultyHandler
            );

            System.Windows.Forms.Application
                .Run(windowService.CreateMainWindow());
        }
    }
}