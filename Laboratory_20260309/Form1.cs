using Laboratory_20260309.Domain.Models;
using System.Text.RegularExpressions;

namespace Laboratory_20260309
{
    public partial class ManageStudentsForm : Form
    {
        private const string PostalCodePattern = @"^\d{2}-\d{3}$";

        [GeneratedRegex(PostalCodePattern)]
        private static partial Regex PostalCodeRegex();

        public ManageStudentsForm()
        {
            InitializeComponent();

            cbCollegeLevel.DataSource = Enum.GetValues<CollegeLevel>();
        }

        private void AddStudent()
        {
            ValidateChildren();

            if (errorProvider.HasErrors)
            {
                MessageBox.Show("Formularz zawiera błędy.");
                return;
            }

            var student = CreateStudent();
        }

        private Student CreateStudent() => new()
        {
            FirstName = tbFirstName.Text.Trim(),
            LastName = tbFirstName.Text.Trim(),
            BirthDate = dtpBirthDate.Value,
            CollegeLevel = (CollegeLevel) cbCollegeLevel.SelectedValue,
            HomeAddress = new()
            {
                City = tbCity.Text.Trim(),
                PostalCode = mtbPostalCode.Text.Trim(),
                Street = tbStreet.Text.Trim(),
                BuildingNumber = (int) nudBuildingNumber.Value,
                FlatNumber = cbFlatNumberEnabled.Checked ? (int) nudFlatNumber.Value : null
            }
        };

        private void ValidateFirstName()
        {
            ValidateTextBoxLength(tbFirstName, 1, tbFirstName.MaxLength);
        }

        private void ValidateTextBoxLength(TextBox textBox, int min, int max)
        {
            var text = textBox.Text.Trim();

            if (text.Length >= min && text.Length <= max)
            {
                errorProvider.SetError(textBox, null);
                return;
            }

            var message = $"Pole musi zawierać między {min} a {max} znaki (nie wliczając białych znaków z obydwu końców).";
            errorProvider.SetError(textBox, message);
        }

        private void ValidateLastName()
        {
            ValidateTextBoxLength(tbLastName, 1, tbLastName.MaxLength);
        }

        private void ValidateBirthDate()
        {
            var date = dtpBirthDate.Value;

            if (date <= DateTime.Now)
            {
                errorProvider.SetError(dtpBirthDate, null);
                return;
            }

            errorProvider.SetError(dtpBirthDate, "Data urodzenia nie może znajdować się w przyszłości.");
        }

        private void ValidateCity()
        {
            ValidateTextBoxLength(tbCity, 1, tbCity.MaxLength);
        }

        private void ValidatePostalCode()
        {
            var text = mtbPostalCode.Text;

            if (PostalCodeRegex().IsMatch(text))
            {
                errorProvider.SetError(mtbPostalCode, null);
                return;
            }

            errorProvider.SetError(mtbPostalCode, "Niepoprawny kod pocztowy.");
        }

        private void ValidateStreet()
        {
            ValidateTextBoxLength(tbStreet, 1, tbStreet.MaxLength);
        }

        private void ToggleFlatNumberEnabledState()
        {
            nudFlatNumber.Enabled = cbFlatNumberEnabled.Checked;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void cbFlatNumberEnabled_CheckedChanged(object sender, EventArgs e)
        {
            ToggleFlatNumberEnabledState();
        }

        private void tbFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateFirstName();
        }

        private void tbLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateLastName();
        }
        private void dtpBirthDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateBirthDate();
        }

        private void tbCity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateCity();
        }

        private void mtbPostalCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidatePostalCode();
        }
        private void tbStreet_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateStreet();
        }
    }
}
