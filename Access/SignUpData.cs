using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationExercise.Access
{
    public partial class SignUpData
    {
        private XElement dataXMLNode;
        public SignUpData(int dataSetNumber)
        {
            LoadDataFromXML(dataSetNumber);
            Name = GetValue("Name");
            EmailAddress = GetValue("EmailAddress");
        }

        private string GetValue(string nodeName)
        {
            var element = dataXMLNode.Element(nodeName);
            return element != null ? element.Value?.Trim() : string.Empty;
        }

        private void LoadDataFromXML(int dataSetNumber)
        {
            string filePath = Path.Combine("C:\\Users\\npenea\\source\\repos\\AutomationExercise\\Resources\\SignUpData.xml");
            XDocument document = XDocument.Load(filePath);

            string nodeName = $"dataSet_{dataSetNumber}";
            dataXMLNode = document.Root.Element(nodeName);

            if (dataXMLNode == null)
                throw new Exception($"Data set {dataSetNumber} not found in XML file");
            //  else Console.WriteLine($"Loaded node: {dataNode}");
        }
    }
}
