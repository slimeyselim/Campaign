using CampaignApp.Data;
using CampaignApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CampaignApp.Business
{ 
    public class GetClients
    {
        public List<Client> GetAll()
        {
            using (CampaignContextDb db = new CampaignContextDb())
            {
                return db.Clients
                    .ToList();
            }
        }
    }
}
