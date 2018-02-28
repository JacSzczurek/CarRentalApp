using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalApp.Core.Model
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }

        public Model Model { get; set; }

        public int ModelId { get; set; }

        public ICollection<VehicleFeature> VehicleFeatures { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public DateTime Creationdate { get; set; }

        public Vehicle()
        {
            VehicleFeatures = new Collection<VehicleFeature>();
            Photos = new Collection<Photo>();
        }
    }
}
