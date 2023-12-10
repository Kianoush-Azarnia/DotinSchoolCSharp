using System;
using System.Collections.Generic;
using System.Linq;

namespace dataHelper
{
    public class DataHelper
    {
        public static (double maleAvgAge, double femaleAvgAge) GetAverageAgeBySex(string csv)
        {
            var rows = csv.Split('\n');
            var maleAges = new List<int>();
            var femaleAges = new List<int>();

            foreach (var row in rows)
            {
                var cols = row.Split(',');
                if (cols.Length != 4) continue;

                var firstName = cols[0];
                var lastName = cols[1];
                var sex = cols[2];
                var age = int.Parse(cols[3]);

                if (sex == "M")
                {
                    maleAges.Add(age);
                }
                else if (sex == "F")
                {
                    femaleAges.Add(age);
                }
            }

            var maleAvgAge = maleAges.Count > 0 ? maleAges.Average() : 0;
            var femaleAvgAge = femaleAges.Count > 0 ? femaleAges.Average() : 0;

            return (maleAvgAge, femaleAvgAge);
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        
    }
}
