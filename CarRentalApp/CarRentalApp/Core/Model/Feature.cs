using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalApp.Core.Model
{
    [Table("Features")]
    public class Feature
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
