using Montreal.Domain.Interfaces;
using Montreal.Infra.Data.Context;

namespace Montreal.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MontrealContext _context;

        public UnitOfWork(MontrealContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
