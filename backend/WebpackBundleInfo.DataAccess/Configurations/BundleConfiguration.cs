using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebpackBundleInfo.Bundles;

namespace WebpackBundleInfo.Configurations
{
    internal class BundleConfiguration : IEntityTypeConfiguration<Bundle>
    {
        public void Configure(EntityTypeBuilder<Bundle> builder)
        {
            builder.Property<int>("Id");
            builder.HasKey("Id");

            builder.HasIndex(x => x.CommitSha).IsUnique();

            builder.OwnsMany(x => x.Components, c =>
            {
                c.ToTable("BundleComponents");
                c.WithOwner().HasForeignKey("BundleId");
            });
        }
    }
}
