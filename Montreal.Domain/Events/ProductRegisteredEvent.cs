using Montreal.Domain.Core.Events;
using Montreal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Montreal.Domain.Events
{
    public class ProductRegisteredEvent : Event
    {
        public ProductRegisteredEvent(Guid id, string name, string description, ICollection<Image> images, Guid? idFatherProduct)
        {
            Id = id;
            Name = name;
            Description = description;
            IdFatherProduct = idFatherProduct;
            Images = images;
            AggregateId = id;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Guid? IdFatherProduct { get; set; }

        public ICollection<Image> Images { get; private set; }
    }
}
