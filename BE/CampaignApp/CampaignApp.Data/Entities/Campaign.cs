using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignApp.Data.Entities
{

    public class Campaign
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public CampaignTypes Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Client Client { get; set; }

        public Campaign()
        {

        }

        public Campaign(int clientId,string name, int type, DateTime startDate, DateTime endDate)
        {
            ClientId = clientId;
            Name = name;
            Type = (CampaignTypes)type;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
