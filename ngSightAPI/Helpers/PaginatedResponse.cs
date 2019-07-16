using System.Collections.Generic;
using System.Linq;

namespace ngSightAPI.Helpers
{
    public class PaginatedResponse<T>
    {
        public PaginatedResponse(IEnumerable<T> data, int index, int size)
        {
            data = data.ToList();
            Data = data.Skip((index - 1) * size).Take(size).ToList();
            Total = data.Count();
        }

        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
