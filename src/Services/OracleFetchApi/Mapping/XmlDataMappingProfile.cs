// using AutoMapper;
// using OracleFetchApi.Model.EmailTemplates;
// using System.Xml.Linq;
// using System.Xml.Serialization;

// namespace OracleFetchApi.Mapping;

// public class XmlDataMappingProfile : Profile
// {
//     public XmlDataMappingProfile()
//     {
//         CreateMap<string, XmlData>()
//             .ConvertUsing<XmlDataConverter>();
//     }
// }

// public class XmlDataConverter : ITypeConverter<string, XmlData>
// {
//     public XmlData Convert(string source, XmlData destination, ResolutionContext context)
//     {
//         if (string.IsNullOrEmpty(source))
//             return null;

//         try
//         {
//             var doc = XDocument.Parse(source);
//             var root = doc.Root.Name.LocalName;

//             switch (root)
//             {
//                 case "login":
//                     return DeserializeXml<Login>(source);
//                 case "overdue":
//                     return DeserializeXml<Overdue>(source);
//                 case "report":
//                     return DeserializeXml<Report>(source);
//                 case "user":
//                     return DeserializeXml<User>(source);
//                 default:
//                     throw new InvalidOperationException("Unknown XML data type.");
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error deserializing XML data: {ex.Message}");
//             return null;
//         }
//     }

//     private T DeserializeXml<T>(string xmlData) where T : XmlData
//     {
//         var serializer = new XmlSerializer(typeof(T));
//         using (var reader = new StringReader(xmlData))
//         {
//             return (T)serializer.Deserialize(reader);
//         }
//     }
// }