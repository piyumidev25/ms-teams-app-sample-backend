using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries.GraphAPIClient
{
    public interface IGraphAPIClientFactory
    {
        IGraphAPIClient CreateClient(string accessToken);
    }
}
