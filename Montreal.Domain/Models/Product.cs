using Montreal.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Montreal.Domain.Models
{
    public class Product : Entity
    {
        public Product(Guid id, string name, string description, ICollection<Image> images, Guid? idFatherProduct = null)
        {
            Id = id;
            Name = name;
            Description = description;
            IdFatherProduct = idFatherProduct;
            Images = images;
        }

        public Product() {}

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid? IdFatherProduct { get; private set; }

        public Product FatherProduct { get; private set; }
        public ICollection<Image> Images { get; private set; }
        public ICollection<Product> ChildrenProducts { get; private set; }

    }
}
