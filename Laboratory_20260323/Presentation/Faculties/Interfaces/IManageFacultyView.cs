namespace Laboratory_20260323.Presentation.Faculties.Interfaces;

public interface IManageFacultyView
{
    string Identifier { set; }
    string FacultyName { get; set; }
    string City { get; set; }
    string PostalCode { get; set; }
    string Street { get; set; }
    string Building { get; set; }

    event EventHandler SubmitClicked;
    event EventHandler CancelClicked;

    void SetErrors(IReadOnlyDictionary<string, string>? errors);
    void Close();
}
