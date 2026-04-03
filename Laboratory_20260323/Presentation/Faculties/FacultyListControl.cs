using Laboratory_20260323.Domain.Entities;
using Laboratory_20260323.Presentation.Faculties.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.Faculties;

public partial class FacultyListControl : UserControl, IFacultyListView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IFacultyListPresenter? Presenter { get; set; }

    public FacultyListControl()
    {
        InitializeComponent();

        mlcFaculties.AddColumn("Name", nameof(Faculty.Name));
        mlcFaculties.AddColumn("Address", nameof(Faculty.Address));
    }
}
