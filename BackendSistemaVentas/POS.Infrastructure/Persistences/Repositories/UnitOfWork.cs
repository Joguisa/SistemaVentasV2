using POS.Infrastructure.Persistences.Contexts;
using POS.Infrastructure.Persistences.Interfaces;

namespace POS.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBSISTEMAVENTASContext _context;
        public ICategoryRepository Category { get; private set; }

        public IUserRepository User { get; private set; }

        public UnitOfWork(DBSISTEMAVENTASContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            User = new UserRepository(_context);
        }

        public void Dispose()
        {
            // liberar los recursos de la memoria
            _context.Dispose();
        }

        public void SaveChanges()
        {
            // guardar los cambios en la base de datos
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            // guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
        }
    }
}
