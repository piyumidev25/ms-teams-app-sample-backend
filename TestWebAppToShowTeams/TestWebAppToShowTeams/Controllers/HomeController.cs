using Libraries.DBClient;
using Libraries.GraphAPIClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppToShowTeams.Models;

namespace TestWebAppToShowTeams.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGraphAPIClientFactory _graphAPIClientFactory;
        private static IRepositoryWrapper _repositoryWrapper;

        public HomeController(ILogger<HomeController> logger, IGraphAPIClientFactory graphAPIClientFactory, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _graphAPIClientFactory = graphAPIClientFactory;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var token = HttpContext.Session.GetString("MSAuthToken");
                if (!string.IsNullOrEmpty(token))
                {
                    var graphAPIClient = _graphAPIClientFactory.CreateClient(token);
                    //retrieve current logged user details
                    var loggedUser = await graphAPIClient.GetUserAsync();
                    //check if user is in DB
                    if (!_repositoryWrapper.AADUserRepository.IsUserExists(loggedUser.Email))
                    {
                        //save user
                        _repositoryWrapper.AADUserRepository.SaveUser(loggedUser.DisplayName, loggedUser.Email, loggedUser.Company, loggedUser.Department);
                        await _repositoryWrapper.SaveAsync();
                                        
                    }
                    //retrieve all joined teams
                    var joinedTeamsWithMembers = await graphAPIClient.GetJoinedTeamsAsync();
                    var joinedTeamsInfo = new List<JoinedTeamViewModel>();
                    foreach (var item in joinedTeamsWithMembers)
                    {
                        var memberList = item.Members.FindAll(x => !x.Roles.Contains("owner")).Select(x => x.DisplayName).ToArray();
                        var ownerList = item.Members.FindAll(x => x.Roles.Contains("owner")).Select(x => x.DisplayName).ToArray();
                        joinedTeamsInfo.Add(new JoinedTeamViewModel(item.DisplayName, string.Join(",", memberList), string.Join(",", ownerList)));
                    } 
                    var teamsInfo = new LoggedUserTeamsViewModel(loggedUser, joinedTeamsInfo);
                
                    return View(teamsInfo);
                }
                else
                {
                    return RedirectToAction("Index", "Auth");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
