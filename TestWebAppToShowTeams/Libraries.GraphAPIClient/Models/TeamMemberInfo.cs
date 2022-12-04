using System.Collections.Generic;

namespace Libraries.GraphAPIClient.Models
{
    public class TeamMemberInfo
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public List<string> Roles { get; set; }
        public TeamMemberInfo(string id, string displayName, List<string> roles)
        {
            Id = id;
            DisplayName = displayName;
            Roles = roles;
        }
    }
}
