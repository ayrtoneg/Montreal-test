using Montreal.Domain.Interfaces;
using Montreal.Domain.Models;
using Montreal.Infra.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Montreal.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MontrealContext context) : base(context)
        {

        }

        public override IQueryable<Product> GetAll()
        {
            var result = DbSet.AsNoTracking();
            return result;
        }

        public override Product GetById(Guid id)
        {
            var result =  DbSet.AsNoTracking().Where(m => m.Id == id).FirstOrDefault();
            return result;
        }

        public override void Update(Product obj)
        {
            Db.Images.UpdateRange(obj.Images);
            obj.Images.Clear();
            DbSet.Update(obj);
        }

        public virtual IQueryable<Product> GetAllIncludingImages()
        {
            return DbSet.Include(c => c.Images);
        }

        public virtual Product GetByIdIncludingImages(Guid id)
        {
            return DbSet.AsNoTracking().Include(m => m.Images).Where(m => m.Id == id).FirstOrDefault();
        }
    }
}
