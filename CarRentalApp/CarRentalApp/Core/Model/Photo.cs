using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalApp.Core.Model
{
    public class Photo
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }

        public string Filename { get; set; }
    }
}
