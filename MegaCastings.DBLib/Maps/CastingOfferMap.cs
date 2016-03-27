using FluentNHibernate.Mapping;
using MegaCastings.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.DBLib.Maps
{
   public class CastingOfferMap : ClassMap<CastingOffer>
    {
        public CastingOfferMap()
        {
            Table("CastingOffer");

            Id(c => c.Id).GeneratedBy.Identity();

            Map(c => c.Title).Not.Nullable().Length(25);

            Map(c => c.Refernce).Not.Nullable().Length(10).UniqueKey("UkCastingOffer");

            Map(c => c.StartingDate).Not.Nullable();

            Map(c => c.EndingDate).Not.Nullable();

            Map(c => c.PostNumber).Not.Nullable();

            Map(c => c.PostDescription).Not.Nullable().Length(500);

            Map(c => c.ProfileDescription).Not.Nullable().Length(500);

            Map(c => c.Contact).Not.Nullable().Length(15);

            References(c => c.Client).Not.Nullable();

            References(c => c.Profession).Not.Nullable();

            References(c => c.ProfessionField).Not.Nullable();

            References(c => c.ContractType).Not.Nullable();

        }
    }
}
