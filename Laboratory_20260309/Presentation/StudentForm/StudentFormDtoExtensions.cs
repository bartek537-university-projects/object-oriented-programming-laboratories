using Laboratory_20260309.Domain.Models;

namespace Laboratory_20260309.Presentation.StudentForm;

internal static class StudentFormDtoExtensions
{
    extension(StudentInput model)
    {
        public Student ToStudent(Guid? id = null)
        {
            Address address = new()
            {
                City = model.City,
                PostalCode = model.PostalCode,
                Street = model.Street,
                BuildingNumber = model.BuildingNumber,
                FlatNumber = model.FlatNumber,
            };

            return new()
            {
                Id = id ?? Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                CollegeLevel = model.CollegeLevel,
                HomeAddress = address,
            };
        }
    }
}
