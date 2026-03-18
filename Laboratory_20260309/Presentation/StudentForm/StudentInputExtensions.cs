using Laboratory_20260309.Domain.Models;

namespace Laboratory_20260309.Presentation.StudentForm;

internal static class StudentInputExtensions
{
    extension(StudentInput model)
    {
        public Student ToStudent(Guid? id = null)
        {
            Adres address = new()
            {
                Miasto = model.City,
                KodPocztowy = model.PostalCode,
                lica = model.Street,
                NumerBudynku = model.BuildingNumber,
                NumerMieszkania = model.FlatNumber,
            };

            return new()
            {
                Id = id ?? Guid.NewGuid(),
                Imie = model.FirstName,
                Nazwisko = model.LastName,
                DataUrodzenia = model.BirthDate,
                RokStudiow = model.CollegeLevel,
                AdresZamieszkania = address,
            };
        }
    }
}
