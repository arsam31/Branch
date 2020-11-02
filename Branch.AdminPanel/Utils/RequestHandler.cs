using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Branch.AdminPanel.Utils
{
    public class RequestHandler
    {
        private HttpClient httpClient = null;
        public RequestHandler()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44335/api");
            var key = "SigningKey";
            var value = "Paris Berlin Cairo Sydney Tokyo Beijing Rome London Athens";
            httpClient.DefaultRequestHeaders.Add(key, value);
        }

        public async Task<T> HandelPOSTRequest<T>(string hostURL, dynamic parameterBody, string token) where T : class
        {
            
            try
            {
                // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await httpClient. PostAsync(hostURL, new StringContent(JsonConvert.SerializeObject(parameterBody), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    JObject rootObj = JObject.Parse(await response.Content.ReadAsStringAsync());
                    var Result = JsonConvert.DeserializeObject<T>(rootObj.ToString());

                    if (Result != null)
                    {
                        return Result;
                    }
                    else
                    {
                        return "OK" as T;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<T> HandelGETRequest<T>(string hostURL, string token, long Id) where T : class
        {
            try
            {
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                if (Id != 0)
                {
                    hostURL = hostURL + "?Id=" + Id;
                }
                HttpResponseMessage response = await httpClient.GetAsync(hostURL);
                if (response.IsSuccessStatusCode)
                {
                    //JObject rootObj = JObject.Parse(await response.Content.ReadAsStringAsync());
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }



        //public static HttpClient GetClient(string Email, string Password)
        //{
        //    var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Email}:{Password}")));

        //    var client = new HttpClient()
        //    {
        //        DefaultRequestHeaders = { Authorization = authValue }
        //        //Set some other client defaults like timeout / BaseAddress
        //    };
        //    return client;
        //}


        //public static HttpClient GetClient(string token)
        //{
        //    var authValue = new AuthenticationHeaderValue("Bearer", token);

        //    var client = new HttpClient()
        //    {
        //        DefaultRequestHeaders = { Authorization = authValue }
        //        //Set some other client defaults like timeout / BaseAddress
        //    };
        //    return client;
        //}
    }
}



        

//        public async Task<T> HandelPutRequest<T>(string hostURL, dynamic parameterBody, string token, string UserId = "") where T : class
//        {
//            try
//            {

//                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//                if (UserId != "")
//                {
//                    hostURL = hostURL + "?UserId=" + UserId;
//                }

//                HttpResponseMessage response = await httpClient.PutAsync(hostURL, new StringContent(JsonConvert.SerializeObject(parameterBody)));
//                if (response.IsSuccessStatusCode)
//                {
//                    var aa = await response.Content.ReadAsStringAsync();
//                    JObject rootObj = JObject.Parse(await response.Content.ReadAsStringAsync());
//                      var d=  rootObj["result"]["items"];
//                    if (UserId != "")
//                    {
//                        return JsonConvert.DeserializeObject<T>(rootObj["result"].ToString());
//                    }

//                }
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//            return null;
//        }

//    }
//}