using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IIvT_ProjectAPI.Persistence.Behaviors
{
    public class EfTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        readonly IIvT_ProjectAPIDbContext _dbContext;

        public EfTransactionBehavior(IIvT_ProjectAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(request is IQueryRequest)
                return await next();

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var tx = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

                try
                {
                    var response = await next();

                    await _dbContext.SaveChangesAsync(cancellationToken);
                    await tx.CommitAsync(cancellationToken);

                    return response;
                }
                catch
                {
                    await tx.RollbackAsync(cancellationToken);
                    throw;
                }
            });
        }
    }
}
