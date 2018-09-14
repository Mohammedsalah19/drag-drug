using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
namespace WepApi
{

    // this class explain how use https rather than http
    public class REquiredHttpsAttribute:AuthorizationFilterAttribute
    {

        //public override void OnAuthorization(HttpActionContext actionContext)
        //{

        //    if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
        //    {

        //        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Found);
        //        actionContext.Response.Content = new StringContent("You have to use https not http");

        //        UriBuilder uribuilder = new UriBuilder(actionContext.Request.RequestUri);
        //        uribuilder.Scheme = Uri.UriSchemeHttps;
        //        uribuilder.Port = 44385;
        //        actionContext.Response.Headers.Location = uribuilder.Uri;

        //    }
        //    else
        //    {
        //        base.OnAuthorization(actionContext);
        //    }
        //}
    }
}