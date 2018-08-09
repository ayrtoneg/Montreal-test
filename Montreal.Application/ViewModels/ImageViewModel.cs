using System;

namespace Montreal.Application.ViewModels
{
    public class ImageViewModel
    {
        public Guid Id { get; set; }
        public Guid IdProduct { get;  set; }
        public string Type { get;  set; }
        public ProductViewModel Product { get;  set; }
    }
}
