// using FakeOracleFetchApi.Model.EmailTemplates;

// namespace FakeOracleFetchApi.Infrastructure.EntityConfigurations;

// public class EmailQueueEntityTypeConfiguration : IEntityTypeConfiguration<EmailQueue>
// {
//     public void Configure(EntityTypeBuilder<EmailQueue> builder)
//     {
//         builder.ToTable("EmailQueue");

//         builder.HasKey(emailQueue => emailQueue.EmailQueueId);

//         builder.HasOne(e => e.EmailTemplate)
//         .WithOne()
//         .HasForeignKey<EmailTemplate>(e => e.Id);

//         // builder.HasOne(emailQueue => emailQueue.EmailTemplate)
//         //     .WithOne()
//         //     .HasForeignKey<EmailTemplate>(emailTemplate => emailTemplate.Id);

//         // builder.OwnsOne(e => e.EmailTemplate);

//         var email1 = new EmailQueue(11500, "ORDER", "aangepast@email.adr")
//         {
//             EmailTemplate = GenerateOrderData1()
//         };
//         var email2 = new EmailQueue(11501, "ORDER", "dizzel@dizzel.dizz")
//         {
//             EmailTemplate = GenerateOrderData2()
//         };
//         var email3 = new EmailQueue(11502, "LOGIN", "aangepast@email.adr")
//         {
//             EmailTemplate = GenerateLoginData1()
//         };
//         var email4 = new EmailQueue(11503, "LOGIN", "dizzel@dizzel.dizz")
//         {
//             EmailTemplate = GenerateLoginData2()
//         };
//         var email5 = new EmailQueue(11504, "OVERDUE", "aangepast@email.adr")
//         {
//             EmailTemplate = GenerateOverdueData1()
//         };
//         var email6 = new EmailQueue(11505, "OVERDUE", "dizzel@dizzel.dizz")
//         {
//             EmailTemplate = GenerateOverdueData2()
//         };
//         var email7 = new EmailQueue(11506, "REPORT", "aangepast@email.adr")
//         {
//             EmailTemplate = GenerateReportData1()
//         };
//         var email8 = new EmailQueue(11507, "REPORT", "dizzel@dizzel.dizz")
//         {
//             EmailTemplate = GenerateReportData2()
//         };
//         var email9 = new EmailQueue(11508, "USER", "aangepast@email.adr")
//         {
//             EmailTemplate = GenerateUserData1()
//         };
//         var email10 = new EmailQueue(11509, "USER", "dizzel@dizzel.dizz")
//         {
//             EmailTemplate = GenerateUserData2()
//         };

//         builder.HasData(
//             email1, email2, email3, email4, email5, email6, email7, email8, email9, email10
//         );
//     }

//     public User GenerateUserData1()
//     {
//         string imageHeader = "header.jpg";
//         string email = "john.doe@example.com";
//         string fullName = "John Doe";
//         string userName = "johndoe";
//         string password = "password123";
//         string company = "Example Company";
//         string url = "http://example.com";

//         User userData = new User(imageHeader, email, fullName, userName, password, company, url);
//         return userData;
//     }

//     public User GenerateUserData2()
//     {
//         string imageHeader = "header.jpg";
//         string email = "gerrit.janssen@example.com";
//         string fullName = "Gerrit Janssen";
//         string userName = "gerritjanssen";
//         string password = "password123";
//         string company = "Example Company";
//         string url = "http://example.com";

//         User userData = new User(imageHeader, email, fullName, userName, password, company, url);
//         return userData;
//     }
//     public Report GenerateReportData1()
//     {
//         string portalName = "Portal X";
//         string reportName = "Monthly Sales Report";
//         string url = "http://example.com/reports/monthly-sales";

//         Report reportData = new Report(portalName, reportName, url);
//         return reportData;
//     }

//     public Report GenerateReportData2()
//     {
//         string portalName = "Portal Y";
//         string reportName = "Monthly Sales Report";
//         string url = "http://example.com/reports/monthly-sales";

//         Report reportData = new Report(portalName, reportName, url);
//         return reportData;
//     }

//     public Overdue GenerateOverdueData1()
//     {
//         string fullName = "John Doe";
//         string email = "john.doe@example.com";
//         string productNumber = "PROD1";
//         string productName = "Product X";
//         string orderCode = "ORDER1";
//         string orderDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
//         string overdueDate = DateTime.Now.ToString("yyyy-MM-dd");

//         Overdue overdueData = new Overdue(fullName, email, productNumber, productName, orderCode, orderDate, overdueDate);
//         return overdueData;
//     }

//     public Overdue GenerateOverdueData2()
//     {
//         string fullName = "Gerrit Janssen";
//         string email = "gerrit.janssen@example.com";
//         string productNumber = "PROD2";
//         string productName = "Product Y";
//         string orderCode = "ORDER2";
//         string orderDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
//         string overdueDate = DateTime.Now.ToString("yyyy-MM-dd");

