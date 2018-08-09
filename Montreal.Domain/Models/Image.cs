using Montreal.Domain.Core.Models;
using System;

namespace Montreal.Domain.Models
{
    public class Image : Entity
    {
        public Image(Guid id, string type, Guid idProduct)
        {
            Id = id;
            Type = type;
            IdProduct = idProduct;
        }

        public Image() { }

        public Guid IdProduct { get; private set; }
        public string Type { get; private set; }
        public Product Product { get; private set; }
    }
}
