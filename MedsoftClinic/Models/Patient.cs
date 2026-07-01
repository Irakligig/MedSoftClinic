namespace MedsoftClinic.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public int GenderID { get; set; }
        public string GenderName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string LastName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FullName)) return string.Empty;
                var parts = FullName.Trim().Split(new[] { ' ' }, 2);
                return parts[0];
            }
        }

        public string FirstName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FullName)) return string.Empty;
                var parts = FullName.Trim().Split(new[] { ' ' }, 2);
                return parts.Length > 1 ? parts[1] : string.Empty;
            }
        }

        public static string ComposeFullName(string lastName, string firstName)
        {
            return $"{lastName.Trim()} {firstName.Trim()}";
        }
    }
}