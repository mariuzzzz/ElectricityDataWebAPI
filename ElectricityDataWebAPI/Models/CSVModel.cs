using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityDataWebAPI.Models
{
    public class CSVModel
    {
        [Index(0)]
        public string TINKLAS { get; set; }
        [Index(1)]
        public string OBT_PAVADINIMAS { get; set; }
        [Index(2)]
        public string OBJ_GV_TIPAS { get; set; }
        [Index(3)]
        public string OBJ_NUMERIS { get; set; }
        [Index(4)]
        public double? Pplus { get; set; }
        [Index(5)]
        public DateTime PL_T { get; set; }
        [Index(6)]
        public double? Pminus { get; set; }
    }
}
