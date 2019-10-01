using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace Orders.Extensions
{
    public static class ResolveFieldContextExtensions
    {
        public static async Task<object> TryAsyncResolve<TSource>(this ResolveFieldContext<TSource> context,
            Func<ResolveFieldContext<TSource>, Task<object>> resolve, Func<ExecutionErrors, Task<object>> error = null)
        {
            try
            {
                return await resolve(context);
            }
            catch (Exception e)
            {
                if (error is null)
                {
                    context.Errors.Add(new ExecutionError(e.Message));
                    return null;
                }

                return error(context.Errors);
            }
        }
    }
}