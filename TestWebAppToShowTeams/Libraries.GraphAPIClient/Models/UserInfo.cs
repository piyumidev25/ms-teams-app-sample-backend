namespace Libraries.GraphAPIClient.Models
{
    public class UserInfo
    {
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }

        public UserInfo(string displayName, string department, string company, string email)
        {
            DisplayName = displayName;
            Department = department;
            Company = company;
            Email = email;
        }
    }
}
