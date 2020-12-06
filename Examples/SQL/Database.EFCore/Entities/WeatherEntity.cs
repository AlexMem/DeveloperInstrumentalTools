using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("Weather")]
    public class WeatherEntity
    {
        public int Id { get; set; }
        
        public SummaryEntity Summary { get; set; }
        
        public DateTime TimeStamp { get; set; }
        
        public decimal Temperature { get; set; }
    }
}