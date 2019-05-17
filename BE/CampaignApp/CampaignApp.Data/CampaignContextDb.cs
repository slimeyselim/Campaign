using System.Data.Entity;
using CampaignApp.Data.Entities;
using CampaignApp.Data.Configs;

namespace CampaignApp.Data
{
    public class CampaignContextDb : DbContext
    {
        public CampaignContextDb() : base("CampaignAppDb")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new CampaignConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
