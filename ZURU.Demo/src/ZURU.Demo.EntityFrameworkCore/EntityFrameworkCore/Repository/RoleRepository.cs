using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using ZURU.Demo.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ZURU.Demo.EntityFrameworkCore
{
    public class RoleRepository : EfCoreRepository<DemoDbContext, Role, Guid>, IRoleRepository
    {
        public RoleRepository(IDbContextProvider<DemoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Role> FindAsync(Expression<Func<Role, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.Include(p => p.PermissionGrants).FirstOrDefaultAsync(predicate, cancellationToken);
        }
    }
}