//         Overdue overdueData = new Overdue(fullName, email, productNumber, productName, orderCode, orderDate, overdueDate);
//         return overdueData;
//     }

//     public Login GenerateLoginData1()
//     {
//         string fullName = "John Doe";
//         string environment = "Production";
//         string date = DateTime.Now.ToString("yyyy-MM-dd");
//         string time = DateTime.Now.ToString("HH:mm:ss");

//         Login loginData = new Login(fullName, environment, date, time);
//         return loginData;
//     }

//     public Login GenerateLoginData2()
//     {
//         string fullName = "Gerrit Janssen";
//         string environment = "Production";
//         string date = DateTime.Now.ToString("yyyy-MM-dd");
//         string time = DateTime.Now.ToString("HH:mm:ss");

//         Login loginData = new Login(fullName, environment, date, time);
//         return loginData;
//     }

//     private Order GenerateOrderData1()
//     {
//         var integrationConfigs = new IntegrationConfigs
//         {
//             Configs = new[]
//             {
//                 new Config("Tool1", "UniqueIdentifier1"),
//                 new Config("Tool2", "UniqueIdentifier2")
//             }
//         };

//         var orderNotes = new OrderNotes
//         {
//             Notes = new[]
//             {
//                 new OrderNote("Description1", "Person1", "NoteGroup1", "CreatedOn1", "CreatedBy1", "ModifiedOn1", "ModifiedBy1"),
//                 new OrderNote("Description2", "Person2", "NoteGroup2", "CreatedOn2", "CreatedBy2", "ModifiedOn2", "ModifiedBy2")
//             }
//         };

//         var orderAttributes = new OrderAttributes
//         {
//             Attributes = new[]
//             {
//                 new OrderAttribute("Description1", "Value1", "UserVisibility1", "ExternalId1", "Validation1"),
//                 new OrderAttribute("Description2", "Value2", "UserVisibility2", "ExternalId2", "Validation2")
//             }
//         };

//         var purchaserPerson = new PurchaserPerson(
//             "PersonId1", "ExternalPersonId1", "GenderId1", "FirstName1", "LastName1",
//             "MiddleName1", "FullName1", "UserName1", "Title1", "Suffix1", "Prefix1",
//             "Remarks1", "Email1", "Company1", "CompanyId1", "Function1", "ExternalFunctionId1",
//             "EmploymentType1", "ExternalEmploymentTypeId1", "Acronym1", "ProjectCode1", "Saldo1");

//         var addresses = new List<Address>
//         {
//             new Address("ClassId1", "ProjectCode1", "AddressTypeId1", "Preamble1", "Street1", "Extra1", "PrimaryNumber1", "AdditionalNumber1", "ZipCode1", "City1", "State1", "CountryCode1", "CountryCode21", "DateFrom1", "DateCreated1"),
//             new Address("ClassId2", "ProjectCode2", "AddressTypeId2", "Preamble2", "Street2", "Extra2", "PrimaryNumber2", "AdditionalNumber2", "ZipCode2", "City2", "State2", "CountryCode2", "CountryCode22", "DateFrom2", "DateCreated2")
//         };

//         var payments = new Payments("Factor1")
//         {
//             Payment = new Payment("Type1", "Amount1", "Paid1")
//         };

//         var orderDetailList = new OrderDetailList
//         {
//             OrderDetails = new List<OrderDetail>
//             {
//                 new OrderDetail(
//                     "OrderDetailId1", "ProductId1", "SupplierProductId1", "ProductCode1", "ProductName1", "Quantity1",
//                     "Price1", "PriceExVat1", "PriceIncVat1", "PriceVatOnly1", "VatPercentage1", "DetailType1", "Size1",
//                     "AssortmentId1", "Status1", "NumberNotDeliverable1", "NumberBackOrder1", "NumberSend1", "NumberReceived1",
//                     "NumberDeliverable1", "SetGroupName1", "SetGroupIdExtern1", "SetDateStart1", "DateModified1",
//                     "DeliveryDate1", "Remark1")
//             }
//         };

//         return new Order(
//             1, "ParentOrderCode1", "OrderType1", "Type1", "Source1", "Status1", "StartSet1", "Email11", "Email21",
//             "ConsigneeId1", "PurchaserId1", "PurchaserComment1", "PurchaserExtern1", "PurchaserFirstname1", "PurchaserLastname1",
//             "PurchaserMiddlename1", "PurchaserFullname1", "PurchaserUsername1", "PurchaserEmail1", "PersonEdit1",
//             "PurchaserFunction1", "PurchaserFunctionIdExtern1", "PurchaserEmploymentType1", "PurchaserEmploymentTypeIdExtern1",
//             "Total1", "TotalExVAT1", "TotalVAT1",
//             // "VATValue1",
//             "DateRequired1", "DateDeliver1", "DateCreated1",
//             "DateEdit1", "OrderCode1", "Remarks1", "PayType1", "ImgHeader1", "CompanyBaseUrl1")
//         {
//             IntegrationConfigs = integrationConfigs,
//             OrderNotes = orderNotes,
//             OrderAttributes = orderAttributes,
//             PurchaserPerson = purchaserPerson,
//             Addresses = addresses,
//             Payments = payments,
//             OrderDetailList = orderDetailList
//         };
//     }

