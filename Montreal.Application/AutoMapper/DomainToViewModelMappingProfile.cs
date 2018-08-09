using AutoMapper;
using Montreal.Application.ViewModels;
using Montreal.Domain.Models;

namespace Montreal.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>().MaxDepth(2);
            CreateMap<Image, ImageViewModel>().ForMember(c => c.Product, m => m.Ignore());
        }
    }
}
