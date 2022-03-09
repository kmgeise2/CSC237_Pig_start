using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CSC237_Pig_start.Models
{
    //Extend the ISession interface with two generic methods
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var jsonString = session.GetString(key);
            if (string.IsNullOrEmpty(jsonString))
                return default(T); //default litteral expression
            else
                return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
