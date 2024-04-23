// using System.ComponentModel.DataAnnotations;

// namespace OracleFetchApi.Model.EmailTemplates;

// public class Order : EmailTemplate
// {
//     [Key]
//     public int Id { get; set; }
//     public int OrderId { get; set; }

//     public string ParentOrderCode { get; set; }

//     public string OrderType { get; set; }

//     public string Type { get; set; }

//     public string Source { get; set; }

//     public string Status { get; set; }

//     public string StartSet { get; set; }

//     public string Email1 { get; set; }

//     public string Email2 { get; set; }

//     public string ConsigneeId { get; set; }

//     public string PurchaserId { get; set; }

//     public string PurchaserComment { get; set; }

//     public string PurchaserExtern { get; set; }

//     public string PurchaserFirstname { get; set; }

//     public string PurchaserLastname { get; set; }

//     public string PurchaserMiddlename { get; set; }

//     public string PurchaserFullname { get; set; }

//     public string PurchaserUsername { get; set; }

//     public string PurchaserEmail { get; set; }

//     public string PersonEdit { get; set; }

//     public string PurchaserFunction { get; set; }

//     public string PurchaserFunctionIdExtern { get; set; }

//     public string PurchaserEmploymentType { get; set; }

//     public string PurchaserEmploymentTypeIdExtern { get; set; }

//     public string Total { get; set; }

//     public string TotalExVAT { get; set; }

//     public string TotalVAT { get; set; }

//     // public string VATValue { get; set; }

//     public string DateRequired { get; set; }

//     public string DateDeliver { get; set; }

//     public string DateCreated { get; set; }

//     public string DateEdit { get; set; }

//     public string OrderCode { get; set; }

//     public string Remarks { get; set; }

//     public string PayType { get; set; }

//     public string ImgHeader { get; set; }

//     public string CompanyBaseUrl { get; set; }

//     // Indirecte Attributen
//     public IntegrationConfigs IntegrationConfigs { get; set; }

//     public OrderNotes OrderNotes { get; set; }

//     public OrderAttributes OrderAttributes { get; set; }

//     public PurchaserPerson PurchaserPerson { get; set; }
//     public CompanyPerson CompanyPerson { get; set; }

//     public List<Address> Addresses { get; set; }

//     public Payments Payments { get; set; }

//     public OrderDetailList OrderDetailList { get; set; }

//     // Constructor
//     public Order(
//         int orderId,
//         string parentOrderCode,
//         string orderType,
//         string type,
//         string source,
//         string status,
//         string startSet,
//         string email1,
//         string email2,
//         string consigneeId,
//         string purchaserId,
//         string purchaserComment,
//         string purchaserExtern,
//         string purchaserFirstname,
//         string purchaserLastname,
//         string purchaserMiddlename,
//         string purchaserFullname,
//         string purchaserUsername,
//         string purchaserEmail,
//         string personEdit,
//         string purchaserFunction,
//         string purchaserFunctionIdExtern,
//         string purchaserEmploymentType,
//         string purchaserEmploymentTypeIdExtern,
//         string total,
//         string totalExVAT,
//         string totalVAT,
//         // string vatValue,
//         string dateRequired,
//         string dateDeliver,
//         string dateCreated,
//         string dateEdit,
//         string orderCode,
//         string remarks,
//         string payType,
//         string imgHeader,
//         string companyBaseUrl)
//     {
//         OrderId = orderId;
//         ParentOrderCode = parentOrderCode;
//         OrderType = orderType;
//         Type = type;
//         Source = source;
//         Status = status;
//         StartSet = startSet;
//         Email1 = email1;
//         Email2 = email2;
//         ConsigneeId = consigneeId;
//         PurchaserId = purchaserId;
//         PurchaserComment = purchaserComment;
//         PurchaserExtern = purchaserExtern;
//         PurchaserFirstname = purchaserFirstname;
//         PurchaserLastname = purchaserLastname;
//         PurchaserMiddlename = purchaserMiddlename;
//         PurchaserFullname = purchaserFullname;
//         PurchaserUsername = purchaserUsername;
//         PurchaserEmail = purchaserEmail;
//         PersonEdit = personEdit;
//         PurchaserFunction = purchaserFunction;
//         PurchaserFunctionIdExtern = purchaserFunctionIdExtern;
//         PurchaserEmploymentType = purchaserEmploymentType;
//         PurchaserEmploymentTypeIdExtern = purchaserEmploymentTypeIdExtern;
//         Total = total;
//         TotalExVAT = totalExVAT;
//         TotalVAT = totalVAT;
//         // VATValue = vatValue;
//         DateRequired = dateRequired;
//         DateDeliver = dateDeliver;
//         DateCreated = dateCreated;
//         DateEdit = dateEdit;
//         OrderCode = orderCode;
//         Remarks = remarks;
//         PayType = payType;
//         ImgHeader = imgHeader;
//         CompanyBaseUrl = companyBaseUrl;
//     }
// }

