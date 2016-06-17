using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MegaCastings.Entities;

namespace MegaCastings.DBLib.Maps
{
    public class DomaineOfferMap : ClassMap<DomaineOffer>
    {
        public DomaineOfferMap()
        {
            Table("DomaineOffer");

            Id(c => c.Id).GeneratedBy.Identity();

            Map(c => c.Title).Not.Nullable().Length(100);

            Map(c => c.Description).Not.Nullable();

        }
    }
}
