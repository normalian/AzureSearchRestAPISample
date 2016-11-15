using Microsoft.Azure.Search;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AzureSearchRestAPISample
{
    class Program
    {
        // REST API URL template of https://msdn.microsoft.com/en-us/library/azure/dn798935.aspx
        const string INDEXER_STATUS_URL = @"https://{0}.search.windows.net/indexers/{1}/status?api-version={2}";

        //Please change below variables for your environment
        const string SERVICE_NAME = "[your azure search service name]";
        const string ADMIN_KEY = "[your admin key]";
        const string INDEXER_NAME = "[your indexer name]";
        const string API_VERSION = "2015-02-28";

        // Please read https://www.infoq.com/news/2016/09/HttpClient
        readonly static HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine("{0}", "Get, last indexer update status...\n");
            GetIndexerUpdateStatus();
            Console.ReadKey();
        }

        static async void GetIndexerUpdateStatus()
        {
            httpClient.DefaultRequestHeaders.Add("api-key", ADMIN_KEY);
            var result = await httpClient.GetStringAsync(string.Format(INDEXER_STATUS_URL, SERVICE_NAME, INDEXER_NAME, API_VERSION));
            var status = JsonConvert.DeserializeObject<AzureSearchIndexerStatus>(result);
            Console.WriteLine("last indexer upadte of {0} was {1} at {2}.", status.name, status.lastResult.status, status.lastResult.endTime);
        }
    }
}
