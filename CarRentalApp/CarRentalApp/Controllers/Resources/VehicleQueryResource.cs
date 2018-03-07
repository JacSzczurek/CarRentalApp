using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalApp.Controllers.Resources
{
    public class VehicleQueryResource
    {
        public int? MakeId { get; set; }

        public int? ModelId { get; set; }

        public IEnumerable<int> Features { get; set; }

        public string SortBy { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public bool IsAscending { get; set; }
    }
}
