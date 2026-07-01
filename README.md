# MedSoft Clinic

A desktop patient management application for medical clinics, built with **.NET 8** and **Windows Forms**. The UI is in Georgian and supports full CRUD operations for patient records backed by **Microsoft SQL Server**.

## Features

- View all patients in a sortable grid
- Add, edit, and delete patient records
- Input validation for required fields and Georgian mobile phone numbers (9 digits, starting with `5`)
- Gender selection (male / female)
- Data access through SQL Server stored procedures

## Tech Stack

| Layer | Technology |
|-------|------------|
| UI | Windows Forms (.NET 8) |
| Language | C# |
| Database | Microsoft SQL Server |
| Data access | `Microsoft.Data.SqlClient` + stored procedures |

## Prerequisites

- [**.NET 8 SDK**](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Windows** (Windows Forms target: `net8.0-windows`)
- **SQL Server** (Express or full edition) with a database named `MedsoftClinic`
- **Visual Studio 2022** (recommended) or the .NET CLI

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/Irakligig/MedSoftClinic.git
cd MedSoftClinic
```

### 2. Configure the database connection

Update the connection string in `MedsoftClinic/Data/DatabaseHelper.cs` to match your SQL Server instance:

```csharp
private static readonly string ConnectionString =
    @"Data Source=YOUR_SERVER\SQLEXPRESS;Initial Catalog=MedsoftClinic;Integrated Security=True;TrustServerCertificate=True;";
```

Replace `YOUR_SERVER` with your machine name or server address.

### 3. Set up the database

Create a database named `MedsoftClinic` and deploy the required tables and stored procedures. The application expects at least:

**Patient table** (conceptual schema):

| Column | Type | Notes |
|--------|------|-------|
| `ID` | `int` | Primary key, identity |
| `FullName` | `nvarchar` | Last name and first name combined |
| `Dob` | `date` / `datetime` | Date of birth |
| `GenderID` | `int` | Foreign key to gender lookup |
| `Phone` | `nvarchar` | Optional; 9-digit Georgian mobile |
| `Address` | `nvarchar` | Optional |

**Stored procedures** used by the app:

| Procedure | Purpose |
|-----------|---------|
| `dbo.Patients_GetAll` | Returns all patients (includes `GenderName`) |
| `dbo.Patients_GetById` | Returns one patient by `@ID` |
| `dbo.Patients_Insert` | Inserts a patient; outputs `@NewID` |
| `dbo.Patients_Update` | Updates a patient by `@ID` |
| `dbo.Patients_Delete` | Deletes a patient by `@ID` |

Gender values referenced in the UI:

| `GenderID` | Label (Georgian) |
|------------|------------------|
| `1` | მამრობითი |
| `2` | მდედრობითი |

### 4. Build and run

**Visual Studio:** open `MedsoftClinic.sln`, restore NuGet packages, and press **F5**.

**Command line:**

```bash
dotnet restore MedsoftClinic.sln
dotnet build MedsoftClinic.sln
dotnet run --project MedsoftClinic/MedsoftClinic.csproj
```

## Project Structure

```
MedsoftClinic/
├── MedsoftClinic.sln          # Visual Studio solution
└── MedsoftClinic/
    ├── Program.cs             # Application entry point
    ├── MainForm.cs            # Patient list (grid + actions)
    ├── PatientEditForm.cs     # Add / edit patient dialog
    ├── Models/
    │   └── Patient.cs         # Patient entity
    └── Data/
        ├── DatabaseHelper.cs  # SQL connection factory
        └── PatientRepository.cs  # CRUD via stored procedures
```

## Usage

1. Launch the application; the main window loads the patient list from the database.
2. **Add** — open the patient form, fill in last name, first name, date of birth, gender, and optional phone/address, then save.
3. **Edit** — select a row and edit the selected patient.
4. **Delete** — select a row and confirm deletion.
5. **Refresh** — reload the grid from the database.

Phone numbers, when provided, must be exactly 9 digits and start with `5` (Georgian mobile format).

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes
4. Push to your fork and open a pull request

## License

This project is provided as-is for educational and clinic management purposes. Add a license file here if you intend to distribute it under specific terms.
