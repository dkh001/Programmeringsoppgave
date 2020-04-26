using System;
using System.Collections.Generic;

namespace Programmeringsoppgave.Models.InputModels
{
    public class DailyMeasureInput
    {
        public string Meter_id { get; set; }

        public string Customer_id { get; set; }

        public string Resolution { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public Dictionary<string, double> Values { get; set; }
    }
}
