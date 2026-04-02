namespace Laboratory_20260323.Presentation.Employees.Interfaces;

public interface IManageEmployeeView
{
    string Identifier { set; }
    string FirstName { get; set; }
    string LastName { get; set; }

    event EventHandler SubmitClicked;
    event EventHandler CancelClicked;

    void SetErrors(IReadOnlyDictionary<string, string>? errors);
    void Close();
}
