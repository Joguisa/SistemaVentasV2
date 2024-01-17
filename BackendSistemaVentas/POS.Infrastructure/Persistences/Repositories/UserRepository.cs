using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Persistences.Contexts;
using POS.Infrastructure.Persistences.Interfaces;

namespace POS.Infrastructure.Persistences.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DBSISTEMAVENTASContext _context;
        public UserRepository(DBSISTEMAVENTASContext context) : base(context)
        {
            _context = context;
        }

        // Este método nos va a servir para validar y posteriormente
        // generar un token de autenticación
        public async Task<User> AccountByUserName(string userName)
        {
            var account = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserName!.Equals(userName));
            return account!;
        }
    }
}
