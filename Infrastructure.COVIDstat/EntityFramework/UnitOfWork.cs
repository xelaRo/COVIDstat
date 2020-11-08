using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.COVIDstat.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CovidStatDBContext _ctx;
        public UnitOfWork(CovidStatDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> SaveAsync()
        {
            return  await  _ctx.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual async Task DisposeAsync(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    await  _ctx.DisposeAsync();
                }
            }
            this.disposed = true;
        }

        public async Task Dispose()
        {
            await  DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

    }
}

