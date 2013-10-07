using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class pet_name_generationMap : EntityTypeConfiguration<pet_name_generation>
    {
        public pet_name_generationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.word)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
