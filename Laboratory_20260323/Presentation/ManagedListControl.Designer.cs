namespace Laboratory_20260323.Presentation
{
    partial class ManagedListControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlcContainer = new TableLayoutPanel();
            pnlActions = new Panel();
            btnRemove = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvManagedList = new DataGridView();
            tlcContainer.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManagedList).BeginInit();
            SuspendLayout();
            // 
            // tlcContainer
            // 
            tlcContainer.ColumnCount = 2;
            tlcContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlcContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
            tlcContainer.Controls.Add(pnlActions, 1, 0);
            tlcContainer.Controls.Add(dgvManagedList, 0, 0);
            tlcContainer.Dock = DockStyle.Fill;
            tlcContainer.Location = new Point(0, 0);
            tlcContainer.Name = "tlcContainer";
            tlcContainer.RowCount = 1;
            tlcContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlcContainer.Size = new Size(300, 192);
            tlcContainer.TabIndex = 0;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnRemove);
            pnlActions.Controls.Add(btnEdit);
            pnlActions.Controls.Add(btnAdd);
            pnlActions.Dock = DockStyle.Fill;
            pnlActions.Location = new Point(175, 3);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(122, 186);
            pnlActions.TabIndex = 0;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRemove.Enabled = false;
            btnRemove.Location = new Point(3, 160);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(116, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnEdit.Enabled = false;
            btnEdit.Location = new Point(3, 32);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(116, 23);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit...";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(116, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add...";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvManagedList
            // 
            dgvManagedList.AllowUserToAddRows = false;
            dgvManagedList.AllowUserToDeleteRows = false;
            dgvManagedList.AllowUserToOrderColumns = true;
            dgvManagedList.AllowUserToResizeRows = false;
            dgvManagedList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManagedList.Dock = DockStyle.Fill;
            dgvManagedList.Location = new Point(3, 3);
            dgvManagedList.Name = "dgvManagedList";
            dgvManagedList.ReadOnly = true;
            dgvManagedList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvManagedList.Size = new Size(166, 186);
            dgvManagedList.TabIndex = 0;
            dgvManagedList.DataSourceChanged += dgvManagedList_DataSourceChanged;
            dgvManagedList.CellDoubleClick += dgvManagedList_CellDoubleClick;
            dgvManagedList.SelectionChanged += dgvManagedList_SelectionChanged;
            // 
            // ManagedListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlcContainer);
            MinimumSize = new Size(256, 96);
            Name = "ManagedListControl";
            Size = new Size(300, 192);
            tlcContainer.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvManagedList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlcContainer;
        private Panel pnlActions;
        private Button btnRemove;
        private Button btnEdit;
        private Button btnAdd;
        private DataGridView dgvManagedList;
    }
}
