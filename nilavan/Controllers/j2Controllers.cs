using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
[HttpGet(template: "ChiliPeppers")]
        public int ChiliPeppers(string Ingredients)
        {
            // Spice levels of different pepper varieties
            int Poblano = 1500;
            int Mirasol = 6000;
            int Serrano = 15500;
            int Cayenne = 40000;
            int Thai = 75000; 
            int Habanero = 125000;
           
            int final_spice = 0;//Final spice level

            // Split ingredients string into an array
            string[] variety_peppers = Ingredients.Split(',');
            
            // Loop through each pepper in the array
            foreach (string pepper in variety_peppers)
            {
                string trim_pepper = pepper.Trim();

              // Add spice level based on the pepper type
                if (trim_pepper == "Poblano")
                {
                    final_spice = final_spice +  Poblano;
                }
                else if (trim_pepper == "Serrano")
                {
                    final_spice = final_spice + Serrano;
                }
                else if (trim_pepper == "Thai")
                {
                    final_spice = final_spice + Thai;
                }
                else if (trim_pepper == "Mirasol")
                {
                    final_spice = final_spice + Mirasol;
                }
               
                else if (trim_pepper == "Cayenne")
                {
                   final_spice = final_spice + Cayenne;
                }
                else
                {
                    final_spice = final_spice + Habanero;
                }
            }

            return final_spice;
        }

        [HttpPost(template: "epidemiology")]
        public int epidemiology([FromForm] int p, [FromForm] int n, [FromForm] int r)
        {
            int total = 0;//total time units
            int infected = n;
            int newinfected = n;

            // Calculate total time until infected population exceeds threshold
            while (infected <= p)
            {
                total++;
                newinfected = newinfected * r;
                infected = infected + newinfected;// Update total infected
            }
            return total;
        }
    }
}

