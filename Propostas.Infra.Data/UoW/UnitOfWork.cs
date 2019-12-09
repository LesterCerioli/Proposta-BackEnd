namespace Propostas.Infra.Data.UoW
{
    using Propostas.Domain.Interfaces;
    using Propostas.Infra.Data.Context;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PropostasContext context;

        public UnitOfWork(PropostasContext context)
        {
            this.context = context;
        }

        public bool Commit()
        {
            var rowsAffected = this.context.SaveChanges();
            return rowsAffected > 0;
        }

        public async Task CommitAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
