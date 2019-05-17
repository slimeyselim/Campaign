using CampaignApp.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CampaignApp.Data.Configs
{
    public class CampaignConfig : EntityTypeConfiguration<Campaign>
    {
        public CampaignConfig()
        {
            ToTable("campaigns");
            HasKey(c => c.Id);
            Property(c => c.ClientId).IsRequired();
            Property(c => c.Name).IsRequired();
            Property(c => c.Type).IsRequired();
            Property(c => c.StartDate).IsRequired();
            Property(c => c.EndDate).IsRequired();

            HasRequired<Client>(c => c.Client);
        }
    }
}
