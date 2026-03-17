using Laboratory_20260309.Domain.Models;

namespace Laboratory_20260309.Presentation.StudentForm;

internal static class StudentFormDtoExtensions
{
    extension(StudentFormDto model)
    {
        public Student ToStudent()
        {
            Address address = new()
            {
                City = model.Street,
                PostalCode = model.PostalCode,
                Street = model.Street,
                BuildingNumber = model.BuildingNumber,
                FlatNumber = model.FlatNumber,
            };

            return new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                CollegeLevel = model.CollegeLevel,
                HomeAddress = address,
            };
        }
    }
}
