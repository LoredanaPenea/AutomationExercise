using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.WebHelperMethods
{
    public class XMLValueParser
    {
        public bool GetBoolValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            switch (value.Trim().ToLowerInvariant())
            {
                case "true":
                case "yes":
                case "1":
                    return true;
                case "false":
                case "no":
                case "0":
                    return false;
                default:
                    throw new FormatException($"Invalid boolean value: {value}");
            }
        }
    }
}
