namespace MedsoftClinic;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dgvPatients = new DataGridView();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        btnRefresh = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
        SuspendLayout();
        // 
        // dgvPatients
        // 
        dgvPatients.AllowUserToAddRows = false;
        dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPatients.Location = new Point(74, 82);
        dgvPatients.MultiSelect = false;
        dgvPatients.Name = "dgvPatients";
        dgvPatients.ReadOnly = true;
        dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPatients.Size = new Size(963, 389);
        dgvPatients.TabIndex = 1;
        dgvPatients.CellContentClick += dgvPatients_CellContentClick;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(162, 642);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(107, 49);
        btnAdd.TabIndex = 2;
        btnAdd.Text = "დამატება";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnEdit
        // 
        btnEdit.Location = new Point(376, 642);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(138, 49);
        btnEdit.TabIndex = 3;
        btnEdit.Text = "რედაქტირება";
        btnEdit.UseVisualStyleBackColor = true;
        btnEdit.Click += btnEdit_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(619, 642);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(117, 49);
        btnDelete.TabIndex = 4;
        btnDelete.Text = "წაშლა";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.Location = new Point(842, 642);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(107, 49);
        btnRefresh.TabIndex = 5;
        btnRefresh.Text = "განახლება";
        btnRefresh.UseVisualStyleBackColor = true;
        btnRefresh.Click += btnRefresh_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1119, 760);
        Controls.Add(btnRefresh);
        Controls.Add(btnDelete);
        Controls.Add(btnEdit);
        Controls.Add(btnAdd);
        Controls.Add(dgvPatients);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "პაციენტების მართვა - MEDSOFT.GE";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvPatients;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnRefresh;
}
