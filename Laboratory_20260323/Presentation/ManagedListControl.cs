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

    private void dgvManagedList_DataSourceChanged(object sender, EventArgs e)
    {
        OnDataSourceChanged();
    }

    private void dgvManagedList_SelectionChanged(object sender, EventArgs e)
    {
        OnSelectionChanged();
    }

    private void OnDataSourceChanged()
    {
        UpdateActionButtons();
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

        _ = dgvManagedList.Columns.Add(column);
    }

    private void dgvManagedList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        OnRowDoubleClicked(e.RowIndex);
    }

    private void OnRowDoubleClicked(int row)
    {
        if (GetRowItem(row) is { } item)
        {
            EditClicked?.Invoke(this, item);
        }
    }

    private object? GetRowItem(int row)
    {
        return row < 0 || row > dgvManagedList.RowCount ? null : dgvManagedList.Rows[row].DataBoundItem;
    }
}
