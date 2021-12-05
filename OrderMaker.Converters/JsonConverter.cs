using AutoMapper;
using Newtonsoft.Json;

namespace OrderMaker.Converters
{
    public class JsonConverter
    {
        private readonly JsonSerializerSettings _settings;
        private readonly Mapper _mapper;
        
        public JsonConverter(JsonSerializerSettings settings, Mapper mapper)
        {
            _settings = settings;
            _mapper = mapper;
        }
        
        public string Serialize<TClass, TClassDto>(TClass obj)
        {
            var objDto = _mapper.Map<TClassDto>(obj);
            var objString = JsonConvert.SerializeObject(objDto, _settings);
            return objString;
        }

        public TClass Deserialize<TClass, TClassDto>(string objString)
        {
            var objDto = JsonConvert.DeserializeObject<TClassDto>(objString);
            var obj = _mapper.Map<TClass>(objDto);
            return obj;
        }
    }
}