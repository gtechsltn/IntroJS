using Newtonsoft.Json;
using System.Diagnostics;

namespace IntroJS.Models
{
    public static class ExtensionsForTesting
    {
        public static void Dump(this object obj)
        {
            Debug.WriteLine(obj.DumpString());
        }

        public static string DumpString(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}