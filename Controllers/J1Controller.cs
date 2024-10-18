using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace J1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        [HttpPost(template: "delevedroid")]
        public int delevedroid([FromForm] int Deliveries, [FromForm] int Collisions)
        {
            /// <summary>
            /// Receives an HTTP POST request with a body and provides a response message i.e. how many collisions occured 
            /// and how many deliveries done. It will returen the total score.
            /// </summary>

            /// <param name="Deliveries & Collisions">The value entered by the user</param>

            /// <returns>An HTTP response with a body indicating the total.</returns>

            /// <remarks>
            /// Heading: Content-Type: application/x-www-form-urlencoded
            /// </remarks>


            /// <example>
            /// POST 'Deliveries=5&Collisions=2' localhost:xx/api/J1/Delivedroid -> 730
            /// </example>

            int final = 0;
            int Del = Deliveries * 50;
            int Col = Collisions * 10;
            final = Del - Col;
            if (Deliveries > Collisions)
            {
                final = final + 500;
            }
            return final;
        }

        [HttpPost(template: "boilingwater")]
        public string boiling([FromForm] int B)
        {
            /// <summary>
            /// Receives an HTTP POST request with a form and returns whether it is above sea level or not.
            /// </summary>

            /// <returns>An HTTP response with a body indicating the Pka.</returns>

            /// <remarks>
            /// Heading: Content-Type: application/x-www-form-urlencoded
            /// </remarks>

            /// <example>
            /// POST 'B=99' localhost:xx/api/J1/boilingwater -> -1
            /// </example>

            int P = (5 * B) - 400;
            if (P >= 100)
            {
                return "1";
            }
            else
            {
                return "-1";
            }
        }
    }
}