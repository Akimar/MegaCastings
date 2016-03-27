using FluentNHibernate.Mapping;
using MegaCastings.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.DBLib.Maps
{
    public class ProfessionFieldMap : ClassMap<ProfessionField>
    {
        public ProfessionFieldMap()
        {
            Table("ProfessionField");

            Id(p => p.Id).GeneratedBy.Identity();

            Map(p => p.Title).Not.Nullable().Length(25);

            HasMany(p => p.Professions).LazyLoad().Inverse().Cascade.All().AsSet();
        }

    }
}
