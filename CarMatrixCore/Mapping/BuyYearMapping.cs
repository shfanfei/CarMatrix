using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixData.Models;

namespace CarMatrixData.Mapping
{
    public class BuyYearMapping : EntityTypeConfiguration<BuyYear>
    {
        public BuyYearMapping()
        {
            this.ToTable("BuyYear");
            this.HasKey(b => b.Id);
            this.HasMany(b => b.Record).WithOptional(r => r.BuyYear);
        }
    }
}
