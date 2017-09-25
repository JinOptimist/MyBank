using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;

namespace MyBank
{
    public static class SerializeHelper
    {
        public static string Serialize<T>(T obj)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(obj);
            return json;
        }

        public static T Deserialize<T>(string json)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var model = jsonSerialiser.Deserialize<T>(json);
            return model;
        }
    }
}
