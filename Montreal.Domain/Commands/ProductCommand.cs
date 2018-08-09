using Montreal.Domain.Core.Commands;
using Montreal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Montreal.Domain.Commands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public Guid? IdFatherProduct { get; set; }

        public ICollection<Image> Images { get; protected set; }
    }
}
