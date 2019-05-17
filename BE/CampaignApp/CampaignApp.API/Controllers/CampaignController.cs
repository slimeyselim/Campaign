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
    public class CampaignController : ApiController
    {
        private CampaignContextDb db = new CampaignContextDb();
        private GetCampaigns get = new GetCampaigns();
        private EditCampaign edit = new EditCampaign();
        private AddCampaign add = new AddCampaign();
        private DeleteCampaign delete = new DeleteCampaign();


        public HttpResponseMessage Get()
        {
            try
            {
                List<Campaign> campaigns = get.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, campaigns); 
            }
            catch (Exception exception)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }
        }

        public HttpResponseMessage Put(int id,[FromBody] string campaignName)
        {
            try
            {
                HttpStatusCode result = edit.Edit(id, campaignName);
                if (result == HttpStatusCode.Accepted)
                {
                    return Request.CreateResponse(HttpStatusCode.Accepted, "Campaign Updated");
                };
                if (result == HttpStatusCode.Conflict)
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict, "Campaign Name already exists");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Unknown Error");
            }
            catch (Exception exception)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }
        }

        public HttpResponseMessage Post([FromBody] Campaign inputCampaign)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HttpStatusCode result = add.Add(inputCampaign);
                    if (result == HttpStatusCode.Accepted)
                    {
                        return Request.CreateResponse(HttpStatusCode.Accepted, "Campaign Added");
                    };
                    if (result == HttpStatusCode.Conflict)
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Campaign already exists");
                    }
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Unknown Error");
                }
                catch (Exception exception)
                {

                    return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Unknown Error");
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                string result = delete.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }
        }
        
    }
}
