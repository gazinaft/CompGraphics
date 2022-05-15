using GeometricObjects.Basic;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GeometricObjectsTest.Sources
{
    class Vector_Normalize_Normalized_Source : Source<Vector_Normalize_Normalized_Source.Args>
    {
        protected override string FileName => @"Vector-Normal-Values.json";

        protected override IEnumerable<JsonConverter> GetConverters()
        {
            yield return new NormalJsonConverter();
        }

        internal class Args
        {
            public Vector? Vector { get; set; }
            public Normal? Normal { get; set; }
        }

        class NormalJsonConverter : JsonConverter<Normal>
        {
            public override Normal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                Dictionary<string, double> args = new()
                {
                    { "x", 0 },
                    { "y", 0 },
                    { "z", 0 },
                };
                List<string> usedProps = new();
                string propName;

                if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();
                reader.Read();
                for (int i = 0; i < args.Count; i++)
                {
                    propName = reader.GetString()!.ToLower();
                    if (usedProps.Contains(propName)) throw new JsonException();
                    if (!args.ContainsKey(propName)) throw new JsonException();
                    reader.Read();
                    args[propName] = reader.GetDouble();
                    usedProps.Add(propName);
                    reader.Read();
                }
                if (reader.TokenType != JsonTokenType.EndObject) throw new JsonException();

                Vector vector = new(args["x"], args["y"], args["z"]);
                Normal normal = new(vector);

                return normal;
            }

            public override void Write(Utf8JsonWriter writer, Normal value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                writer.WriteNumber("x", value.X);
                writer.WriteNumber("y", value.Y);
                writer.WriteNumber("z", value.Z);
                writer.WriteEndObject();
            }
        }
    }
}
