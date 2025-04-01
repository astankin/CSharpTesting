using Newtonsoft.Json.Linq;
using OpenQA.Selenium.DevTools.V131.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.utilities
{
    class JsonReader
    {
        public JsonReader() 
        {
        } 
        public string? getData(String tokenName)
        {
            string jsonString = File.ReadAllText("testData.json");
            var jsonObject = JToken.Parse(jsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

    }
}
