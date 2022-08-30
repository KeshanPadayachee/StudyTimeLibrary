using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTimeLibrary
{
    public class Validation
    {
        // Validating text to consist of only integers
        public static bool validateInteger(string input)
        {
            int number = 0;
            return int.TryParse(input, out number);
        }

        // Validating text to consist of only letters
        public static bool validateString(string input)
        {
            return input.All(Char.IsLetter);
        }

        // Validating text to be of type double
        public static bool validateDouble(string input)
        {
            double number = 0;
            return Double.TryParse(input, out number);
        }

        
    }
}
