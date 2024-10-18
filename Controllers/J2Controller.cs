using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        /// <summary>
        /// The input should be the names of the pepper and will return the spice level. 
        /// </summary>

        ///<param name = "ingredients" > A list of pepper names </param>

        /// <remarks> Spiciness levels
        /// int Cayenne = 40000;
        /// Mirasol = 6000;
        /// Poblano = 1500;
        /// Habanero = 125000;
        /// Serrano = 15500;
        /// Thai = 75000;
        /// </remarks>

        /// <returns>
        /// Total spiciness level
        /// </returns>

        /// <example>
        /// localhost:xx/api/J2/ChiliPeppers&Ingredients=Poblano, Cayenne,Thai,Poblano -> 118000
        /// </example>

      
        [HttpGet(template: "chillipeppers")]
        public int chillipeppers(string quantity)
        {
            int Cayenne = 40000;
            int Mirasol = 6000;
            int Poblano = 1500;
            int Habanero = 125000;
            int Serrano = 15500; 
            int Thai = 75000;
           
            int final_spice = 0;

            string[] variety_peppers = quantity.Split(',');

            foreach (string pepper in variety_peppers)
            {
                string trim_pepper = pepper.Trim();

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
        public int epidemiology([FromForm] int P, [FromForm] int N, [FromForm] int R)
        {
            /// <summary>
            /// Receives an HTTP POST request with a form and outout the total number of people who have had the disease is greater than 
            /// </summary>

            /// <param name="P,N,R">The value entered by the user</param>

            /// <returns>It returns the total number of patients who have disease.</returns>

            /// <remarks>
            /// Heading: Content-Type: application/x-www-form-urlencoded
            /// </remarks>


            /// <example>
            ///  -d "P=10&N=2&R=1" //localhost:7083/api/J2/epidemiology -> 5
            /// </example>
            int total = 0;
            int recentinf = N;
            int infect = N;
       
            while (infect <= P)
            {
                total++;
                recentinf = recentinf * R;
                infect= infect + recentinf;
            }
            return total;
        }
    }
}






