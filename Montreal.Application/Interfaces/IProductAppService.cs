using Montreal.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Montreal.Application.Interfaces
{
    public interface IProductAppService
    {
        void Register(ProductViewModel productRepository);
        IEnumerable<ProductViewModel> GetAll();
        IEnumerable<ProductViewModel> GetAllIncludingImages();
        ProductViewModel GetById(Guid id);
        ProductViewModel GetByIdIncludingImages(Guid id);
        void Update(ProductViewModel productRepository);
        void Remove(Guid id);
    }
}
