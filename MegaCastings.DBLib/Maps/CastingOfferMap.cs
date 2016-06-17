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

            Map(c => c.Title).Not.Nullable().Length(100);

            Map(c => c.Reference).Not.Nullable().Length(25).UniqueKey("UkCastingOffer");

            Map(c => c.BroadcastStartingDate).Not.Nullable();

            Map(c => c.ContractStartingDate).Not.Nullable();

            Map(c => c.BroadcastingTime).Not.Nullable().Length(75);

            Map(c => c.Location).Not.Nullable().Length(100);

            Map(c => c.PostNumber).Not.Nullable();

            Map(c => c.PostDescription).Not.Nullable().Length(500);

            Map(c => c.ProfileDescription).Not.Nullable().Length(500);

            References(c => c.Client).Not.Nullable().Index("IxCastingOfferClient");

            References(c => c.Profession).Nullable().Index("IxCastingOfferProfession"); 

            References(c => c.ProfessionField).Nullable().Index("IxCastingOfferProfessionField"); 

            References(c => c.ContractType).Not.Nullable().Index("IxCastingOfferContractType");

            References(c => c.DomaineOffer).Not.Nullable().Index("IxCastingOfferDomaineOffer"); ;
        }
    }
}
