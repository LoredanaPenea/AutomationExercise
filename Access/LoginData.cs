using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationExercise.Access
{
    public partial class LoginData
    {
        private XElement dataXMLNode;
        public LoginData(int dataSetNumber)
        {
            LoadDataFromXML(dataSetNumber);
            EmailAddress = GetValue("EmailAddress");
            Password = GetValue("Password");
        }

        private string GetValue(string nodeName)
        {
            var element = dataXMLNode.Element(nodeName);
            return element != null ? element.Value?.Trim() : string.Empty;
        }

        private void LoadDataFromXML(int dataSetNumber)
        {
            string filePath = Path.Combine("C:\\Users\\npenea\\source\\repos\\AutomationExercise\\Resources\\LoginData.xml");
            XDocument document = XDocument.Load(filePath);

            string nodeName = $"dataSet_{dataSetNumber}";
            dataXMLNode = document.Root.Element(nodeName);

            if (dataXMLNode == null)
                throw new Exception($"Data set {dataSetNumber} not found in XML file");
            //  else Console.WriteLine($"Loaded node: {dataNode}");
        }
    }
}
