using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using Newtonsoft.Json;

namespace CommonsAPI.Serialize
{
    public class JavaScriptSerializerHelper
    {
        public static string Serialize(object obj)
        {
            string objSerializado = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind
            });
            return objSerializado;
        }

        public static ObjType Deserialize<ObjType>(string objSerializado)
        {
            ObjType obj = JsonConvert.DeserializeObject<ObjType>(objSerializado, new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind
            });
            return obj;
        }
    }
}
