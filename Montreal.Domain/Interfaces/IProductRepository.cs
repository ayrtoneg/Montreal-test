using Montreal.Domain.Models;
using System;
using System.Linq;

namespace Montreal.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> GetAllIncludingImages();
        Product GetByIdIncludingImages(Guid id);
    }
}
