using Libraries.GraphAPIClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libraries.GraphAPIClient
{
    public interface IGraphAPIClient
    {
        Task<UserInfo> GetUserAsync();
        Task<List<JoinedTeamInfo>> GetJoinedTeamsAsync();
    }
}
