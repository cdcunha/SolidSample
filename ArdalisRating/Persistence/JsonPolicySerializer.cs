using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating.Persistence
{
    public static class JsonPolicySerializer
    {
        public static Policy GetPolicyFromJsonString(string policyJson)
        {
            if (string.IsNullOrWhiteSpace(policyJson))
            {
                policyJson = "{}";
            }

            return JsonConvert.DeserializeObject<Policy>(policyJson, new StringEnumConverter());
        }

        public static string GetJsonStringFromPolicy(Policy policy)
        {
            return JsonConvert.SerializeObject(policy); ;
        }
    }
}
