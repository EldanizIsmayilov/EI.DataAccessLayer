using IEldaniz.DataAccessLayer.Abstractions;
using IEldaniz.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace IEldaniz.DataAccessLayer.Persistence.Configurations
{
    public class SampleEntityConfig : EntityTypeConfiguration<SampleEntity>, IEntityConfiguration
    {
        public SampleEntityConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Id).HasColumnName("ID");
            Property(x => x.Name).HasColumnName("NAME");
            Property(x => x.Surname).HasColumnName("SURNAME");
            Property(x => x.Patronymic).HasColumnName("PATRONYMIC");

            ToTable("SAMPLE_ENTITY");

        }
    }
}
