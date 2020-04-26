using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmeringsoppgave.Data;
using Programmeringsoppgave.Models;
using Programmeringsoppgave.Models.Entities;
using Programmeringsoppgave.Models.InputModels;

namespace Programmeringsoppgave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyMeasuresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DailyMeasuresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyMeasures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyMeasureInput>>> GetDailyMeasure()
        {
            var dailyMeasureFromDateBase = await _context.DailyMeasure.ToListAsync();
            List<DailyMeasureInput> dailyMeasureList = new List<DailyMeasureInput>();
            foreach (DailyMeasure dailyMeasure in dailyMeasureFromDateBase)
            {
                dailyMeasureList.Add(new DailyMeasureInput()
                {
                    Meter_id = dailyMeasure.Meter_id,
                    Customer_id = dailyMeasure.Customer_id,
                    Resolution = dailyMeasure.Resolution,
                    From = dailyMeasure.From,
                    To = dailyMeasure.To,
                    Values = dailyMeasure.Values
                });
            };

            return dailyMeasureList;
        }

        //GET: /api/DailyMeasures/GetTotalSumAllMeters/"nsd98f"
        [Route("[action]/{customer_id}")]
        [HttpGet]
        public async Task<ActionResult<OutputTotalSumAllMeters>> GetTotalSumAllMeters(string customer_id)

        {
            DateTime today = DateTime.Today;
            DateTime sevenDaysEarlier = today.AddDays(-7);
            OutputTotalSumAllMeters outputTotalSumAllMeters = new OutputTotalSumAllMeters();
            var list = await _context.DailyMeasure.Where(c => c.Customer_id == customer_id && (c.From >= sevenDaysEarlier && c.From <= today))
                  .ToListAsync();

            double weekSum = 0;
            foreach (DailyMeasure dm in list)
            {
                weekSum += dm.Values.Values.Sum();
            }
            outputTotalSumAllMeters.Customer_id = customer_id;
            outputTotalSumAllMeters.TotalSumWeek = weekSum;
            return outputTotalSumAllMeters;
        }

        //GET: /api/DailyMeasures/GetTotalSumEachMeters/"nsd98f"
        [Route("[action]/{customer_id}")]
        [HttpGet]
        public async Task<ActionResult<OutputTotalSumEachMeters>> GetTotalSumEachMeters(string customer_id)
        {
            OutputTotalSumEachMeters outputTotalSumEachMeters = new OutputTotalSumEachMeters();
            outputTotalSumEachMeters.TotalSumWeekEachMeters = new Dictionary<string, double>();
            outputTotalSumEachMeters.Customer_id = customer_id;
            DateTime today = DateTime.Today;
            DateTime sevenDaysEarlier = today.AddDays(-7);

            var list = await _context.DailyMeasure.Where(c => c.Customer_id == customer_id && (c.From >= sevenDaysEarlier && c.From <= today))
                  .ToListAsync();
            var listMeters = await _context.DailyMeasure.Where(c => c.Customer_id == customer_id).Select(a => a.Meter_id).Distinct()
                 .ToListAsync();

            foreach (string meterId in listMeters)
            {
                double weekSum = 0;
                foreach (DailyMeasure dm in list)
                {
                    if (dm.Meter_id == meterId)
                    {
                        weekSum += dm.Values.Values.Sum();
                    }
                }
                outputTotalSumEachMeters.TotalSumWeekEachMeters.Add(meterId, weekSum);
            }

            return outputTotalSumEachMeters;
        }

        //GET: /api/DailyMeasures/GetAllTimeSeriesByDay/"2020-04-24T00:00:00"
        [Route("[action]/{date}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyMeasure>>> GetAllTimeSeriesByDay(DateTime date)
        {
            var timeSeriesByDay = await _context.DailyMeasure.Where(ts => ts.From.Date == date.Date).ToListAsync();

            return timeSeriesByDay;
        }

        // POST: api/DailyMeasures
        [HttpPost]
        public async Task<ActionResult<DailyMeasure>> PostDailyMeasure(DailyMeasureInput dailyMeasureInput)
        {
            DailyMeasure dailyMeasure = new DailyMeasure()
            {
                Id = 0,
                Meter_id = dailyMeasureInput.Meter_id,
                Customer_id = dailyMeasureInput.Customer_id,
                Resolution = dailyMeasureInput.Resolution,
                From = dailyMeasureInput.From,
                To = dailyMeasureInput.To,
                Values = dailyMeasureInput.Values
            };
            _context.DailyMeasure.Add(dailyMeasure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyMeasure", new { id = dailyMeasure.Id }, dailyMeasure);
        }

        private bool DailyMeasureExists(int id)
        {
            return _context.DailyMeasure.Any(e => e.Id == id);
        }
    }
}
