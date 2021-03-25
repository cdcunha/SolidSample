using System;

namespace ArdalisRating.Persistence
{
    public static class FilePolicySource
    {
        public static string FileName => "policy.json";

        public static string GetPolicyFromSource()
        {
            if (System.IO.File.Exists(FileName))
            {
                return System.IO.File.ReadAllText(FileName);
            }
            else
            {
                SavePolicyToSource();
                return GetPolicyFromSource();
            }
        }

        public static void SavePolicyToSource(string json = "{}")
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                json = "{}";
            }

            System.IO.File.WriteAllText(FileName, json);
        }
    }
}
