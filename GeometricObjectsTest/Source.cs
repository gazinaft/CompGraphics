using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GeometricObjectsTest
{
    abstract class Source<T> : IEnumerable
    {
        public const string TestsFullPathDirectory = @"C:\Users\Mihailo\Source\Repos\gazinaft\CompGraphics\GeometricObjectsTest\Values\";

        protected abstract string FileName { get; }

        private IEnumerable<T> Read()
        {
            string testDirectoryPath = Path.Combine(TestsFullPathDirectory, FileName);
            JsonSerializerOptions options = new();

            //замість явних зв'язків можливо підставити DI, але я 1628 так викручуватись, тим більш для тестів
            using FileStream fileStream = new(testDirectoryPath, FileMode.Open);
            using StreamReader reader = new(fileStream);

            var json = reader.ReadToEnd();
            var converters = GetConverters();
            foreach (var item in converters)
            {
                options.Converters.Add(item);
            }
            var values = JsonSerializer.Deserialize<List<T>>(json, options);

            if (values == null) throw new NullReferenceException();

            return values;
        }

        //can be overriden for some jojo bizarre arguments
        protected virtual IEnumerable<object[]> CastToObjects(IEnumerable<T> values)
        {
            var argsProperties = typeof(T).GetProperties();

            foreach (var arg in values)
            {
                int length = argsProperties.Length;
                object[] args = new object[length];
                for (int i = 0; i < length; i++)
                {
                    args[i] = argsProperties[i].GetValue(arg)!;
                }
                yield return args;
            }
        }

        protected virtual IEnumerable<JsonConverter> GetConverters()
        {
            yield break;
        }

        public IEnumerator GetEnumerator()
        {
            var values = Read();
            return CastToObjects(values).GetEnumerator();
        }
    }
}
