using Microsoft.Graph;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace GraphAPIClient.UnitTests
{
    public class Tests
    {
        private Mock<GraphServiceClient> _graphServiceClient;
        private Mock<IUserRequestBuilder> _mockUserRequestBuilder;
        private Mock<IUserRequest> _mockUserRequest;
        private Mock<IUserJoinedTeamsCollectionRequest> _mockUserJoinedTeamsCollectionRequest;
        private Mock<IUserJoinedTeamsCollectionRequestBuilder> _mockUserJoinedTeamsCollectionRequestBuilder;
        private Mock<ITeamMembersCollectionRequest> _mockTeamsMembersCollectionRequest;
        private Mock<ITeamMembersCollectionRequestBuilder> _mockTeamsMembersCollectionRequestBuilder;

        private User _user;

        [SetUp]
        public void Setup()
        {
            var mockAuthProvider = new Mock<IAuthenticationProvider>();
            var mockHttpProvider = new Mock<IHttpProvider>();

            _user = new User();
            _user.DisplayName = "Alex Wibe";
            _user.UserPrincipalName = "AlexW@4lqv33.onmicrosoft.com";
            _user.Id = Guid.NewGuid().ToString();

            var page = GetJoinedTeamsCollectionPage();
            var membersForTeams = GetTeamMembers();

            _mockUserRequestBuilder = new Mock<IUserRequestBuilder>();
            _graphServiceClient = new Mock<GraphServiceClient>(mockAuthProvider.Object, mockHttpProvider.Object);
            _mockUserRequest = new Mock<IUserRequest>();
            _mockUserJoinedTeamsCollectionRequest = new Mock<IUserJoinedTeamsCollectionRequest>();
            _mockUserJoinedTeamsCollectionRequestBuilder = new Mock<IUserJoinedTeamsCollectionRequestBuilder>();
            _mockTeamsMembersCollectionRequest = new Mock<ITeamMembersCollectionRequest>();
            _mockTeamsMembersCollectionRequestBuilder = new Mock<ITeamMembersCollectionRequestBuilder>();

            _mockUserRequest.Setup(x => x.GetAsync(CancellationToken.None)).ReturnsAsync(_user);
            _mockUserRequestBuilder.Setup(x => x.Request()).Returns(_mockUserRequest.Object);

            _mockUserJoinedTeamsCollectionRequest.Setup(x => x.GetAsync(CancellationToken.None)).ReturnsAsync(page);
            _mockUserJoinedTeamsCollectionRequestBuilder.Setup(x => x.Request()).Returns(_mockUserJoinedTeamsCollectionRequest.Object);

            _mockTeamsMembersCollectionRequest.Setup(x => x.GetAsync(CancellationToken.None)).ReturnsAsync(membersForTeams);
            _mockTeamsMembersCollectionRequest.Setup(x => x.Select(It.IsAny<Expression<Func<ConversationMember, object>>>())).Returns(_mockTeamsMembersCollectionRequest.Object);
            _mockTeamsMembersCollectionRequestBuilder.Setup(x => x.Request()).Returns(_mockTeamsMembersCollectionRequest.Object);

            _graphServiceClient.Setup(x => x.Me).Returns(_mockUserRequestBuilder.Object);
            _graphServiceClient.Setup(x => x.Me.JoinedTeams).Returns(_mockUserJoinedTeamsCollectionRequestBuilder.Object);
            _graphServiceClient.Setup(x => x.Teams[It.IsAny<string>()].Members).Returns(_mockTeamsMembersCollectionRequestBuilder.Object);
        }

        [Test] 
        public async Task TestGetUserAsync_ShouldReturn_ValidUser()
        {
            // Arrange
            var graphAPIClient = new Libraries.GraphAPIClient.GraphAPIClient(_graphServiceClient.Object);
            var regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            //Act
            var user = await graphAPIClient.GetUserAsync();
            //Assert
            Assert.That(user, Is.Not.Null);
            Assert.That(user.DisplayName, Is.Not.Null);
            Assert.That(user.DisplayName, Is.Not.Empty);
            Assert.That(user.Email, Is.Not.Null);
            Assert.That(user.Email, Is.Not.Empty);
            Assert.IsTrue(Regex.IsMatch(user.Email, regex, RegexOptions.IgnoreCase));
        }

        [Test]
        public async Task TestGetJoinedTeamsAsync_ShouldReturn_TeamsWithMembers()
        {
            // Arrange
            var graphAPIClient = new Libraries.GraphAPIClient.GraphAPIClient(_graphServiceClient.Object);
            
            //Act
            var joinedTeams = await graphAPIClient.GetJoinedTeamsAsync();
            //Assert
            Assert.That(joinedTeams, Is.Not.Null);
            Assert.That(joinedTeams.Count, Is.GreaterThanOrEqualTo(0));
        }

        private IUserJoinedTeamsCollectionPage GetJoinedTeamsCollectionPage()
        {
            var page = new UserJoinedTeamsCollectionPage
            {
                AdditionalData = new Dictionary<string, object>()
            };
            page.Add(new Team
            {
                AdditionalData = new Dictionary<string, object>(),
                DisplayName = "TestTeam 1",
                Id = Guid.NewGuid().ToString()
            });
            page.Add(new Team
            {
                AdditionalData = new Dictionary<string, object>(),
                DisplayName = "TestTeam 2",
                Id = Guid.NewGuid().ToString()
            });
            page.Add(new Team
            {
                AdditionalData = new Dictionary<string, object>(),
                DisplayName = "TestTeam 3",
                Id = Guid.NewGuid().ToString()
            });
            return page;
        }
        private ICollectionPage<ConversationMember> GetTeamMembers()
        {
            var page = new CollectionPage<ConversationMember>
            {
                AdditionalData = new Dictionary<string, object>()
            };
            page.Add(new ConversationMember
            {

            })
            return page;
        }
    }
}