// public class IntegrationConfigs
// {
//     [Key]
//     public int Id { get; set; }
//     public Config[] Configs { get; set; }
// }

// public class Config
// {
//     [Key]
//     public int Id { get; set; }
//     public string Tool { get; set; }

//     public string UniqueIdentifier { get; set; }

//     public AppSettings AppSettings { get; set; }

//     // Constructor
//     public Config(string tool, string uniqueIdentifier)
//     {
//         Tool = tool;
//         UniqueIdentifier = uniqueIdentifier;
//     }
// }

// public class AppSettings
// {
//     [Key]
//     public int Id { get; set; }
//     public KeyValue[] KeyValues { get; set; }
// }

// public class KeyValue
// {
//     [Key]
//     public int Id { get; set; }
//     public string Key { get; set; }

//     public string Value { get; set; }

//     // Constructor
//     public KeyValue(string key, string value)
//     {
//         Key = key;
//         Value = value;
//     }
// }

// public class OrderNotes
// {
//     [Key]
//     public int Id { get; set; }
//     public OrderNote[] Notes { get; set; }
// }

// public class OrderNote
// {
//     [Key]
//     public int Id { get; set; }
//     public string Description { get; set; }

//     public string Person { get; set; }

//     public string NoteGroup { get; set; }

//     public string CreatedOn { get; set; }

//     public string CreatedBy { get; set; }

//     public string ModifiedOn { get; set; }

//     public string ModifiedBy { get; set; }

//     // Constructor
//     public OrderNote(string description, string person, string noteGroup, string createdOn, string createdBy, string modifiedOn, string modifiedBy)
//     {
//         Description = description;
//         Person = person;
//         NoteGroup = noteGroup;
//         CreatedOn = createdOn;
//         CreatedBy = createdBy;
//         ModifiedOn = modifiedOn;
//         ModifiedBy = modifiedBy;
//     }
// }

// public class OrderAttributes
// {
//     [Key]
//     public int Id { get; set; }
//     public OrderAttribute[] Attributes { get; set; }
// }

// public class OrderAttribute
// {
//     [Key]
//     public int Id { get; set; }
//     public string Description { get; set; }

//     public string Value { get; set; }

//     public string UserVisibility { get; set; }

//     public string ExternalId { get; set; }
//     public string Validation { get; set; }

//     // Constructor
//     public OrderAttribute(string description, string value, string userVisibility, string externalId, string validation)
//     {
//         Description = description;
//         Value = value;
//         UserVisibility = userVisibility;
//         ExternalId = externalId;
//         Validation = validation;
//     }
// }

// public class PurchaserPerson
// {
//     [Key]
//     public int Id { get; set; }
//     public string PersonId { get; set; }

//     public string ExternalPersonId { get; set; }

//     public string GenderId { get; set; }

//     public string FirstName { get; set; }
//     public string LastName { get; set; }

//     public string MiddleName { get; set; }

//     public string FullName { get; set; }

//     public string UserName { get; set; }

//     public string Title { get; set; }

//     public string Suffix { get; set; }

//     public string Prefix { get; set; }

//     public string Remarks { get; set; }

//     public string Email { get; set; }

//     public string Company { get; set; }

//     public string CompanyId { get; set; }

//     public string Function { get; set; }

//     public string ExternalFunctionId { get; set; }

//     public string EmploymentType { get; set; }

//     public string ExternalEmploymentTypeId { get; set; }

//     public string Acronym { get; set; }

//     public string ProjectCode { get; set; }
//     public string Saldo { get; set; }

//     public List<PersonAttribute> PersonAttributes { get; set; }

