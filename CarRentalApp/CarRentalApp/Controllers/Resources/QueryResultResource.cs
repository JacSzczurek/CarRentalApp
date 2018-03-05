using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalApp.Controllers.Resources
{
    public class QueryResultResource<T>
    {
        public int ItemsCount { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
