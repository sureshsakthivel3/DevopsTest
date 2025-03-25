using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace iAMSWebCore.Controllers
{
    public class BaseController : Controller
    {
        private IConfiguration _configuration;
        private HttpClient client;
        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new HttpClient();
            Uri baseAddress = new Uri(_configuration["iamswebapiurl"]);
            client.BaseAddress = baseAddress;
        }
        public string GetResult(string actionName)
        {
            string result = string.Empty;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + actionName).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }

        public string PostResult(string actionName, dynamic model)
        {
            string result = string.Empty;
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress + actionName, content).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                result = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return result;
        }

        public string PostResult(string actionName, string model)
        {
            string result = string.Empty;
            StringContent content = new StringContent(model, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress + actionName, content).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                result = responseMessage.Content.ReadAsStringAsync().Result;
            }
            return result;
        }

        public List<T> Json2List<T>(string result,string listname)
        {
            JObject jObject = JObject.Parse(result);
            List<JToken> jTokenList = jObject.GetValue(listname).ToList();
            List<T> LstT = new List<T>();
            foreach (JToken jt in jTokenList)
            {
                T obj = jt.ToObject<T>();
                LstT.Add(obj);
            }
            return LstT;
        }
    }
}
