using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Business
{
    public static class Json
    {
        public static object ToJson(this string Json) => Json == null ? (object)null : JsonConvert.DeserializeObject(Json);

        public static string ToJson(this object obj)
        {
            IsoDateTimeConverter dateTimeConverter = new IsoDateTimeConverter()
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
            return JsonConvert.SerializeObject(obj, (JsonConverter)dateTimeConverter);
        }

        public static string ToJson(this object obj, string datetimeformats)
        {
            IsoDateTimeConverter dateTimeConverter = new IsoDateTimeConverter()
            {
                DateTimeFormat = datetimeformats
            };
            return JsonConvert.SerializeObject(obj, (JsonConverter)dateTimeConverter);
        }

        public static T ToObject<T>(this string Json) => Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);

        public static List<T> ToList<T>(this string Json) => Json == null ? (List<T>)null : JsonConvert.DeserializeObject<List<T>>(Json);

        public static DataTable ToTable(this string Json) => Json == null ? (DataTable)null : JsonConvert.DeserializeObject<DataTable>(Json);

        public static JObject ToJObject(this string Json) => Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
    }
}
