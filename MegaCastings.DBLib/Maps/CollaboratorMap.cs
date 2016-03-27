﻿using FluentNHibernate.Mapping;
using MegaCastings.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCastings.DBLib.Maps
{
    public class CollaboratorMap : ClassMap<Collaborator>
    {
        public CollaboratorMap()
        {
            Table("Collaborator");

            Id(c => c.Id).GeneratedBy.Identity();

            Map(c => c.Login).Not.Nullable().Length(8);

            Map(c => c.Password).Not.Nullable().Length(64);

            Map(c => c.Name).Not.Nullable().Length(25);

            Map(c => c.PhoneNumber).Length(10);

            Map(c => c.Address).Not.Nullable().Length(75);

            Map(c => c.City).Not.Nullable().Length(50);

            Map(c => c.ZipCode).Not.Nullable().Length(5);

            HasMany(c => c.CastingOffers).LazyLoad().Inverse().Cascade.All().AsSet();

        }
    }
}
