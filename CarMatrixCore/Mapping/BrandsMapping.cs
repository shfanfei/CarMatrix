using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixData.Models;

namespace CarMatrixData.Mapping
{
    public class BrandsMapping : EntityTypeConfiguration<Brands>
    {
        public BrandsMapping()
        {
            this.ToTable("Brands");
            this.HasKey(b => b.Id);

            this.HasMany(b => b.Record).WithOptional(r => r.Brands);
        }
    }
}
