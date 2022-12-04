using Microsoft.Graph;
using System.Collections.Generic;

namespace Libraries.GraphAPIClient.Models
{
    public class JoinedTeamInfo
    {
        public  string Id { get; set; }
        public string DisplayName { get; set; }
        public List<TeamMemberInfo> Members { get; set; }
        public JoinedTeamInfo(string id, string displayName, List<TeamMemberInfo> members)
        {
            Id = id;
            DisplayName = displayName;
            Members = members;
        }
    }
}
