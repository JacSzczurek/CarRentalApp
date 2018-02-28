using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalApp.Controllers.Resources
{
    public class MakeResource
    {
        public string Name { get; set; }

        public ICollection<KeyValueResource> Models { get; set; }

        public MakeResource()
        {
            Models = new Collection<KeyValueResource>();
        }
    }
}
