using EI.DataAccessLayer.Abstractions;
using EI.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EI.DataAccessLayer.Persistence.Configurations
{
    public class PersonConfig : EntityTypeConfiguration<Person>, IEntityConfiguration
    {
        public PersonConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Id).HasColumnName("ID");
            Property(x => x.Name).HasColumnName("NAME");
            Property(x => x.Surname).HasColumnName("SURNAME");
            Property(x => x.Patronymic).HasColumnName("PATRONYMIC");

            ToTable("PERSONS");

        }
    }
}
