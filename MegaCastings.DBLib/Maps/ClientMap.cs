﻿using System;
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

            Map(c => c.Name).Not.Nullable().Length(25);

            Map(c => c.PhoneNumber).Length(10);

            Map(c => c.Address).Not.Nullable().Length(75);

            Map(c => c.City).Not.Nullable().Length(50);

            Map(c => c.ZipCode).Not.Nullable().Length(5);

            HasMany(c => c.Representatives).LazyLoad().Inverse().Cascade.All().AsSet(); 

        }

    }
}