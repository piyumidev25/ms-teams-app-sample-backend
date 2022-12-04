namespace TestWebAppToShowTeams.Models
{
    public class JoinedTeamViewModel
    {
        public string DisplayName { get; set; }
        public string Members { get; set; }
        public string Owners { get; set; }
        public JoinedTeamViewModel(string displayName, string members, string owners)
        {
            DisplayName = displayName;
            Members = members;
            Owners = owners;
        }
    }
}
