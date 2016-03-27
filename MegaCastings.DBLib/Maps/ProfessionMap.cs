using FluentNHibernate.Mapping;
using MegaCastings.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.DBLib.Maps
{
    public class ProfessionMap : ClassMap<Profession>
    {
        public ProfessionMap()
        {
            Table("Profession");

            Id(p => p.Id).GeneratedBy.Identity();

            Map(p => p.Name).Not.Nullable().Length(20);

            References(p => p.ProfessionField).Not.Nullable();
        }

    }
}
