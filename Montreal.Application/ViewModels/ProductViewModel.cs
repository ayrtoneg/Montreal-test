using System;
using System.Collections.Generic;

namespace Montreal.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public Guid? IdFatherProduct { get;  set; }

        public ProductViewModel FatherProduct { get;  set; }
        public ICollection<ImageViewModel> Images { get;  set; }
        public ICollection<ProductViewModel> ChildrenProducts { get;  set; }
    }
}
