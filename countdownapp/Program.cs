using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace countdownapp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var movie_data = new Movie();
            try
            {
                movie_data = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"C:\_Git\countdownapp\countdownapp\config.json"));
            }
            catch
            {
                movie_data.Event = "Wonder Woman";
                movie_data.Date = "06-02-2017";
            }
            finally
            {
                string MovieTitle = movie_data.Event;
                string HowLongDoIHaveToWait = HoursRemaining(movie_data.Date);
                Console.WriteLine(MovieTitle + HowLongDoIHaveToWait);
                Console.ReadKey();
            }
        }

        public static string HoursRemaining(string day)
        {
            DateTime dt = Convert.ToDateTime(day);
            DateTime now = DateTime.Now;
            var diffInMinutes = (dt - now).TotalMinutes;
            var diffInHours = diffInMinutes / 60;
            var appendMinutes = diffInMinutes % 60;
            string hours = " will arrive in " + Math.Truncate(diffInHours) + " hours ";
            string minutes = appendMinutes > 0 ? "and " + Math.Truncate(appendMinutes).ToString() + " minutes" : "";
            return hours + minutes;
        }
    }
}
