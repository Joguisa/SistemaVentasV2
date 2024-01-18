using POS.Infrastructure.FileStorage;

namespace POS.Infrastructure.Persistences.Interfaces
{
    // Este patrón de diseño nos va a permitir manejar transacciones durante la manipulación de datos
    // en la base de datos. Es decir, si se produce un error en alguna de las operaciones, se va a
    // deshacer todo lo que se haya hecho hasta el momento.
    public interface IUnitOfWork : IDisposable
    {
        // Declaración o matricula de nuestras interfaces a nivel de repositorio
        ICategoryRepository Category { get; }
        IUserRepository User { get; }

        IAzureStorage Storage { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
