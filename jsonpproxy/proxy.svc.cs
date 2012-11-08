using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using System.Net;
using System.IO;

namespace JSONPproxy
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProxyService 
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string Hello()
        {
            return "Hello World!";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string GrabHtml(string url)
        {
            WebRequest req = WebRequest.Create(url);
            using (WebResponse rsp = req.GetResponse())
            {
                using (StreamReader sr = new StreamReader(rsp.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        
    }
}
