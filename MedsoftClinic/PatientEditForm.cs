using System;
using System.Linq;
using System.Windows.Forms;
using MedsoftClinic.Data;
using MedsoftClinic.Models;

namespace MedsoftClinic;

public partial class PatientEditForm : Form
{
    private int? _patientId;

    private readonly PatientRepository _patientRepository = new PatientRepository();


    public PatientEditForm()
    {
        InitializeComponent();
    }


    public PatientEditForm(int patientId)
    {
        InitializeComponent();
        _patientId = patientId;
    }


    private void PatientEditForm_Load(object sender, EventArgs e)
    {
        LoadGenders();

        if (_patientId.HasValue)
        {
            LoadPatient(_patientId.Value);
            Text = "პაციენტის რედაქტირება";
        }
        else
        {
            Text = "პაციენტის დამატება";
        }
    }


    private void LoadGenders()
    {
        cmbGender.Items.Clear();

        cmbGender.Items.Add(new GenderItem
        {
            GenderID = 1,
            GenderName = "მამრობითი"
        });

        cmbGender.Items.Add(new GenderItem
        {
            GenderID = 2,
            GenderName = "მდედრობითი"
        });

        cmbGender.DisplayMember = "GenderName";

        cmbGender.SelectedIndex = -1;
    }


    private void LoadPatient(int id)
    {
        Patient patient = _patientRepository.GetById(id);

        if (patient == null)
            return;


        string[] names = patient.FullName.Split(' ');


        txtLastName.Text = names.Length > 0 ? names[0] : "";

        txtFirstName.Text = names.Length > 1 ? names[1] : "";


        dtpDob.Value = patient.Dob;


        foreach (GenderItem item in cmbGender.Items)
        {
            if (item.GenderID == patient.GenderID)
            {
                cmbGender.SelectedItem = item;
                break;
            }
        }


        txtPhone.Text = patient.Phone ?? "";

        txtAddress.Text = patient.Address ?? "";
    }


    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            MessageBox.Show("შეიყვანეთ გვარი");
            return false;
        }


        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            MessageBox.Show("შეიყვანეთ სახელი");
            return false;
        }


        if (cmbGender.SelectedIndex == -1)
        {
            MessageBox.Show("აირჩიეთ სქესი");
            return false;
        }


        if (!string.IsNullOrWhiteSpace(txtPhone.Text))
        {
            string phone = txtPhone.Text;


            if (!phone.StartsWith("5") ||
                phone.Length != 9 ||
                !phone.All(char.IsDigit))
            {
                MessageBox.Show(
                    "მობილურის ნომერი უნდა იწყებოდეს 5-ით და შეიცავდეს 9 ციფრს"
                );

                return false;
            }
        }


        return true;
    }



    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs())
            return;


        Patient patient = new Patient
        {
            ID = _patientId ?? 0,

            FullName =
                txtLastName.Text.Trim()
                + " "
                + txtFirstName.Text.Trim(),

            Dob = dtpDob.Value.Date,

            GenderID = ((GenderItem)cmbGender.SelectedItem).GenderID,

            Phone = string.IsNullOrWhiteSpace(txtPhone.Text)
                ? null
                : txtPhone.Text.Trim(),

            Address = string.IsNullOrWhiteSpace(txtAddress.Text)
                ? null
                : txtAddress.Text.Trim()
        };


        try
        {
            if (_patientId.HasValue)
            {
                _patientRepository.Update(patient);

                MessageBox.Show("პაციენტი განახლდა");
            }
            else
            {
                _patientRepository.Insert(patient);

                MessageBox.Show("პაციენტი დაემატა");
            }


            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }



    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}



public class GenderItem
{
    public int GenderID { get; set; }

    public string GenderName { get; set; }
}