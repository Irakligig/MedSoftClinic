using MedsoftClinic.Data;
using MedsoftClinic.Models;

namespace MedsoftClinic;

public partial class MainForm : Form
{
    private readonly PatientRepository _patientRepository = new PatientRepository();

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        LoadPatients();
    }

    private void LoadPatients()
    {
        try
        {
            var patients = _patientRepository.GetAll();
            dgvPatients.DataSource = patients;

            // Hide unwanted columns
            dgvPatients.Columns["FullName"].Visible = false;
            dgvPatients.Columns["GenderID"].Visible = false;

            // Georgian headers
            dgvPatients.Columns["ID"].HeaderText = "ID";
            dgvPatients.Columns["LastName"].HeaderText = "გვარი";
            dgvPatients.Columns["FirstName"].HeaderText = "სახელი";
            dgvPatients.Columns["Dob"].HeaderText = "დაბადების თარიღი";
            dgvPatients.Columns["Dob"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvPatients.Columns["GenderName"].HeaderText = "სქესი";
            dgvPatients.Columns["Phone"].HeaderText = "მობილურის ნომერი";
            dgvPatients.Columns["Address"].HeaderText = "მისამართი";

            // Column order
            dgvPatients.Columns["ID"].DisplayIndex = 0;
            dgvPatients.Columns["LastName"].DisplayIndex = 1;
            dgvPatients.Columns["FirstName"].DisplayIndex = 2;
            dgvPatients.Columns["Dob"].DisplayIndex = 3;
            dgvPatients.Columns["GenderName"].DisplayIndex = 4;
            dgvPatients.Columns["Phone"].DisplayIndex = 5;
            dgvPatients.Columns["Address"].DisplayIndex = 6;

            // Column widths
            dgvPatients.Columns["ID"].Width = 40;
            dgvPatients.Columns["LastName"].Width = 120;
            dgvPatients.Columns["FirstName"].Width = 120;
            dgvPatients.Columns["Dob"].Width = 110;
            dgvPatients.Columns["GenderName"].Width = 100;
            dgvPatients.Columns["Phone"].Width = 110;
            dgvPatients.Columns["Address"].Width = 110;
        }
        catch (Exception ex)
        {
            MessageBox.Show("მონაცემების ჩატვირთვისას მოხდა შეცდომა: " + ex.Message,
                "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        PatientEditForm form = new PatientEditForm();

        if (form.ShowDialog() == DialogResult.OK)
        {
            LoadPatients();
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvPatients.SelectedRows.Count == 0)
        {
            MessageBox.Show("აირჩიეთ პაციენტი");
            return;
        }

        int id = Convert.ToInt32(
            dgvPatients.SelectedRows[0].Cells["ID"].Value
        );

        PatientEditForm form = new PatientEditForm(id);

        if (form.ShowDialog() == DialogResult.OK)
        {
            LoadPatients();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvPatients.SelectedRows.Count == 0)
        {
            MessageBox.Show("აირჩიეთ პაციენტი.");
            return;
        }

        int id = Convert.ToInt32(
            dgvPatients.SelectedRows[0].Cells["ID"].Value
        );

        DialogResult result = MessageBox.Show(
            "გსურთ მონიშნული ჩანაწერის წაშლა?",
            "დადასტურება",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                _patientRepository.Delete(id);

                LoadPatients();

                MessageBox.Show("ჩანაწერი წარმატებით წაიშალა.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadPatients();
    }

    private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}