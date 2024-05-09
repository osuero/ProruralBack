using Data.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;

namespace Data
{
    public static class ModelBuilderExtensions
    {
        public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityType)
        {
            var method = typeof(ModelBuilderExtensions).GetMethod(nameof(GetSoftDeleteFilter),
                BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(entityType.ClrType);
            var filter = method.Invoke(null, new object[] { });
            entityType.SetQueryFilter((LambdaExpression)filter);
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : class, ISoftDelete
        {
            Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
            return filter;
        }
    }

}
