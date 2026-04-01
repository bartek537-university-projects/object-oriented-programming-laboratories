namespace Laboratory_20260323.Application.Employees;

public class AddEmployee
{
    public record Request(string FirstName, string LastName);

    public class Handler : IAddEmployeeHandler
    {
        public Response Handle(Request request)
        {
            return new Response();
        }
    }

    public record Response();
}

public interface IAddEmployeeHandler
{
    AddEmployee.Response Handle(AddEmployee.Request request);
}
