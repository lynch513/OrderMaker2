using AutoMapper;
using Newtonsoft.Json;
using OrderMaker.Converters.DTO;

namespace OrderMaker.Converters
{
    public class JsonConverter<TClass, TClassDto>
    {
        private readonly JsonSerializerSettings _settings;
        private readonly Mapper _mapper;
        
        public JsonConverter(FormatType format = FormatType.Indent)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TClass, TClassDto>();
                cfg.CreateMap<TClassDto, TClass>();
            });
            _mapper = new Mapper(config);
            _settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = format switch
                {
                    FormatType.None => Formatting.None,
                    _ => Formatting.Indented
                }
            };
        }
        
        public string Serialize(TClass obj)
        {
            var objDto = _mapper.Map<TClassDto>(obj);
            var objString = JsonConvert.SerializeObject(objDto, _settings);
            return objString;
        }

        public TClass Deserialize(string objString)
        {
            var objDto = JsonConvert.DeserializeObject<PersonDto>(objString);
            var obj = _mapper.Map<TClass>(objDto);
            return obj;
        }
    }
}