# What is AzureSearchRestAPISample?
This REST API sample for Azure Search have below feacture.
- Get an Indexer status

## If you use this sample at Azure Function
Please reference below files. 
### run.csx 
```csharp:run.csx
using Microsoft.Azure.Search;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// REST API URL template of https://msdn.microsoft.com/en-us/library/azure/dn798935.aspx
const string INDEXER_STATUS_URL = @"https://{0}.search.windows.net/indexers/{1}/status?api-version={2}";

//Please change below variables for your environment
const string SERVICE_NAME = "[your azure search service name]";
const string ADMIN_KEY = "[your admin key]";
const string INDEXER_NAME = "[your indexer name]";
const string API_VERSION = "2015-02-28";

// Please read https://www.infoq.com/news/2016/09/HttpClient
readonly static HttpClient httpClient = new HttpClient();

public static void Run(TimerInfo myTimer, TraceWriter log)
{
    log.Info("Get, last indexer update status...\n");
    httpClient.DefaultRequestHeaders.Add("api-key", ADMIN_KEY);
    var task = httpClient.GetStringAsync(string.Format(INDEXER_STATUS_URL, SERVICE_NAME, INDEXER_NAME, API_VERSION));
    task.Wait();
    var status = JsonConvert.DeserializeObject<AzureSearchIndexerStatus>(task.Result);
    log.Info( string.Format("last indexer upadte of {0} was {1} at {2}.", status.name, status.lastResult.status, status.lastResult.endTime) );
}

public class AzureSearchIndexerStatus
{
    public string odatacontext { get; set; }
    public string name { get; set; }
    public string status { get; set; }
    public Lastresult lastResult { get; set; }
    public Executionhistory[] executionHistory { get; set; }
}

public class Lastresult
{
    public string status { get; set; }
    public object errorMessage { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public object[] errors { get; set; }
    public int itemsProcessed { get; set; }
    public int itemsFailed { get; set; }
    public string initialTrackingState { get; set; }
    public string finalTrackingState { get; set; }
}

public class Executionhistory
{
    public string status { get; set; }
    public object errorMessage { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public object[] errors { get; set; }
    public int itemsProcessed { get; set; }
    public int itemsFailed { get; set; }
    public string initialTrackingState { get; set; }
    public string finalTrackingState { get; set; }
}
```

### project.json
```json:project.json
{
  "frameworks": {
    "net46":{
      "dependencies": {
        "Microsoft.Azure.Search": "1.1.3",
        "Newtonsoft.Json": "7.0.1"
      }
    }
   }
}
```
