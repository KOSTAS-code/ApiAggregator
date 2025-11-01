using ApiAggregator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAggregator.Tests.Fakes
{
    public class FakeNewsService : NewsService
    {
        public override async Task<object> GetDataAsync()
        {
            await Task.Delay(1);
            return new { Source = "News", Headlines = new[] { "Test headline" } };
        }
    }
}
