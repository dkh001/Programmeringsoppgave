using System.Collections.Generic;

namespace Programmeringsoppgave.Models
{
    public class OutputTotalSumEachMeters
    {
        public string Customer_id { get; set; }

        public Dictionary<string, double> TotalSumWeekEachMeters { get; set; }
    }
}
