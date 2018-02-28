using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalApp.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }

        public KeyValueResource Model { get; set; }

        public KeyValueResource Make { get; set; }

        public ICollection<KeyValueResource> Features { get; set; }

        public ICollection<KeyValueResource> Photos { get; set; }

    }
}
