using EvoClientSPA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EvoClientSPA.APIServices
{
    public class PersonClientAPIAdapter : IPersonClientAPIAdapter
    {
        private string WebAPIurl
        {
            get { return ConfigurationManager.AppSettings["WebApiurl"]; }
        }

        private HttpResponseMessage response = null;

        public HttpResponseMessage GetResponseFromAPI(string Id = null)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (Id == null)
                { response = client.GetAsync(new Uri(WebAPIurl)).Result; }
                else
                { response = client.GetAsync(string.Concat(new Uri(WebAPIurl), "/", Id)).Result; }
            }
            return response;
        }

        public async Task<HttpResponseMessage> PostToAPI(PersonVM model)
        {

            using (var client = new HttpClient())
            {
                var modelJSON = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(modelJSON, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new Uri(WebAPIurl), stringContent);
                return response;
            }
        }

        public HttpResponseMessage EditPerson(int Id, PersonVM model)
        {
            using (var client = new HttpClient())
            {
                var modelJSON = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(modelJSON, Encoding.UTF8, "application/json");
                response = client.PutAsync(string.Concat(new Uri(WebAPIurl), "/", Id), stringContent).Result;
            }
            return response;
        }

        public HttpResponseMessage DeleteToAPI(string Id, PersonVM model)
        {
            using (var client = new HttpClient())
            {
                response = client.DeleteAsync(string.Concat(new Uri(WebAPIurl), "/", Id)).Result;
            }
            return response;
        }
    }
    //internal static class PersonClientAPI
    //{
    //    private static string WebAPIurl
    //    {
    //        get { return ConfigurationManager.AppSettings["WebApiurl"]; }
    //    }

    //    private static HttpResponseMessage response = null;

    //    internal static HttpResponseMessage GetResponseFromAPI(string Id = null)
    //    {
    //        using (var client = new HttpClient())
    //        {
    //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //            if (Id == null)
    //            { response = client.GetAsync(new Uri(WebAPIurl)).Result; }
    //            else
    //            { response = client.GetAsync(string.Concat(new Uri(WebAPIurl),"/",Id)).Result; }
    //        }
    //        return response;
    //    }

    //    internal static async Task<HttpResponseMessage> PostToAPI(PersonVM model)
    //    {

    //        using (var client = new HttpClient())
    //        {
    //            var modelJSON = JsonConvert.SerializeObject(model);
    //            var stringContent = new StringContent(modelJSON, Encoding.UTF8, "application/json");
    //            var response = await client.PostAsync(new Uri(WebAPIurl), stringContent);
    //            return response;
    //        }
    //    }

    //    internal static HttpResponseMessage EditPerson(int Id, PersonVM model)
    //    {
    //        using (var client = new HttpClient())
    //        {
    //            var modelJSON = JsonConvert.SerializeObject(model);
    //            var stringContent = new StringContent(modelJSON, Encoding.UTF8, "application/json");
    //            response = client.PutAsync(string.Concat(new Uri(WebAPIurl),"/",Id), stringContent).Result;
    //        }
    //        return response;
    //    }

    //    internal static HttpResponseMessage DeleteToAPI(string Id, PersonVM model)
    //    {
    //        using (var client = new HttpClient())
    //        {
    //            response = client.DeleteAsync(string.Concat(new Uri(WebAPIurl),"/",Id)).Result;
    //        }
    //        return response;
    //    }
    //}

}