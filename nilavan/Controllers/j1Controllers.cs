using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class j1Controller : ControllerBase
    {
        [HttpPost(template: "delevedroid")]
        public int delevedroid([FromForm] int deliveries, [FromForm] int collisions)
        {
            int total = 0;// Initialize the total score
            int del = deliveries * 50;// Score for deliveries
            int col = collisions * 10;// Penalty for collisions
            total = del - col;//Calculate the total score

            
            if (deliveries > collisions) // Checking if deliveries are greater than collisions
            {
                total = total + 500;
            }
            return total;
        }
        [HttpPost("cupcakes")]
        public ActionResult<int> CalculateLeftoverCupcakes([FromForm] int regularBoxes, [FromForm] int smallBoxes)
        {
             const int CUPCAKES_IN_REGULAR_BOX = 8;//Cupcakes per regularbox
            const int CUPCAKES_IN_SMALL_BOX = 3;//Cupcakes per samllbox
            const int NUMBER_OF_STUDENTS = 28;//No of Students

            
            int totalCupcakes = (regularBoxes * CUPCAKES_IN_REGULAR_BOX) + (smallBoxes * CUPCAKES_IN_SMALL_BOX);//Total Cupcakes

            int leftoverCupcakes = totalCupcakes - NUMBER_OF_STUDENTS;//Calculate the leftover

            return Ok(leftoverCupcakes); 
        }
    }
}
        

    
