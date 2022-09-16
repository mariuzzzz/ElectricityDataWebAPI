using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectricityDataWebAPI.Models
{
    
    [Table("ElectricityData")]
    public class DataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Area { get; set; }
        public string Type { get; set; }
        public string IsLiving { get; set; }
        public string ObjNumber { get; set; }
        public double? Consumed { get; set; }
        public DateTime Date { get; set; }
        public double? Generated { get; set; }
        public double? Difference { get; set; }

    }
}
