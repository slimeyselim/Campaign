using System.Data.Entity.ModelConfiguration;
using CampaignApp.Data.Entities;

namespace CampaignApp.Data.Configs
{
    public class ClientConfig : EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            ToTable("clients");
            HasKey(c => c.Id);
            Property(c => c.ClientName).IsRequired();
            HasMany<Campaign>(c => c.Campaigns).WithRequired(c => c.Client).HasForeignKey(c => c.ClientId);
        }
    }
}
