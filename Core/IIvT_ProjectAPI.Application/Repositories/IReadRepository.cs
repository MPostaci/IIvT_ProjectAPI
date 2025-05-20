using IIvT_ProjectAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, bool tracking = true, CancellationToken cancellation = default);
        Task<int> CountAsync(bool tracking = true);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, bool tracking = true);
    }
}
