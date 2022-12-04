using Libraries.GraphAPIClient.Models;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.GraphAPIClient
{
    public class GraphAPIClient: IGraphAPIClient
    {
        private readonly GraphServiceClient _graphServiceClient;

        public GraphAPIClient(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }

        public async Task<List<JoinedTeamInfo>> GetJoinedTeamsAsync()
        {
            var joinedTeamsWithMembers = new List<JoinedTeamInfo>();
            var joinedTeams = new List<Team>();
            try
            {
                //get joined teams of the user
                var joinedTeamsCollectionPage = await _graphServiceClient.Me.JoinedTeams.Request().GetAsync();
                var pageIterator = PageIterator<Team>
                               .CreatePageIterator(_graphServiceClient, joinedTeamsCollectionPage, (@team) =>
                               {
                                   joinedTeams.Add(@team);
                                   return true;
                               });
                await pageIterator.IterateAsync();
                foreach (var team in joinedTeams)
                {
                    var teamMembers = new List<ConversationMember>();
                    //get team members
                    var teamMembersCollectionPage = await _graphServiceClient.Teams[team.Id].Members.Request().Select("id, displayName, roles").GetAsync();
                    var pageIterator2 = PageIterator<ConversationMember>
                              .CreatePageIterator(_graphServiceClient, teamMembersCollectionPage, (@onversationMember) =>
                              {
                                  teamMembers.Add(@onversationMember);
                                  return true;
                              });
                    await pageIterator2.IterateAsync();

                    var members = new List<TeamMemberInfo>();
                    foreach (var member in teamMembers)
                    {
                        members.Add(new TeamMemberInfo(member.Id, member.DisplayName, member.Roles.ToList()));
                    }

                    joinedTeamsWithMembers.Add(new JoinedTeamInfo(team.Id, team.DisplayName, members));
                }
                return joinedTeamsWithMembers;
            }
            catch (ServiceException)
            {
                throw;
            }
        }

        public async Task<UserInfo> GetUserAsync()
        {
            try
            {
                var currentLoggedUser = await _graphServiceClient.Me.Request().GetAsync();
                return new UserInfo(currentLoggedUser.DisplayName, currentLoggedUser.Department, currentLoggedUser.CompanyName, currentLoggedUser.UserPrincipalName);
            }
            catch (ServiceException)
            {
                throw;
            }
        }
    }
}
