namespace MedsoftClinic;

partial class PatientEditForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        label1 = new Label();
        txtLastName = new TextBox();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        label6 = new Label();
        txtFirstName = new TextBox();
        txtPhone = new TextBox();
        dtpDob = new DateTimePicker();
        cmbGender = new ComboBox();
        txtAddress = new TextBox();
        btnSave = new Button();
        btnCancel = new Button();
        SuspendLayout();

        // label1
        label1.AutoSize = true;
        label1.Location = new Point(306, 23);
        label1.Name = "label1";
        label1.Size = new Size(45, 15);
        label1.TabIndex = 0;
        label1.Text = "გვარი:";

        // txtLastName
        txtLastName.Location = new Point(385, 20);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(249, 23);
        txtLastName.TabIndex = 1;

        // label2
        label2.AutoSize = true;
        label2.Location = new Point(295, 100);
        label2.Name = "label2";
        label2.Size = new Size(56, 15);
        label2.TabIndex = 2;
        label2.Text = "სახელი:";

        // label3
        label3.AutoSize = true;
        label3.Location = new Point(221, 176);
        label3.Name = "label3";
        label3.Size = new Size(130, 15);
        label3.TabIndex = 3;
        label3.Text = "დაბადების თარიღი:";

        // label4
        label4.AutoSize = true;
        label4.Location = new Point(308, 257);
        label4.Name = "label4";
        label4.Size = new Size(43, 15);
        label4.TabIndex = 4;
        label4.Text = "სქესი:";

        // label5
        label5.AutoSize = true;
        label5.Location = new Point(217, 437);
        label5.Name = "label5";
        label5.Size = new Size(134, 15);
        label5.TabIndex = 5;
        label5.Text = "მობილურის ნომერი:";

        // label6
        label6.AutoSize = true;
        label6.Location = new Point(274, 347);
        label6.Name = "label6";
        label6.Size = new Size(77, 15);
        label6.TabIndex = 6;
        label6.Text = "მისამართი:";

        // txtFirstName
        txtFirstName.Location = new Point(385, 92);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(249, 23);
        txtFirstName.TabIndex = 7;

        // txtPhone
        txtPhone.Location = new Point(385, 437);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(249, 23);
        txtPhone.TabIndex = 11;

        // dtpDob
        dtpDob.Location = new Point(385, 168);
        dtpDob.Name = "dtpDob";
        dtpDob.Size = new Size(249, 23);
        dtpDob.TabIndex = 12;

        // cmbGender
        cmbGender.FormattingEnabled = true;
        cmbGender.Location = new Point(385, 257);
        cmbGender.Name = "cmbGender";
        cmbGender.Size = new Size(249, 23);
        cmbGender.TabIndex = 13;

        // txtAddress
        txtAddress.Location = new Point(385, 344);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(249, 23);
        txtAddress.TabIndex = 14;

        // btnSave
        btnSave.Location = new Point(385, 554);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(114, 38);
        btnSave.TabIndex = 16;
        btnSave.Text = "შენახვა";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;


        // btnCancel
        btnCancel.Location = new Point(522, 554);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(112, 38);
        btnCancel.TabIndex = 17;
        btnCancel.Text = "გაუქმება";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;

        // PatientEditForm
        AutoScaleDimensions = new SizeF(7, 15);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1006, 653);

        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(txtAddress);
        Controls.Add(cmbGender);
        Controls.Add(dtpDob);
        Controls.Add(txtPhone);
        Controls.Add(txtFirstName);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(txtLastName);
        Controls.Add(label1);

        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PatientEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "პაციენტის დამატება";

        Load += PatientEditForm_Load;

        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox txtLastName;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private TextBox txtFirstName;
    private TextBox txtPhone;
    private DateTimePicker dtpDob;
    private ComboBox cmbGender;
    private TextBox txtAddress;
    private Button btnSave;
    private Button btnCancel;
}