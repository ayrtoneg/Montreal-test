using AutoMapper;
using Montreal.Application.ViewModels;
using Montreal.Domain.Commands;
using Montreal.Domain.Models;
using System.Collections.Generic;

namespace Montreal.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile :Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(c => new RegisterNewProductCommand(c.Id, c.Name, c.Description, Mapper.Map<ICollection<Image>>(c.Images), c.IdFatherProduct));
            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(c => new UpdateProductCommand(c.Id, c.Name, c.Description, Mapper.Map<ICollection<Image>>(c.Images), c.IdFatherProduct));
        }
    }
}
