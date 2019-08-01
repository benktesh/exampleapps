
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;


public class Message
{
    public String Key { get; set; }
    public String Value { get; set; }
}

public class Test
{


    public static void Run(string myQueueItem)
    {
        //log.LogInformation($"Original Message {myQueueItem}");
        Message m = JsonConvert.DeserializeObject<Message>(myQueueItem);
       // log.LogInformation($"Key = {m.Key} - Value={m.Value}");

        //start a client
        var client = new HttpClient();
        //if the key is GetJoke, value is ignored as we will get directly from our site.
        if (m.Key.Equals("GetJoke", StringComparison.InvariantCultureIgnoreCase))
        {
            string url = "https://joke3.p.rapidapi.com/v1/joke";
            string jokeHost = "joke3.p.rapidapi.com";
            string jokeKey = "c812b07f3cmshbed411ccb96b811p1f9e2ajsncf4b1584d198";

            
      //"ClientIdValue": "e2df2768-5104-4137-904e-117f77a2b406",
      //"BaseUrl": "https://apigatewaydemo.cunamutual.com/cmfg/dev-int/lendingfolders/v1.0/",
      //"ServiceUrl": "",

      //"EnvironmentHeaderKey", "x-subdomain"
      //"EnvironmentValue", "llc5dvlp"


            client.BaseAddress = new Uri("https://apigatewaydemo.cunamutual.com/cmfg/dev-int/lendingfolders/v1.0/");
            client.DefaultRequestHeaders.Add("ClientIdHeaderKey", "X-IBM-Client-Id");
            client.DefaultRequestHeaders.Add("UserName", "SA-LendingProdSvcs-D");
            client.DefaultRequestHeaders.Add("Password", "w1NkjnTB8Vgx");
            client.DefaultRequestHeaders.Add("EnvironmentHeaderKey", "x-subdomain");
            client.DefaultRequestHeaders.Add("EnvironmentValue", "llc5dvlp");



         
            try
            {
                var response = client.GetAsync(url);
                //read the content
                var content = response.Result.Content.ReadAsStringAsync();
                //log the content
                //log.LogInformation(content.Result);
            }
            catch (Exception ex)
            {
               // log.LogInformation("Exception occured. \n" + ex.ToString());
            }
        }
        else
        {
            //for unrecognized key, log the information
            //log.LogInformation("Not implemented key " + m.Key);
        }
    }
}
