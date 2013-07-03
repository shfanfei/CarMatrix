using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMatrixData.Mapping
{
    public class ModelsMapping : EntityTypeConfiguration<CarMatrixData.Models.Models>
    {
        public ModelsMapping()
        {
            this.ToTable("Models");
            this.HasKey(m => m.Id);
            this.HasMany(m => m.Record).WithOptional(r => r.Models);
        }
    }
}
