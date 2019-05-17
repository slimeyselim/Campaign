using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignApp.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }

        public ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();

        public Client()
        {

        }

        public Client(string clientName)
        {
            ClientName = clientName;
            Campaigns = new List<Campaign>();
        }
    }
}
