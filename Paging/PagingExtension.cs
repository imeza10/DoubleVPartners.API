using Collection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Paging
{
    public static class PagingExtension
    {
        public static DataCollection<T> GetPaged<T>(
            this IQueryable<T> query,
            int page,
            int take)
        {
            var originalPages = page - 1;
            var skip = originalPages * take;

            var result = new DataCollection<T>
            {
                Items = query.Skip(skip).Take(take).ToList(),
                Total = query.Count(),
                Page = page
            };

            if (result.Total > 0)
            {
                result.Pages = (int)Math.Ceiling((double)result.Total / take);
            }
            return result;
        }
    }
}
