using Innofactor.EfCoreJsonValueConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programmeringsoppgave.Models.Entities
{
    public class DailyMeasure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Meter_id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Customer_id { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Resolution { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }

        [JsonField]
        public Dictionary<string, double> Values { get; set; }

    }
}
