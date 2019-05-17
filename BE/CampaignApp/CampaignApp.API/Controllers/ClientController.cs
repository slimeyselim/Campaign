using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CampaignApp.Business;
using CampaignApp.Data;
using CampaignApp.Data.Entities;


namespace CampaignApp.API.Controllers
{
    public class ClientController : ApiController
    {
        private CampaignContextDb db = new CampaignContextDb();
        private GetClients get = new GetClients();

        public HttpResponseMessage Get()
        {
            try
            {
                List<Client> clients = get.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, clients);
            }
            catch (Exception exception)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }
        }
    }
}