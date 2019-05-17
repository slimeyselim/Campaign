using CampaignApp.Data;
using CampaignApp.Data.Entities;
using System.Linq;
using System.Net;

namespace CampaignApp.Business
{
    public class EditCampaign
    {
        public HttpStatusCode Edit(int id, string campaignName)
        {
            using (CampaignContextDb db = new CampaignContextDb())
            {

                if (db.Campaigns.Any(c => c.Name == campaignName)) return HttpStatusCode.Conflict;

                Campaign _campaign = db.Campaigns.SingleOrDefault(c => c.Id == id);

                _campaign.Name = campaignName;
                db.SaveChanges();

                return HttpStatusCode.Accepted;
            };
        }
    }
}
