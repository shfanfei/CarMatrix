using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixData.Models;

namespace CarMatrixData.Mapping
{
    public class RecordMapping : EntityTypeConfiguration<Record>
    {
        public RecordMapping()
        {
            this.ToTable("Record");
            this.HasKey(r => r.Id);
        }
    }
}
