using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class ValidatationConversion
    {
        /// <summary>
        /// Method for checking if the input text from user can be converted to an integer
        /// </summary>
        /// <param name="input">String input from user</param>
        /// <returns>bool</returns>
        public static bool CanBeConverted(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Method for convering an input string to integer
        /// </summary>
        /// <param name="input">The text input from the user</param>
        /// <returns>int</returns>
        public static int ConvertToInt(string input)
        {
            return int.Parse(input);
        }
    }
}