//     // Constructor
//     public PurchaserPerson(string personId, string externalPersonId, string genderId, string firstName, string lastName, string middleName, string fullName, string userName, string title, string suffix, string prefix, string remarks, string email, string company, string companyId, string function, string externalFunctionId, string employmentType, string externalEmploymentTypeId, string acronym, string projectCode, string saldo)
//     {
//         PersonId = personId;
//         ExternalPersonId = externalPersonId;
//         GenderId = genderId;
//         FirstName = firstName;
//         LastName = lastName;
//         MiddleName = middleName;
//         FullName = fullName;
//         UserName = userName;
//         Title = title;
//         Suffix = suffix;
//         Prefix = prefix;
//         Remarks = remarks;
//         Email = email;
//         Company = company;
//         CompanyId = companyId;
//         Function = function;
//         ExternalFunctionId = externalFunctionId;
//         EmploymentType = employmentType;
//         ExternalEmploymentTypeId = externalEmploymentTypeId;
//         Acronym = acronym;
//         ProjectCode = projectCode;
//         Saldo = saldo;
//     }
// }

// public class PersonAttribute
// {
//     [Key]
//     public int Id { get; set; }
//     public string ExternalId { get; set; }

//     public string Description { get; set; }

//     public string Value { get; set; }
//     public string UniqueId { get; set; }

//     public string UserVisibility { get; set; }

//     // Constructor
//     public PersonAttribute(string externalId, string description, string value, string uniqueId, string userVisibility)
//     {
//         ExternalId = externalId;
//         Description = description;
//         Value = value;
//         UniqueId = uniqueId;
//         UserVisibility = userVisibility;
//     }
// }

// public class CompanyPerson
// {
//     [Key]
//     public int Id { get; set; }
//     public string PersonId { get; set; }

//     public string ExternalPersonId { get; set; }

//     public string GenderId { get; set; }

//     public string FirstName { get; set; }

//     public string LastName { get; set; }

//     public string MiddleName { get; set; }

//     public string FullName { get; set; }

//     public string UserName { get; set; }
//     public string Title { get; set; }

//     public string Suffix { get; set; }

//     public string Prefix { get; set; }

//     public string Remarks { get; set; }

//     public string Email { get; set; }

//     public string Company { get; set; }

//     public string CompanyId { get; set; }

//     public string Function { get; set; }

//     public string ExternalFunctionId { get; set; }

//     public string EmploymentType { get; set; }

//     public string ExternalEmploymentTypeId { get; set; }

//     public string Acronym { get; set; }

//     public string ProjectCode { get; set; }

//     public string Saldo { get; set; }

//     public PersonFunctions PersonFunctions { get; set; }

//     public PersonRoles PersonRoles { get; set; }

//     public PersonAttributes PersonAttributes { get; set; }

//     public List<Address> Addresses { get; set; }

//     // Constructor
//     public CompanyPerson(string personId, string externalPersonId, string genderId, string firstName, string lastName,
//                          string middleName, string fullName, string userName, string title, string suffix, string prefix,
//                          string remarks, string email, string company, string companyId, string function, string externalFunctionId,
//                          string employmentType, string externalEmploymentTypeId, string acronym, string projectCode, string saldo)
//     {
//         PersonId = personId;
//         ExternalPersonId = externalPersonId;
//         GenderId = genderId;
//         FirstName = firstName;
//         LastName = lastName;
//         MiddleName = middleName;
//         FullName = fullName;
//         UserName = userName;
//         Title = title;
//         Suffix = suffix;
//         Prefix = prefix;
//         Remarks = remarks;
//         Email = email;
//         Company = company;
//         CompanyId = companyId;
//         Function = function;
//         ExternalFunctionId = externalFunctionId;
//         EmploymentType = employmentType;
//         ExternalEmploymentTypeId = externalEmploymentTypeId;
//         Acronym = acronym;
//         ProjectCode = projectCode;
//         Saldo = saldo;
//     }
// }

// public class PersonFunctions
// {
//     [Key]
//     public int Id { get; set; }
//     public List<Function> Functions { get; set; }
// }

// public class Function
// {
//     [Key]
//     public int Id { get; set; }
//     public string Description { get; set; }

//     public string ExternalFunctionId { get; set; }

//     // Constructor
//     public Function(string description, string externalFunctionId)
//     {
//         Description = description;
//         ExternalFunctionId = externalFunctionId;
//     }
// }

// public class PersonRoles
// {
//     [Key]
//     public int Id { get; set; }
//     public List<Role> Roles { get; set; }
// }

