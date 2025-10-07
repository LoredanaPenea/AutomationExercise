using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.WebHelperMethods
{
    public class DateParserMethod
    {
        private static readonly string[] SupportedFormats = new[]
        {
        "d/M/yyyy", "dd/MM/yyyy",
        "d/MMM/yyyy", "dd/MMM/yyyy",
        "d MMM yyyy", "d MMMM yyyy",
        "dd MMM yyyy", "dd MMMM yyyy"
         };
        public static bool TryParse(string input, out DateTime date)
        {
            return DateTime.TryParseExact(
                input.Trim(),
                SupportedFormats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date
            );
        }

        //optional - iset f I set DateOfBirth as string
        public (string Day, string Month, string Year) Parse(string dateString)
        {
            if (!TryParse(dateString, out DateTime dob))
                throw new FormatException($"Invalid date format: '{dateString}'");

            return (
                dob.Day.ToString(),
                dob.ToString("MMMM"),
                dob.Year.ToString()
            );
        }
    }
}
