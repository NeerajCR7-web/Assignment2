using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace J3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
        [HttpPost("citydist")]
        public string Findistance([FromForm] string enterdist)
        {
            /// <summary>
            /// Receives an HTTP POST request from the form and provides distance table that indicates
            /// the distance between any two cities
            /// </summary>

            /// <param name="enterdist">enter 4 numbers which represent the distance</param>

            /// <returns>An HTTP response containing the distance.</returns>

            /// <remarks>
            /// Heading: Content-Type: application/x-www-form-urlencoded
            /// </remarks>


            /// <example>
            /// POST -d "enterdist=3 10 12 5" //localhost:7083/api/J3/citydist ->    0 3 13 25 30
           ///                                                                       3 0 10 22 27
              ///                                                                    13 10 0 12 17
                 ///                                                                 25 22 12 0 5
                    ///                                                              30 27 17 5 0
            /// </example>

            var distance = enterdist.Split(' ');
            int[] distances = Array.ConvertAll(distance, int.Parse);
            int[,] disttable = new int[5, 5];

          
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j)
                    {
                        disttable[i, j] = 0; 
                    }
                    else if (i < j)
                    {
                        int sum = 0;
                        for (int k = i; k < j; k++)
                        {
                            sum = sum + distances[k];
                        }
                        disttable[i, j] = sum;
                        disttable[j, i] = sum; 
                    }
                }
            }

            string result = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    result = result + disttable[i, j] + " ";
                }
                result = result + "\n";
            }


            return result.TrimEnd();
        }
    }
}