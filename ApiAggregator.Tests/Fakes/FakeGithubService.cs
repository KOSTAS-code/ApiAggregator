using ApiAggregator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAggregator.Tests.Fakes
{
    public class FakeGithubService : GithubService
    {
        public override async Task<object> GetDataAsync()
        {
            await Task.Delay(1);
            return new { Source = "GitHub", Repo = "fake-repo" };
        }
    }
}
