using CampaignApp.Data;
using CampaignApp.Data.Entities;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace CampaignApp.Business
{
    public class AddCampaign
    {
        public HttpStatusCode Add(Campaign _campaign)
        {
            using(CampaignContextDb db = new CampaignContextDb())
            {
                if (db.Campaigns.Any(c => c.Name == _campaign.Name && c.ClientId == _campaign.ClientId)) return HttpStatusCode.Conflict;

                db.Campaigns.Add(_campaign);
                db.SaveChanges();

                return HttpStatusCode.Accepted;
            };
        }
    }
}
