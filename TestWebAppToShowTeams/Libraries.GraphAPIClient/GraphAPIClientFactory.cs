using Microsoft.Graph;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Libraries.GraphAPIClient
{
    public class GraphAPIClientFactory: IGraphAPIClientFactory
    {
        public IGraphAPIClient CreateClient(string accessToken)
        {
            var graphServiceClient = new GraphServiceClient(new DelegateAuthenticationProvider((requestMessage) =>
            {
                requestMessage
                    .Headers
                    .Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                return Task.FromResult(0);
            }));
            return new GraphAPIClient(graphServiceClient);
        }
    }
}
