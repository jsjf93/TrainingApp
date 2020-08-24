﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Train.Domain.Models.Sets;
using Train.Domain.Models.Sets.Base;

namespace Train.Domain.Converters
{
    public class ExerciseSetSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(ExerciseSet).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null;
            return base.ResolveContractConverter(objectType);
        }
    }

    public class ExerciseSetConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings()
        {
            ContractResolver = new ExerciseSetSpecifiedConcreteClassConverter()
        };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ExerciseSet));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            switch (jo["exerciseType"].Value<int>())
            {
                case 0:
                    return JsonConvert.DeserializeObject<DurationSet>(jo.ToString(), SpecifiedSubclassConversion);
                case 1:
                    return JsonConvert.DeserializeObject<IntervalSet>(jo.ToString(), SpecifiedSubclassConversion);
                case 2:
                    return JsonConvert.DeserializeObject<StrengthSet>(jo.ToString(), SpecifiedSubclassConversion);
                default:
                    throw new NotImplementedException();
            }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
