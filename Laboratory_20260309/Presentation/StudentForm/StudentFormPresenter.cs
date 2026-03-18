using Laboratory_20260309.Domain.Models;
using Laboratory_20260309.Domain.Repositories;
using Laboratory_20260309.Presentation.StudentForm.Interfaces;

namespace Laboratory_20260309.Presentation.StudentForm;

internal class StudentFormPresenter : IStudentFormPresenter
{
    private readonly IStudentFormView _view;

    private readonly IStudentRepository _studentRepository;
    private readonly DziennikStudentow _studentRegister = new();

    private readonly StudentValidator _studentValidator = new();

    private Student? _selectedStudent = null;

    public StudentFormPresenter(IStudentFormView view, IStudentRepository studentRepository)
    {
        _view = view;
        _studentRepository = studentRepository;

        _view.SetStudents(_studentRegister.Students);

        _view.AddStudentClicked += OnAddStudentClicked;
        _view.EditStudentClicked += OnEditStudentClicked;
        _view.DeleteStudentClicked += OnDeleteStudentClicked;
        _view.SaveStudentListClicked += OnSaveStudentListClicked;
        _view.LoadStudentListClicked += OnLoadStudentListClicked;

        _view.StudentSelected += OnStudentSelected;
    }

    private void OnAddStudentClicked(object? sender, StudentInput input)
    {
        var errors = _studentValidator.Validate(input);
        _view.SetFormErorrs(errors);

        if (errors.Count > 0)
        {
            return;
        }

        var student = input.ToStudent();
        _studentRegister.Upsert(student);

        _view.ClearForm();
    }

    private void OnEditStudentClicked(object? sender, StudentInput input)
    {
        if (_selectedStudent is not { } selection)
        {
            return;
        }

        var errors = _studentValidator.Validate(input);
        _view.SetFormErorrs(errors);

        if(errors.Count > 0)
        {
            return;
        }

        var student = input.ToStudent(id: selection.Id);
        _studentRegister.Upsert(student);
    }

    private void OnDeleteStudentClicked(object? sender, EventArgs e)
    {
        if (_selectedStudent is not { } selection)
        {
            return;
        }

        _studentRegister.Delete(selection);

        _view.ClearForm();
    }


    private void OnStudentSelected(object? sender, Student? student)
    {
        _selectedStudent = student;

        if (student is null)
        {
            _view.ClearForm();
        }
        else
        {
            _view.PopulateForm(student);
        }
    }

    private void OnSaveStudentListClicked(object? sender, string path)
    {
        _studentRepository.Save(_studentRegister.Students, path);
    }

    private void OnLoadStudentListClicked(object? sender, string path)
    {
        var students = _studentRepository.Read(path);
        LoadStudentList(students);
    }

    private void LoadStudentList(IEnumerable<Student> students)
    {
        _studentRegister.Students.Clear();

        foreach (var student in students)
        {
            _studentRegister.Students.Add(student);
        }
    }
}
