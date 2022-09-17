using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxpayerLibraryEntityVersion.Classes
{
    /// <summary>
    /// Responsible for generating a random <see cref="DateTime"/>
    /// </summary>
    public class RandomDateTime
    {
        DateTime start;
        Random random;
        int range;

        public RandomDateTime()
        {
            start = new DateTime(2000, 1, 1);
            random = new Random();
            range = (DateTime.Today - start).Days;
        }

        public DateTime Next() 
            => start
                .AddDays(random.Next(range))
                .AddHours(random.Next(0, 24))
                .AddMinutes(random.Next(0, 60))
                .AddSeconds(random.Next(0, 60));
    }
}
