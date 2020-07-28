using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ApiGetway
{
    public class DashboardAggregator : IDefinedAggregator
    {

        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var contentBuilder = new StringBuilder();

            var responseKeys = responses.Select(s => s.Items.DownstreamRoute().Key).Distinct().ToList();
            contentBuilder.AppendLine("{");
            for (var k = 0; k < responseKeys.Count; k++)
            {
                var contexts = responses.Where(w => w.Items.DownstreamRoute().Key == responseKeys[k]).ToList();

                var content = await contexts[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
                if (k != 0)
                    contentBuilder.AppendLine(",");

                contentBuilder.Append($"\"{responseKeys[k]}\":{content}");
            }
            contentBuilder.AppendLine("}");

            var stringContent = new StringContent(contentBuilder.ToString())
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }
    }
}
