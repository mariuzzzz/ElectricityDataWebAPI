using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ElectricityDataWebAPI.Models;


namespace ElectricityDataWebAPI.DB
{
    public class ElectricityContext : DbContext
    {
        public ElectricityContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<DataModel> Data { get; set; }
    }
}