// public class Role
// {
//     [Key]
//     public int Id { get; set; }
//     public string RoleName { get; set; }
//     public string SortOrder { get; set; }
//     // Constructor
//     public Role(string roleName, string sortOrder)
//     {
//         RoleName = roleName;
//         SortOrder = sortOrder;
//     }
// }

// public class PersonAttributes
// {
//     [Key]
//     public int Id { get; set; }
//     public List<PersonAttribute> Attributes { get; set; }
// }

// public class Addresses
// {
//     [Key]
//     public int Id { get; set; }
//     public Address Address { get; set; }

// }

// public class Address
// {
//     [Key]
//     public int Id { get; set; }
//     public string ClassId { get; set; }

//     public string ProjectCode { get; set; }

//     public string AddressTypeId { get; set; }

//     public string Preamble { get; set; }

//     public string Street { get; set; }

//     public string Extra { get; set; }

//     public string PrimaryNumber { get; set; }

//     public string AdditionalNumber { get; set; }

//     public string ZipCode { get; set; }

//     public string City { get; set; }

//     public string State { get; set; }

//     public string CountryCode { get; set; }

//     public string CountryCode2 { get; set; }

//     public string DateFrom { get; set; }
//     public string DateCreated { get; set; }

//     public AddressAttributes AddressAttributes { get; set; }

//     // Constructor
//     public Address(string classId, string projectCode, string addressTypeId, string preamble, string street, string extra, string primaryNumber, string additionalNumber, string zipCode, string city, string state, string countryCode, string countryCode2, string dateFrom, string dateCreated)
//     {
//         ClassId = classId;
//         ProjectCode = projectCode;
//         AddressTypeId = addressTypeId;
//         Preamble = preamble;
//         Street = street;
//         Extra = extra;
//         PrimaryNumber = primaryNumber;
//         AdditionalNumber = additionalNumber;
//         ZipCode = zipCode;
//         City = city;
//         State = state;
//         CountryCode = countryCode;
//         CountryCode2 = countryCode2;
//         DateFrom = dateFrom;
//         DateCreated = dateCreated;
//     }
// }

// public class AddressAttributes
// {
//     [Key]
//     public int Id { get; set; }
//     public List<AddressAttribute> AddressAttribute { get; set; }
// }

// public class AddressAttribute
// {
//     [Key]
//     public int Id { get; set; }
//     public string Description { get; set; }

//     public string Value { get; set; }

//     public string ExternalId { get; set; }

//     // Constructor
//     public AddressAttribute(string description, string value, string externalId)
//     {
//         Description = description;
//         Value = value;
//         ExternalId = externalId;
//     }
// }

// public class Payments
// {
//     [Key]
//     public int Id { get; set; }
//     public string Factor { get; set; }

//     public Payment Payment { get; set; }

//     // Constructor
//     public Payments(string factor)
//     {
//         Factor = factor;
//     }
// }

// public class Payment
// {
//     [Key]
//     public int Id { get; set; }
//     public string Type { get; set; }

//     public string Amount { get; set; }

//     public string Paid { get; set; }

//     // Constructor
//     public Payment(string type, string amount, string paid)
//     {
//         Type = type;
//         Amount = amount;
//         Paid = paid;
//     }
// }

// public class OrderDetailList
// {
//     [Key]
//     public int Id { get; set; }
//     public List<OrderDetail> OrderDetails { get; set; }
// }

// public class OrderDetail
// {
//     [Key]
//     public int Id { get; set; }
//     public string OrderDetailId { get; set; }

//     public string ProductId { get; set; }

//     public string SupplierProductId { get; set; }

//     public string ProductCode { get; set; }

//     public string ProductName { get; set; }
//     public string Quantity { get; set; }
//     public string Price { get; set; }

//     public string PriceExVat { get; set; }

//     public string PriceIncVat { get; set; }

//     public string PriceVatOnly { get; set; }

//     public string VatPercentage { get; set; }

//     public string DetailType { get; set; }

//     public string Size { get; set; }

//     public string AssortmentId { get; set; }

//     public string Status { get; set; }

//     public string NumberNotDeliverable { get; set; }

//     public string NumberBackOrder { get; set; }

//     public string NumberSend { get; set; }

//     public string NumberReceived { get; set; }

//     public string NumberDeliverable { get; set; }

//     public string SetGroupName { get; set; }

//     public string SetGroupIdExtern { get; set; }

//     public string SetDateStart { get; set; }

//     public string DateModified { get; set; }

//     public string DeliveryDate { get; set; }

