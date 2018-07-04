using EvoClientSPA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EvoClientSPA.APIServices
{
    [InheritedExport]
    public interface IPersonClientAPIAdapter //: IAdapter
    {
     
        HttpResponseMessage GetResponseFromAPI(string Id = null);

        Task<HttpResponseMessage> PostToAPI(PersonVM model);


        HttpResponseMessage EditPerson(int Id, PersonVM model);

        HttpResponseMessage DeleteToAPI(string Id, PersonVM model);
        
    }

}