//     private Order GenerateOrderData2()
//     {
//         var integrationConfigs = new IntegrationConfigs
//         {
//             Configs = new[]
//             {
//                 new Config("Tool3", "UniqueIdentifier3"),
//                 new Config("Tool4", "UniqueIdentifier4")
//             }
//         };

//         var orderNotes = new OrderNotes
//         {
//             Notes = new[]
//             {
//                 new OrderNote("Description3", "Person3", "NoteGroup3", "CreatedOn3", "CreatedBy3", "ModifiedOn3", "ModifiedBy3"),
//                 new OrderNote("Description4", "Person4", "NoteGroup4", "CreatedOn4", "CreatedBy4", "ModifiedOn4", "ModifiedBy4")
//             }
//         };

//         var orderAttributes = new OrderAttributes
//         {
//             Attributes = new[]
//             {
//                 new OrderAttribute("Description3", "Value3", "UserVisibility3", "ExternalId3", "Validation3"),
//                 new OrderAttribute("Description4", "Value4", "UserVisibility4", "ExternalId4", "Validation4")
//             }
//         };

//         var purchaserPerson = new PurchaserPerson(
//             "PersonId2", "ExternalPersonId2", "GenderId2", "FirstName2", "LastName2",
//             "MiddleName2", "FullName2", "UserName2", "Title2", "Suffix2", "Prefix2",
//             "Remarks2", "Email2", "Company2", "CompanyId2", "Function2", "ExternalFunctionId2",
//             "EmploymentType2", "ExternalEmploymentTypeId2", "Acronym2", "ProjectCode2", "Saldo2");

//         var addresses = new List<Address>
//         {
//             new Address("ClassId3", "ProjectCode3", "AddressTypeId3", "Preamble3", "Street3", "Extra3", "PrimaryNumber3", "AdditionalNumber3", "ZipCode3", "City3", "State3", "CountryCode3", "CountryCode23", "DateFrom3", "DateCreated3"),
//             new Address("ClassId4", "ProjectCode4", "AddressTypeId4", "Preamble4", "Street4", "Extra4", "PrimaryNumber4", "AdditionalNumber4", "ZipCode4", "City4", "State4", "CountryCode4", "CountryCode24", "DateFrom4", "DateCreated4")
//         };

//         var payments = new Payments("Factor2")
//         {
//             Payment = new Payment("Type2", "Amount2", "Paid2")
//         };

//         var orderDetailList = new OrderDetailList
//         {
//             OrderDetails = new List<OrderDetail>
//             {
//                 new OrderDetail(
//                     "OrderDetailId2", "ProductId2", "SupplierProductId2", "ProductCode2", "ProductName2", "Quantity2",
//                     "Price2", "PriceExVat2", "PriceIncVat2", "PriceVatOnly2", "VatPercentage2", "DetailType2", "Size2",
//                     "AssortmentId2", "Status2", "NumberNotDeliverable2", "NumberBackOrder2", "NumberSend2", "NumberReceived2",
//                     "NumberDeliverable2", "SetGroupName2", "SetGroupIdExtern2", "SetDateStart2", "DateModified2",
//                     "DeliveryDate2", "Remark2")
//             }
//         };

//         return new Order(
//             2, "ParentOrderCode2", "OrderType2", "Type2", "Source2", "Status2", "StartSet2", "Email12", "Email22",
//             "ConsigneeId2", "PurchaserId2", "PurchaserComment2", "PurchaserExtern2", "PurchaserFirstname2", "PurchaserLastname2",
//             "PurchaserMiddlename2", "PurchaserFullname2", "PurchaserUsername2", "PurchaserEmail2", "PersonEdit2",
//             "PurchaserFunction2", "PurchaserFunctionIdExtern2", "PurchaserEmploymentType2", "PurchaserEmploymentTypeIdExtern2",
//             "Total2", "TotalExVAT2", "TotalVAT2",
//             // "VATValue2",
//             "DateRequired2", "DateDeliver2", "DateCreated2",
//             "DateEdit2", "OrderCode2", "Remarks2", "PayType2", "ImgHeader2", "CompanyBaseUrl2")
//         {
//             IntegrationConfigs = integrationConfigs,
//             OrderNotes = orderNotes,
//             OrderAttributes = orderAttributes,
//             PurchaserPerson = purchaserPerson,
//             Addresses = addresses,
//             Payments = payments,
//             OrderDetailList = orderDetailList
//         };
//     }
// }
