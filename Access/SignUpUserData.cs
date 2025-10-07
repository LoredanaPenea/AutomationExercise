using AutomationExercise.WebHelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.Autofill;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationExercise.Access
{
    public partial class SignUpUserData
    {
        private XElement dataXMLNode;
        public SignUpUserData(int dataSetNumber)
        {
            LoadDataFromXML(dataSetNumber);
            Title = GetValue("Title");
            Name = GetValue("Name");
            Email = GetValue("Email");
            Password = GetValue("Password");

           // DateOfBirth = GetValue("DateOfBirth");
            //date of birth 
             string DateOfBirthString = GetValue("DateOfBirth");
              if (!string.IsNullOrWhiteSpace(DateOfBirthString) &&
                   DateTime.TryParseExact(DateOfBirthString, new[] { "dd MMM yyyy","dd MMMM yyyy","d MMM yyyy", "d MMMM yyyy"}, 
                   CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                  DateOfBirth = parsedDate;
              else
              {
                  // Optionally handle missing DOB
                  Console.WriteLine("Date of Birth invalid or missing");
                  DateOfBirth = DateTime.Now;
              }
            // SubscribeToNewsletter = bool.TryParse(GetValue("SubscribeToNewsletter"), out bool subscribe) && subscribe;

            SubscribeToNewsletter = GetBoolValue(GetValue("SubscribeToNewsletter"));
            ReceiveSpecialOffers = GetBoolValue(GetValue("ReceiveSpecialOffers"));

            //SubscribeToNewsletter = XMLValueParser.GetBoolValue(GetValue("SubscribeToNewsletter"));


            FirstName = GetValue("FirstName");
            LastName = GetValue("LastName");
            Company = GetValue("Company");
            Address = GetValue("Address");
            Address2 = GetValue("Address2");
            Country = GetValue("Country");
            State = GetValue("State");
            City = GetValue("City");
            Zipcode = GetValue("Zipcode");
            MobileNumber = GetValue("MobileNumber");
        }

        private string GetValue(string nodeName)
        {
            var element = dataXMLNode.Element(nodeName);
            return element != null ? element.Value?.Trim() : string.Empty;
        }

        private void LoadDataFromXML(int dataSetNumber)
        {
            string filePath = Path.Combine("C:\\Users\\npenea\\source\\repos\\AutomationExercise\\Resources\\SignUpUserData.xml");
            XDocument document = XDocument.Load(filePath);

            string nodeName = $"dataSet_{dataSetNumber}";
            dataXMLNode = document.Root.Element(nodeName);

            if (dataXMLNode == null)
                throw new Exception($"Data set {dataSetNumber} not found in XML file");
            //  else Console.WriteLine($"Loaded node: {dataNode}");
        }

        private bool GetBoolValue(string value)
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
