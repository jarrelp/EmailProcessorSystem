// using AutoMapper;
// using OracleFetchApi.Events;

// namespace OracleFetchApi.Mapping;

// public class EmailQueueMappingProfile : Profile
// {
//     public EmailQueueMappingProfile()
//     {
//         CreateMap<EmailQueueItem, LoginIntegrationEvent>()
//             .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
//             .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.XmlData is Login login ? login.EmailId : 0))
//             .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.XmlData is Login login ? login.Fullname : string.Empty))
//             .ForMember(dest => dest.Environment, opt => opt.MapFrom(src => src.XmlData is Login login ? login.Environment : string.Empty))
//             .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.XmlData is Login login ? login.Date.ToString() : string.Empty))
//             .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.XmlData is Login login ? login.Time.ToString() : string.Empty))
//             .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
//             .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

//         CreateMap<EmailQueueItem, OverdueIntegrationEvent>()
//             .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
//             .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.XmlData is Overdue overdue ? overdue.EmailId : 0))
//             .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.XmlData is Overdue overdue ? overdue.Fullname : string.Empty))
//             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.XmlData is Overdue overdue ? overdue.Email : string.Empty))
//             .ForMember(dest => dest.ProductNumber, opt => opt.MapFrom(src => src.XmlData is Overdue overdue ? overdue.Productnr : string.Empty))
//             .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.XmlData is Overdue overdue ? overdue.Productname : string.Empty))
//             .ForMember(dest => dest.OrderCode, opt => opt.MapFrom(src => src.XmlData is Overdue overdue ? overdue.Ordercode : string.Empty))
//             .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.XmlData is Overdue overdue ? overdue.Orderdate.ToString() : string.Empty))
//             .ForMember(dest => dest.OverdueDate, opt => opt.MapFrom(src => src.XmlData is Overdue overdue ? overdue.Overduedate.ToString() : string.Empty))
//             .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
//             .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

//         CreateMap<EmailQueueItem, ReportIntegrationEvent>()
//             .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
//             .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.XmlData is Report report ? report.EmailId : 0))
//             .ForMember(dest => dest.PortalName, opt => opt.MapFrom(src => src.XmlData is Report report ? report.Portalname : string.Empty))
//             .ForMember(dest => dest.ReportName, opt => opt.MapFrom(src => src.XmlData is Report report ? report.Reportname : string.Empty))
//             .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.XmlData is Report report ? report.Url : string.Empty))
//             .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
//             .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

//         CreateMap<EmailQueueItem, UserIntegrationEvent>()
//             .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
//             .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.XmlData is User user ? user.EmailId : 0))
//             .ForMember(dest => dest.ImageHeader, opt => opt.MapFrom(src => src.XmlData is User user ? user.ImageHeader : string.Empty))
//             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.XmlData is User user ? user.Email : string.Empty))
//             .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.XmlData is User user ? user.Fullname : string.Empty))
//             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.XmlData is User user ? user.Username : string.Empty))
//             .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.XmlData is User user ? user.Password : string.Empty))
//             .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.XmlData is User user ? user.Company : string.Empty))
//             .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.XmlData is User user ? user.Url : string.Empty))
//             .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
//             .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));
//     }
// }
