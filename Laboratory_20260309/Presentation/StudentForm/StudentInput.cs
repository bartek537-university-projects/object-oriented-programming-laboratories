using Laboratory_20260309.Domain.Models;

namespace Laboratory_20260309.Presentation.StudentForm;

public partial class StudentInput
{
    public required string FirstName { get; set => field = value.Trim(); }
    public required string LastName { get; set => field = value.Trim(); }
    public required DateTime BirthDate { get; set; }
    public required RokStudiow CollegeLevel { get; set; }
    public required string City { get; set => field = value.Trim(); }
    public required string PostalCode { get; set => field = value.Trim(); }
    public required string Street { get; set => field = value.Trim(); }
    public required int BuildingNumber { get; set; }
    public required int? FlatNumber { get; set; }
}
