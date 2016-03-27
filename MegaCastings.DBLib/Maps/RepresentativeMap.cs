using FluentNHibernate.Mapping;
using MegaCastings.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.DBLib.Maps
{
   public class RepresentativeMap : ClassMap<Representative>
    {
        public RepresentativeMap()
        {

            Table("Representative");

            Id(r => r.Id).GeneratedBy.Identity();

            Map(r => r.FirstName).Not.Nullable().Length(15);

            Map(r => r.LastName).Not.Nullable().Length(15);

            Map(r => r.PhoneNumber).Not.Nullable().Length(10);

            References(r => r.Client).Not.Nullable();

        }
    }
}
