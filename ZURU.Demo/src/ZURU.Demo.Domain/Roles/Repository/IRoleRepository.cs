using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ZURU.Demo.Domain
{
    public interface IRoleRepository:IRepository<Role,Guid>
    {
        Task<Role> FindAsync(Expression<Func<Role, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
    }
}
