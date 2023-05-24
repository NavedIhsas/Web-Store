using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace infrastructure.Extensions
{
    //Add to startup this code

    //services.AddSession();
    //services.AddDistributedMemoryCache();
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }


        public static T GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data == null ? default(T) : JsonConvert.DeserializeObject<T>(data);
        }
    }
}