//     public string Remark { get; set; }
//     public Product Product { get; set; }

//     public OrderDetailAttributes OrderDetailAttributes { get; set; }

//     // Constructor
//     public OrderDetail(
//         string orderDetailId, string productId, string supplierProductId, string productCode,
//         string productName, string quantity, string price, string priceExVat, string priceIncVat,
//         string priceVatOnly, string vatPercentage, string detailType, string size, string assortmentId,
//         string status, string numberNotDeliverable, string numberBackOrder, string numberSend,
//         string numberReceived, string numberDeliverable, string setGroupName, string setGroupIdExtern,
//         string setDateStart, string dateModified, string deliveryDate, string remark)
//     {
//         OrderDetailId = orderDetailId;
//         ProductId = productId;
//         SupplierProductId = supplierProductId;
//         ProductCode = productCode;
//         ProductName = productName;
//         Quantity = quantity;
//         Price = price;
//         PriceExVat = priceExVat;
//         PriceIncVat = priceIncVat;
//         PriceVatOnly = priceVatOnly;
//         VatPercentage = vatPercentage;
//         DetailType = detailType;
//         Size = size;
//         AssortmentId = assortmentId;
//         Status = status;
//         NumberNotDeliverable = numberNotDeliverable;
//         NumberBackOrder = numberBackOrder;
//         NumberSend = numberSend;
//         NumberReceived = numberReceived;
//         NumberDeliverable = numberDeliverable;
//         SetGroupName = setGroupName;
//         SetGroupIdExtern = setGroupIdExtern;
//         SetDateStart = setDateStart;
//         DateModified = dateModified;
//         DeliveryDate = deliveryDate;
//         Remark = remark;
//     }
// }

// public class Product
// {
//     [Key]
//     public int Id { get; set; }
//     public string ProductId { get; set; }

//     public string SupplierProductId { get; set; }

//     public string ProductCode { get; set; }

//     public string ClassId { get; set; }

//     public string ProductName { get; set; }

//     public string ProductDescription { get; set; }

//     public string Active { get; set; }

//     public string Language { get; set; }

//     public List<Assortment> AssortmentList { get; set; }

//     // Constructor
//     public Product(
//         string productId, string supplierProductId, string productCode, string classId,
//         string productName, string productDescription, string active, string language)
//     {
//         ProductId = productId;
//         SupplierProductId = supplierProductId;
//         ProductCode = productCode;
//         ClassId = classId;
//         ProductName = productName;
//         ProductDescription = productDescription;
//         Active = active;
//         Language = language;
//     }
// }

// public class Assortment
// {
//     [Key]
//     public int Id { get; set; }
//     public string AssortmentId { get; set; }

//     public string MeasureValue { get; set; }

//     public string PriceIntern { get; set; }

//     public string ValutaIntern { get; set; }

//     public string PriceExtern { get; set; }

//     public string ValutaExtern { get; set; }

//     public string DateFrom { get; set; }

//     public string InStock { get; set; }

//     public string Active { get; set; }

//     public string SupplierAssortmentId { get; set; }

//     // Constructor
//     public Assortment(
//         string assortmentId, string measureValue, string priceIntern, string valutaIntern,
//         string priceExtern, string valutaExtern, string dateFrom, string inStock,
//         string active, string supplierAssortmentId)
//     {
//         AssortmentId = assortmentId;
//         MeasureValue = measureValue;
//         PriceIntern = priceIntern;
//         ValutaIntern = valutaIntern;
//         PriceExtern = priceExtern;
//         ValutaExtern = valutaExtern;
//         DateFrom = dateFrom;
//         InStock = inStock;
//         Active = active;
//         SupplierAssortmentId = supplierAssortmentId;
//     }
// }

// public class OrderDetailAttributes
// {
//     [Key]
//     public int Id { get; set; }
//     public List<OrderDetailAttribute> OrderDetailAttributeList { get; set; }
// }

// public class OrderDetailAttribute
// {
//     [Key]
//     public int Id { get; set; }
//     public string ExternId { get; set; }

//     public string Value { get; set; }

//     public string Description { get; set; }

//     public string UserVisibility { get; set; }

//     public string Validation { get; set; }

//     // Constructor
//     public OrderDetailAttribute(string externId, string value, string description, string userVisibility, string validation)
//     {
//         ExternId = externId;
//         Value = value;
//         Description = description;
//         UserVisibility = userVisibility;
//         Validation = validation;
//     }
// }