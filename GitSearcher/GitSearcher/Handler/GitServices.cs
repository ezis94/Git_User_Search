using System;
using System.Collections.Generic;
using System.Text;
using GitSearcher.Models;
using GitSearcher.GitRestClient;
using System.Threading.Tasks;

namespace GitSearcher.Handler
{
    //The handler of Git Search task
    class GitServices
    {
        GetSearchResults<UserModel> _GitRest = new GetSearchResults<UserModel>();
        public async Task<UserModel> GetGitDetails(string query)
        {
            var getUserDetails = await _GitRest.GetAllUsers(query);
            return getUserDetails;
        }
    }
}
