using CampaignApp.Data;
using CampaignApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CampaignApp.Business
{
    public class GetCampaigns
    {
        public List<Campaign> GetAll()
        {
            using (CampaignContextDb db = new CampaignContextDb())
            {
                return db.Campaigns
                    .ToList();
            }
        }
    }
}
