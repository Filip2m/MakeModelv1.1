using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MakeModel.Models
{
    public class VehicleModel
    {
       public int id { get; set; }
       public string ModelName { get; set; }
       public string abrv { get; set; }
       public VehicleMake VehicleMake { get; set; }  
    }
    public class ModelDBContext : DbContext
    {
        public DbSet<VehicleModel> VehicleModels { get; set; }
    }
}