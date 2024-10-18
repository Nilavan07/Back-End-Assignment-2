using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j3Controller : ControllerBase
    {
        [HttpPost(template: "scheduleEvent")]
        public ActionResult<string> ScheduleEvent([FromForm] int numberOfPeople, [FromForm] List<string> availability)
        {
            
            int[] availableCount = new int[5];// Array to count availability for each day

            // Loop through each person's availability
            foreach (var person in availability)
            {
                for (int i = 0; i < 5; i++)// Checking the availability for each of the 5 days
                {
                    if (person[i] == 'Y') 
                    {
                        availableCount[i]++;
                    }
                }
            }

            
            int maxAvailable = availableCount.Max();// Get the maximum availability count


            
            List<int> bestDays = new List<int>();
             // Find the days with maximum availability
            for (int i = 0; i < 5; i++)
            {
                if (availableCount[i] == maxAvailable)// Check if count matches max
                {
                    bestDays.Add(i + 1); 
                }
            }

            
            return Ok(string.Join(",", bestDays));
        }
    }
}
