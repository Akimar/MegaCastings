using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MegaCastings.Entities;

namespace MegaCastings.DBLib.Maps
{
    public class ClientMap : ClassMap<Client>

    {
        public ClientMap()
        {
            Table("Client");

            Id(c => c.Id).GeneratedBy.Identity();



        }

    }
}
