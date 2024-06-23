using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mapping
{
    public static class DTOMapperExtension
    {
        public static T MapTo<T>(this object value)
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new IgnoreTaskConverter() }
            };

            var json = JsonSerializer.Serialize(value, options);
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }

    public class IgnoreTaskConverter : JsonConverter<Task>
    {
        public override Task Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }

        public override void Write(Utf8JsonWriter writer, Task value, JsonSerializerOptions options)
        {
            // Do nothing, effectively ignoring Task properties
        }
    }

}
