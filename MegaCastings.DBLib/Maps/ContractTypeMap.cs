using FluentNHibernate.Mapping;
using MegaCastings.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.DBLib.Maps
{
     public class ContractTypeMap : ClassMap<ContractType>
    {
        public ContractTypeMap()
        {
            Table("ContractType");

            Id(c => c.Id).GeneratedBy.Identity();

            Map(c => c.ConType).Not.Nullable().Length(100).UniqueKey("UkContractType");

        }
    }
}
