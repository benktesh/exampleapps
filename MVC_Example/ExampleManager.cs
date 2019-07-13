using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Example
{
    public class ExampleManager
    {

        public static int GetPersonAge(DateTime? birthDay, DateTime endDate)
        {

            if (birthDay == null)
            {
                throw new ArgumentNullException($"Cannot calculate Age"); 
            }
            
            int years = endDate.Year - birthDay.Value.Year;

            if (birthDay.Value.Month > endDate.Month || (birthDay.Value.Month == endDate.Month &&
                                                   birthDay.Value.Day > endDate.Day))
                years--;

            return years;
        }
    }
}
