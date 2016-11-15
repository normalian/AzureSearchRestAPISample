using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSearchRestAPISample
{
    // This class was created from below REST API response
    // https://msdn.microsoft.com/en-us/library/azure/dn946884.aspx
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

}
