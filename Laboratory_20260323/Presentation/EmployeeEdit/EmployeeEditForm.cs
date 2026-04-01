using Laboratory_20260323.Presentation.EmployeeEdit.Interfaces;
using System.ComponentModel;

namespace Laboratory_20260323.Presentation.EmployeeEdit
{
    public partial class EmployeeEditForm : Form, IEmployeeEditView
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEmployeeEditPresenter? Presenter { get; set; } = null;

        public EmployeeEditForm()
        {
            InitializeComponent();
        }
    }
}
