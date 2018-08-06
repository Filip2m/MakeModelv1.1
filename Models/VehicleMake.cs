using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MakeModel.Models
{
    public class VehicleMake
    {
        public int id{get;set;}
        public string MakeName{get;set;}
        public string abrv{get;set;}
    }

    public class MakeDBContext : DbContext //MakeDBContext se mora podudarat sa web.config connection add name=MakeDBContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }
    }
}