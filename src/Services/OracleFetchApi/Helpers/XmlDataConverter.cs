// using System.Xml.Linq;
// using AutoMapper;

// namespace OracleFetchApi.Helpers;

// public class MappingProfile : Profile
// {
//     public MappingProfile()
//     {
//         CreateMap<XElement, XmlData>().ConvertUsing<XmlDataConverter>();
//     }
// }

// public class XmlDataConverter : ITypeConverter<XElement, XmlData>
// {
//     public XmlData Convert(XElement source, XmlData destination, ResolutionContext context)
//     {
//         if (source == null)
//             return null;

//         if (source.Element("login") != null)
//         {
//             return new Login
//             {
//                 FullName = (string)source.Element("login").Element("fullname"),
//                 Environment = (string)source.Element("login").Element("environment"),
//                 IPAddress = (string)source.Element("login").Element("ipaddress"),
//                 Date = (DateTime)source.Element("login").Element("date"),
//                 Time = TimeSpan.Parse((string)source.Element("login").Element("time"))
//             };
//         }

//         if (source.Element("overdue") != null)
//         {
//             return new Overdue
//             {
//                 FullName = (string)source.Element("overdue").Element("fullname"),
//                 Email = (string)source.Element("overdue").Element("email"),
//                 ProductNumber = (string)source.Element("overdue").Element("productnr"),
//                 ProductName = (string)source.Element("overdue").Element("productname"),
//                 OrderCode = (string)source.Element("overdue").Element("ordercode"),
//                 OrderDate = (DateTime)source.Element("overdue").Element("orderdate"),
//                 OverdueDate = (DateTime)source.Element("overdue").Element("overduedate")
//             };
//         }

//         if (source.Element("report") != null)
//         {
//             return new Report
//             {
//                 PortalName = (string)source.Element("report").Element("portalname"),
//                 ReportName = (string)source.Element("report").Element("reportname"),
//                 Url = (string)source.Element("report").Element("url")
//             };
//         }

//         if (source.Element("user") != null)
//         {
//             return new User
//             {
//                 Email = (string)source.Element("user").Element("email"),
//                 FullName = (string)source.Element("user").Element("fullname"),
//                 UserName = (string)source.Element("user").Element("username"),
//                 Password = (string)source.Element("user").Element("password"),
//                 // Company = (string)source.Element("user").Element("company"),
//                 Url = (string)source.Element("user").Element("url")
//             };
//         }

//         return null;
//     }
// }