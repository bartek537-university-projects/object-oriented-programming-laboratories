using Laboratory_20260323.Domain.Entities;

namespace Laboratory_20260323.Presentation.Faculties.Interfaces;

public interface IFacultyListView
{
    event EventHandler AddFacultyClicked;
    event EventHandler<Faculty> EditFacultyClicked;
    event EventHandler<Faculty> RemoveFacultyClicked;

    void SetFaculties(IReadOnlyList<Faculty> faculties);
}
