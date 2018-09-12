using System.Collections.Generic;
// reflection namespace
namespace WEB.UnderWriting.Common
{
    public static class UnderwritingCallHelper
    {
        public class test
        {
            public string ase { get; set; }
            public string ase2 { get; set; }
        }

        public static void FillUnderwritingTemplate()
        {
            var testString = "{ase} es diferente de {ase2}";
            var t = new test { ase = "1", ase2 = "2" };

            var propertyInfos = typeof(test).GetProperties();
            var propertyNames = new List<string>();

            for (int i = 0; i < propertyInfos.Length; i++)
                propertyNames.Add(propertyInfos[i].Name);

            var counter = 0;

            foreach (var item in propertyInfos)
            {
                var val = propertyInfos[counter].GetValue(t).ToString();
                testString = testString.Replace("{" + propertyNames[counter] + "}", val);
                counter++;
            }
        }
    }
}

