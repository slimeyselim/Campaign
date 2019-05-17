using CampaignApp.Data;
using CampaignApp.Data.Entities;
using System.Linq;

namespace CampaignApp.Business
{
    public class DeleteCampaign
    {
        public string Delete(int id)
        {
            using(CampaignContextDb db = new CampaignContextDb())
            {
                if (!db.Campaigns.Any(c => c.Id == id)) return "no campaign exists";

                Campaign campaign = db.Campaigns.Where(c => c.Id == id).SingleOrDefault();

                db.Campaigns.Remove(campaign);
                db.SaveChanges();
                return "Campaign Deleted";
            }
        }
    }
}
