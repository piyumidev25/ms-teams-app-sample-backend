using Libraries.GraphAPIClient.Models;
using System.Collections.Generic;

namespace TestWebAppToShowTeams.Models
{
    public class LoggedUserTeamsViewModel
    {
        public UserInfo UserInfo { get; set; }
        public List<JoinedTeamViewModel> JoinedTeamsInfo { get; set; }
        public LoggedUserTeamsViewModel(UserInfo userInfo, List<JoinedTeamViewModel> joinedTeamsInfo)
        {
            UserInfo = userInfo;
            JoinedTeamsInfo = joinedTeamsInfo;
        }
    }
}
