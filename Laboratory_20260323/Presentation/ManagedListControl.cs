using System.ComponentModel;

namespace Laboratory_20260323.Presentation;

public partial class ManagedListControl : UserControl
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IReadOnlyList<object> DataSource
    {
        set => dgvManagedList.DataSource = value;
    }

    public event EventHandler? AddClicked;
    public event EventHandler<object>? EditClicked;
    public event EventHandler<object>? RemoveClicked;

    public ManagedListControl()
    {
        InitializeComponent();
        OnSelectionChanged();

        dgvManagedList.AutoGenerateColumns = false;
        dgvManagedList.Columns.Clear();
    }

    private void dgvManagedList_SelectionChanged(object sender, EventArgs e)
    {
        OnSelectionChanged();
    }

    private void OnSelectionChanged()
    {
        UpdateActionButtons();
    }

    private void UpdateActionButtons()
    {
        if (GetSelectedItem() is null)
        {
            DisableActionButtons();
        }
        else
        {
            EnableActionButtons();
        }
    }

    private object? GetSelectedItem()
    {
        return dgvManagedList.CurrentRow?.DataBoundItem;
    }

    private void DisableActionButtons()
    {
        btnEdit.Enabled = false;
        btnRemove.Enabled = false;
    }

    private void EnableActionButtons()
    {
        btnEdit.Enabled = true;
        btnRemove.Enabled = true;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        OnAddClicked();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        OnEditClicked();
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        OnRemoveClicked();
    }

    private void OnAddClicked()
    {
        AddClicked?.Invoke(this, EventArgs.Empty);
    }

    private void OnEditClicked()
    {
        if (GetSelectedItem() is { } item)
        {
            EditClicked?.Invoke(this, item);
        }
    }

    private void OnRemoveClicked()
    {
        if (GetSelectedItem() is { } item)
        {
            RemoveClicked?.Invoke(this, item);
        }
    }

    public void AddColumn(string title, string member)
    {
        using DataGridViewTextBoxColumn column = new()
        {
            DataPropertyName = member,
            HeaderText = title,
        };

        dgvManagedList.Columns.Add(column);
    }
}
