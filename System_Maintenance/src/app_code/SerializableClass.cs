using System;
using System.Collections.Generic;
using xAPI.Library.General;
namespace xSystem_Maintenance.src.app_code
{
    [Serializable]
    public class srParties
    {
        public string ID { get; set; }
        public int Partytypeid { get; set; }
        public int Distributorid { get; set; }
        public string distid { get; set; }
        public string Partyname { get; set; }
        public string Description { get; set; }
        public string EndEventdate { get; set; }
        public string Eventdate { get; set; }
        public string StartEventdate { get; set; }
        public string Eventhour { get; set; }
        public DateTime Startregistration { get; set; }
        public DateTime Endregistration { get; set; }
        public DateTime Createddate { get; set; }
        public string HostessName { get; set; }
        public string Location { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Stateprovince { get; set; }
        public string Postalcode { get; set; }
        public int Countryid { get; set; }
        public srHostess Hostess { get; set; }
        public string Status { get; set; }
        public string HostFirstName { get; set; }
        public string HostLastName { get; set; }
        public string Suburb { get; set; }
        public string Close { get; set; }


        public string isCheckbok { get; set; }

        public string Index { get; set; }
    }
    [Serializable]
    public class srHostess
    {
        public string ID { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Password { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Stateprovince { get; set; }
        public string Postalcode { get; set; }
        public int Countryid { get; set; }
        public string Lastname { get; set; }
        public string Message { get; set; }
        public bool IsCorrect { get; set; }
    }
    [Serializable]
    public class srLogsReport
    {
        public string ID { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string TypeData { get; set; }
        public string IdData { get; set; }
        public string Table { get; set; }

        public string Index { get; set; }
    }
    [Serializable]
    public class srWeeklyCommissions
    {
        public string CommissionId { get; set; }
        public string OrderNumber { get; set; }
        public string SkuId { get; set; }
        public string Quantity { get; set; }
        public string EnrollerId { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public string cbdisplay { get; set; }
    }

    [Serializable]

    public class srPayCommissions
    {
        public string Id { get; set; }
        public string Legacynumber { get; set; }
        public string CommPeriod { get; set; }
        public string DistributorId { get; set; }
        public string OrderNo { get; set; }
        public string BonusRecipientId { get; set; }
        public string BonusAmount { get; set; }
        public string BonusLevel { get; set; }
    }
    [Serializable]
    public class srinfotraxLogin
    {
        public string ROLES { get; set; }
        public string SESSION { get; set; }
        public string response { get; set; }
    }
    [Serializable]
    public class srErrorinfotraxLogin
    {
        public string ERRORCODE { get; set; }
        public string MESSAGE { get; set; }
        public string DETAIL { get; set; }
        public string TIMESTAMP { get; set; }
    }
    [Serializable]
    public class srProductCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
        public string Order { get; set; }
    }

    [Serializable]
    public class srUserDownline
    {
        public string username { get; set; }
        public string EmailManager { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string legacynumber { get; set; }
        public string Name { get; set; }


    }

    [Serializable]
    public class srProductCategory2
    {
        public string CategoryID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
    [Serializable]
    public class srNotify
    {
        public string NumberMessage { get { return string.Format("You have {0} new messages(s)", this.Number); } }
        public int Number { get; set; }
        public List<srMessageNotify> MessagesList { get; set; }

        public srNotify()
        {
            this.MessagesList = new List<srMessageNotify>();
        }


    }
    [Serializable]
    public class srMessageNotify
    {
        public string ID { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
        public string TimeAgo { get; set; } 
    }

    [Serializable]
    public class srAlertDistributor
    {
        public string ID { get; set; }
        public string Content { get; set; }
        public string TimeAgo { get; set; }
        public string Estado { get; set; }
    }
    [Serializable]
    public class srCategorybyCatalog
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    [Serializable]
    public class srCatalogs 
    {
        public string Id { get; set; }
        public string CatName { get; set; }
        public string CatDescription { get; set; }
        public string MarketName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srProviders
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srTips 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string LanguageName { get; set; }
        public string Index { get; set; }
        public string Action { get; set; }

        public string isCheckbox { get; set; }
    }
    [Serializable]
    public class srLibrary
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string Section { get; set; }
        public string LanguageName { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }
    [Serializable]
    public class srCalendar
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srEvents
    {
        public string Id { get; set; }
        public string Host { get; set; }
        public string EventDisplay { get; set; }
        public string EventTittle { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string LanguageName { get; set; }
        public string Location { get; set; }
        public string EventType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srTitlesOverride
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }
        
    [Serializable]
    public class srHelp
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }
    //[Serializable]
    //public class srNotesOrder
    //{

    //    public String Id { get; set; }
    //    public String OrderId { get; set; }
    //    public String Note { get; set; }
    //    public String CreatedDate { get; set; }
    //    public String Createdby { get; set; }
        
    //}
    

    [Serializable]
    public class srBlacklist
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Word { get; set; }
        public string CreatedDate { get; set; }
        public string Reason { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srExchangeRates
    {
        public string Id { get; set; }
        public string MarketId { get; set; }
        public string ExchangeDate { get; set; }
        public string ExchangeRate { get; set; }
        public string MarketName { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srResultList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string text { get; set; }
        public string value { get; set; }
        public string desc { get; set; }
        public string Status { get; set; }
    }
     [Serializable]
    public class srRespLogin
    {
         public string SESSION { get; set; }
        //public String Name { get; set; }
        //public String text { get; set; }
        //public String value { get; set; }
        //public String desc { get; set; }
        //public String Status { get; set; }
    }
    
    [Serializable]
    public class srMarkets
    {
        public string Id { get; set; }
        public string MarketName { get; set; }
        public string MarketDescription { get; set; }
        public string MarketCurrency { get; set; }
        public string CurrencySymbol { get; set; }
        public string TaxRate { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }
    
    [Serializable]
    public class srMarketStates
    {
        public string ID { get; set; }
        public string ABBNAME { get; set; }
        public string NAME { get; set; }
        public string STATUS { get; set; }
        public string MARKETID { get; set; }
        public string MARKETNAME { get; set; }
        public short ACTION { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srReportCommissions
    {
        public string Id { get; set; }
        public string DistributorId { get; set; }
        public string EnrollerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string MarketId { get; set; }
        public string MarketName { get; set; }
        public string Balance { get; set; }
        public string AmountReserved { get; set; }
        public string AmountPaid { get; set; }
        public string HasAccount { get; set; }
        public string AccountNumber { get; set; }
        public string PayoutMethod { get; set; }
    }


    [Serializable]
    public class srMarketsMerchant 
    {
        public string Id { get; set; }
        public string LanguageId { get; set; }
        public string MarketName { get; set; }
        public string MarketDescription { get; set; }
        public string MarketCurrency { get; set; }
        public string CurrencySymbol { get; set; }
        public string TaxRate { get; set; }
        public string Status { get; set; }
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
        public string LanguageCode { get; set; }

        public string idCheckbox { get; set; }

        public string Index { get; set; }
    }

    [Serializable]
    public class srMerchant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Merchantid { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
    }

    [Serializable]
    public class srPegRates
    {
        public string Id { get; set; }
        public string MarketId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Currency { get; set; }
        public string Rate { get; set; }
        public string MarketName { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srTaxCategory
    {
        public string Id { get; set; }
        public string MarketId { get; set; }
        public string MarketName { get; set; }
        public string CategoryName { get; set; }
        public string TaxRate { get; set; }
        public string CountryName { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }

    }


    //[Serializable]
    //public class srProducts
    //{
    //    public String Id { get; set; }
    //    public String Name { get; set; }

    //    public String MarketId { get; set; }
    //    public String MarketName { get; set; }

    //    public String ExchangeRate { get; set; }

    //    public String VendorId { get; set; }
    //    public String VendorName { get; set; }

    //    public String CategoryId { get; set; }
    //    public String CategoryName { get; set; }

    //    public String ProductSubType { get; set; }
    //    public String ProductUnit { get; set; }
    //    public String ShortDescription { get; set; }
    //    public String FullDescription { get; set; }
    //    public String SkuId { get; set; }
    //    public String SkuName { get; set; }
    //    public String AddDate { get; set; }
    //    public Decimal SalesTax { get; set; }
    //    public Decimal RetailPrice { get; set; }
    //    public Decimal WholeSalePrice { get; set; }
    //    public Decimal ShippingAndHandlingPrice { get; set; }
    //    public Decimal CommissionValue { get; set; }
    //    public Decimal QualifyingVolume { get; set; }
    //    public Decimal MinOrderQty { get; set; }
    //    public Int32 QuantityOnHand { get; set; }
    //    public Int32 WarehouseId { get; set; }
    //    public Int32 OutOfStockAction { get; set; }
    //    public Boolean NotifyWhenMinimum { get; set; }
    //    public String Package { get; set; }
    //    public String Width { get; set; }
    //    public String Depth { get; set; }
    //    public String Weight_Lbs { get; set; }
    //    public String Dimensions { get; set; }
    //    public Boolean ShowType { get; set; }
    //    public Boolean DisplayInShoppingCart { get; set; }
    //    public Boolean MultiPackage { get; set; }
    //    public Boolean ChargeShipping { get; set; }
    //    public Boolean ChargeTax { get; set; }
    //    public Boolean ChargeTaxOnShipping { get; set; }
    //    public Boolean AutoShip { get; set; }
    //    public String ImageLocation { get; set; }
    //    public String ImageForDistributor { get; set; }
    //    public Decimal SalesPrice { get; set; }
    //    public Boolean IsBussinessPack { get; set; }
    //    public String ShowInQuickAdd { get; set; }
    //    public String Status { get; set; }
    //}

    //[Serializable]
    //public class srBase
    //{
    //    public String Id { get; set; }
    //    public String Name { get; set; }
    //    public String Description { get; set; }
    //    public String CreatedDate { get; set; }
    //    public String Disabled { get; set; }
    //    public String Status { get; set; }
    //    public String Createdby { get; set; }
    //    public String Query { get; set; }
    //    public String isCheckbox { get; set; }
    //    public String UpdatedDate { get; set; }
    //    public String UpdatedBy { get; set; }
    //    public String Index { get; set; }
    //    public String Index2 { get; set; }
    //    public String Default { get; set; }
    //}

    [Serializable]
    public class srReportCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    [Serializable]
    public class srReport
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public string Status { get; set; }
        public string Static { get; set; }
        public string Url { get; set; }
    }


    [Serializable]
    public class srCountry
    {
        public string CountryId { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }
    [Serializable]
    public class srDistributorPws
    {
        public string Id { get; set; }
        public string DistId { get; set; }
        public string Legacynumber { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Review { get; set; }
        public string ResourceReview { get; set; }
        public string Site { get; set; }
        public string Date { get; set; }
        public string Country { get; set; }
        public string Index { get; set; }
        public string isAction { get; set; }
        public string Marketname { get; set; }
        public string ResourceEditReview { get; set; }
        public string Links { get; set; }
        public string ViewPhoto { get; set; }

    }
    [Serializable]
    public class srRenu28
    {
        public string Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BeforePhoto { get; set; }
        public string AfterPhoto { get; set; }
        public string DistId { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string Index { get; set; }
       
    }
    [Serializable]
    public class srDistributorLog : srBase
    {
        public string Iddistributor { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string Data { get; set; }
        //public String Message { get; set; }
        public string ViewResource { get; set; }

    }
    [Serializable]
    public class srCountryAccess : srBase
    {
        public string Row { get; set; }
    }

    [Serializable]
    public class srNavSetting : srBase
    {
    }

    [Serializable]
    public class srWarehouse:srBase
    {
        public string Address { get; set; }
    }

    [Serializable]
    public class srCommisionPeriod:srBase
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Close { get; set; }
        public string sClose { get; set; }
    }

    [Serializable]
    public class srAdjustmentOverrides
    {
        public string ID { get; set; }
        public string DistributorID { get; set; }
        public string AdjustmentDate { get; set; }
        public string DistributorName { get; set; }
        public string Amount { get; set; }
        public string Comments { get; set; }
        public string CommissionPeriod { get; set; }
        public string AdjustmentType { get; set; }
        public string PeriodClosed { get; set; }
    }
    [Serializable]
    public class srPayments
    {        
        public string ID { get; set; }
        public string DistributorID { get; set; }
        public string DistributorName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Reason { get; set; }        
    }
    [Serializable]
    public class srPayouts
    {
        public string Id { get; set; }
        public string DistributorID { get; set; }
        public string PaymentType { get; set; }
        public string Amount { get; set; }
        public string Comment { get; set; }
        public string Period { get; set; }
        public string PaymentDate { get; set; }
        public string DocNumber { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
    }

    [Serializable]
    public class srNews
    {

        public string Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public int LanguageID { get; set; }
        public string CreatedDate { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srNewsLetters : srBase
    {
        public string Text { get; set; }
        public int LanguageID { get; set; }
    }

    [Serializable]
    public class srResx
    {        
        public string Id { get; set; }
        public string Text { get; set; }
        public string Resx { get; set; }
    }
    [Serializable]
    public class srSitev2
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Status { get; set; }

    }

    [Serializable]
    public class srLanguage : srBase
    {
        public string LanguageName { get; set; }
        public string Icon { get; set; }
        public string CultureInfo { get; set; }
        public string Published { get; set; }
    }

    [Serializable]
    public class srBonus
    {
        public string ID { get; set; }
        public string CreatedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Frequency { get; set; }
        public string Status { get; set; }
        public string Runorder { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srSeasonalOffers
    {
        public string Id { get; set; }
        public string offerName { get; set; }
        public string offerDescription { get; set; }
        public string dateCreated { get; set; }
        public string disabled { get; set; }
        public string sql { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srPressroom : srBase
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    [Serializable]
    public class srSite
    {
        public string SiteName { get; set; }
        public string Distributor { get; set; }
        public string SiteEmail { get; set; }
        public string Index { get; set; }
        public string DistID { get; set; }
        public string DistributorName { get; set; }
        public string CreatedDate { get; set; }
    }

    [Serializable]
    public class srRangesIP
    {
        public string ID { get; set; }
        public string IPFrom { get; set; }
        public string IPTo { get; set; }
        public string TypeIP { get; set; }
        public string CreatedDate { get; set; }
        public string Index { get; set; }          
    }
    [Serializable]
    public class srGridSmall
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }
        public string col5 { get; set; }
        public string col6 { get; set; }
        public string col7 { get; set; }
        public string col8 { get; set; }
        public string col9 { get; set; }
        public string col10 { get; set; }
        public string col11 { get; set; }
        public string isSelected { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }



    [Serializable]
    public class srGridReportOrderWithinOrganization
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }
        public string col5 { get; set; }
        public string col6 { get; set; }
        public string col7 { get; set; }
        public string col8 { get; set; }
        public string col9 { get; set; }
        public string col10 { get; set; }
        public string col11 { get; set; }
        public string col12 { get; set; }
        public string col13 { get; set; }
        public string col14 { get; set; }
        public string col15 { get; set; }
        public string col16 { get; set; }
        public string col17 { get; set; }
        public string col18 { get; set; }

    }

    [Serializable]
    public class srGridReportDistributorOrders
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }
        public string col5 { get; set; }
        public string col6 { get; set; }
        public string col7 { get; set; }
        public string col8 { get; set; }
        public string col9 { get; set; }
        public string col10 { get; set; }
        public string col11 { get; set; }
        public string col12 { get; set; }
       
    }


    [Serializable]
    public class srGrid
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }
        public string col5 { get; set; }
        public string col6 { get; set; }
        public string col7 { get; set; }
        public string col8 { get; set; }
        public string col9 { get; set; }
        public string col10 { get; set; }
        public string col11 { get; set; }
        public string col12 { get; set; }
        public string col13 { get; set; }
        public string col14 { get; set; }
        public string col15 { get; set; }
        public string col16 { get; set; }
        public string col17 { get; set; }
        public string col18 { get; set; }
        public string col19 { get; set; }
        public string col20 { get; set; }
        public string col21 { get; set; }
        public string col22 { get; set; }
        public string col23 { get; set; }
        public string col24 { get; set; }
        public string col25 { get; set; }
        public string col26 { get; set; }
        public string isSelected { get; set; }
        public string isCheckbox { get; set; }
        public string col27 { get; set; }
        public string col28 { get; set; }
        public string col29 { get; set; }
        public string col30 { get; set; }
        public string col31 { get; set; }
        public string col32 { get; set; }
        public string col33 { get; set; }
        public string col34 { get; set; }
        public string col35 { get; set; }
        public string col36 { get; set; }
        public string col37 { get; set; }
        public string col38 { get; set; }
        public string col39 { get; set; }
        public string col40 { get; set; }
        public string col41 { get; set; }
        public string col42 { get; set; }
        public string col43 { get; set; }
        public string col44 { get; set; }
        public string col45 { get; set; }
        public string col46 { get; set; }
        public string col47 { get; set; }
        public string col48 { get; set; } 
        public string col49 { get; set; }
        public string col50 { get; set; }
        public string col51 { get; set; }
        public string datarow { get; set; }
        public string currencySymbol { get; set; }
        public string col52 { get; set; }
        public string Reference { get; set; }
        public string col53 { get; set; }
        public string countryShippingRateId { get; set; }
        public string TaxLevelId { get; set; }
        public string InvoiceDocumentStatus { get; set; }
        public string OtherTaxTotal { get; set; }
        public String UserFullName { get; set; }
        public String WarehouseId { get; set; }
        public Boolean IsDistributor { get; set; }
        public String ShippingProviderName { get; set; }
    }
 
    [Serializable]
    public class srDistributor : srBase
    {
        public string DistributorID { get; set; }
        public string ReplicatedSite { get; set; }
        public string UserID { get; set; }
        public string Email { get; set; }
        public string Subdomain { get; set; }
        public string EmailForward { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string JoinDate { get; set; }
        public string BirthDate { get; set; }
        public string LegacyNumber { get; set; }
        public string Rank { get; set; }
        public string Enrolldate { get; set; }
        public string EnrollerId { get; set; }
        public string AccountType { get; set; }
        public string Homephone { get; set; }
    }



    [Serializable]
    public class srOrderHeaderToday
    {
        public string LegacyNumber { get; set; }
        public string SubTotal { get; set; }
        public string OrderTotal { get; set; }
        public string DistributorStatus { get; set; }
        public string TotlShippingCharged { get; set; }
        public string TotalShippingTax { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Message { get; set; }
        public string Volume { get; set; }
    }

    [Serializable]
    public class srDistributorSearch
    {
        public string Index { get; set; }
        public string Id { get; set; }
       
        public string FullName { get; set; }
        
        public string LegacyNumber { get; set; }

        public string Name { get; set; }
    }
    [Serializable]
    public class srSubscriptions
    {
        public string Index { get; set; }
        public string DistributorLegacy { get; set; }

        public string Type { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public string Status { get; set; }

        public string OrderLegacy { get; set; }
    }

    [Serializable]
    public class srSettings : srBase
    {
        public string smtp { get; set; }
        public string port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string section { get; set; }

        public string EmailSender { get; set; }
        public string EmailName { get; set; }

        public string CommissionsRunTest { get; set; }
        public string CommissionsRunLive { get; set; }
        public string OrderDateChanged { get; set; }
        public string BlackOrderCreated { get; set; }
        public string ClawbackCreated { get; set; }

        public string ProccesorName { get; set; }
        public string MerchantAccount { get; set; }
        public string Transactionkey { get; set; }
        public string PasswordPayment { get; set; }
        public string Market { get; set; }

        public string SqlServerName { get; set; }
        public string SqlServerProfile { get; set; }
        public string UserSqlServerProfile { get; set; }

        public string ProccesorId { get; set; }
        public string AuthenticationToken { get; set; }
        public string MerchantProfileId { get; set; }
        public string TestCreditCard { get; set; }
        public string MerchantProcessorId { get; set; }
        public string MerchantAccountId { get; set; }
        public string MerchantId { get; set; }

        public string UseInAllMarkets { get; set; }
        public string Url { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
    }


    [Serializable]
    public class srEmail : srBase
    {
        public string Subject { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string SentDate { get; set; }

        public string Sender { get; set; }
        public string Contact { get; set; }
    }

    [Serializable]
    public class srEmailTemplate : srBase
    {
        public string Subject { get; set; }
        public string Mail { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Module { get; set; }
        public string IdHidden { get; set; }
        public string Campaign { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Page { get; set; }
    }

    [Serializable]
    public class srEmailTemplateManagment : srBase
    {
    }

    [Serializable]
    public class srEmailTemplateManagmentTag : srBase
    {
        public string TagName { get; set; }
    }

    [Serializable]
    public class srLogs : srBase
    {
        public string Source { get; set; }
        public string DateRun { get; set; }
        public string RunBy { get; set; }
        public string OrdersGenerated { get; set; }
        public string OrdersDeclined { get; set; }
        public string OrdersPassed { get; set; }
        public string ProcessName { get; set; }
        public string OrdersTotal { get; set; }
        public string OrdersStatus { get; set; }
        public string OrdersModule { get; set; }
    }
    //[Serializable]
    //public class srOrderHeader : srBase
    //{
    //    public String OrderNumber { get; set; }
    //    public String Orderdate { get; set; }
    //    public String LegacyNumber { get; set; }
    //    public String Iddistributor { get; set; }
    //    public String Fullname { get; set; }
    //    public String Subtotal { get; set; }
    //    public String Date { get; set; }
    //    public String Discounts { get; set; }
    //    public String Citytaxes { get; set; }
    //    public String Countytaxes { get; set; }
    //    public String Statetaxes { get; set; }
    //    public String Totalshipping { get; set; }
    //    public String Totalshippingtax { get; set; }
    //    public String Totaltax { get; set; }
    //    public String Ordertotal { get; set; }
    //    public String Atdate { get; set; }
    //    public String Type { get; set; }
    //    public String Country { get; set; }
    //    public String City { get; set; }
    //    public String State { get; set; }
    //    public String Address { get; set; }
    //    public String Trackingnumber { get; set; }
    //    public String UpdateUser { get; set; }
    //    //
    //    public String CommValue { get; set; }
    //    public String DistributirId { get; set; }
    //    public String DateShipped { get; set; }
    //    public String DateCompleted { get; set; }
    //    public String Invoiceno { get; set; }
    //    public String Action { get; set; }
    //    public String CardLast4 { get; set; }

    //    /*Order Detail Fields*/
    //    public String OrderDetailId { get; set; }
    //    public String Skuid { get; set; } 
    //    public String UnitPrice { get; set; }
    //    public String Quantity { get; set; }
    //    public String Discount { get; set; }
    //    public String TotalPrice { get; set; }        /*_END*/


    //    public String DatePrinted { get; set; }

    //    public String InvoiceNo { get; set; }

    //    public String Response { get; set; }
    //    public String isAction { get; set; }
    //    public String Index { get; set; }
    //}


    [Serializable]
    public class srOrderDetail : srBase
    {
        public string ProductName { get; set; }
        public string UnitPrice { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string TotalPrice { get; set; }
    }

    [Serializable]
    public class srAddress : srBase {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string AddressType { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public string CountryId { get; set; }
        public string isAddress { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string Federalid { get; set; }
        public int Distributorid { get; set; }
        public int Legacy { get; set; }
        public string DistributoridEnc { get; set; }
        public short Setasdefault { get; set; }
        public string OrderMinimumAmount { get; set; }
        public string EnableOrderMinimumAmount { get; set; }
        public string EnableOrders { get; set; }
        public string EnableLoginXr { get; set; }
        public string EnableHelpDescriptions { get; set; }
        public string EnableChatWindows { get; set; }
        public string ConsentApplocation { get; set; }
        public string MinPasswordLenght { get; set; }
        public string HideStep { get; set; }
        public string HideSelectMarket { get; set; }
        public string MaxEmail { get; set; }
        public string EnablePromotion { get; set; }
        public string ShowRetailPriceShoppingCart { get; set; }
        public string ShowMemberPriceShoppingCart { get; set; }
        public string ShowPVAmountShoppingCart { get; set; }
        public string AllowSavingOrders { get; set; }
        public string EnrollmentSponsorUrl { get; set; }
        public string PopupForBlankGoverment { get; set; }
        public string CheckRequestMinimumAmount { get; set; }
        public string ProcessingFee { get; set; }
        public string InactiveMonths { get; set; }
        public string EnrollmentPlacement { get; set; }
        public string Address { get; set; }
        public string CompanyEmail { get; set; }
        public string MaxNodeTree { get; set; }
        public string MaxLevelTree { get; set; }
        public string MaxLevelBinaryTree { get; set; }


    }
    [Serializable]
    public class srCards : srBase
    {
        public int DistributorID { get; set; }
        public string DistributoridEnc { get; set; }
        public string Cardtype { get; set; }
        public string Cardnumber { get; set; }
        public string Expmonth { get; set; }
        public string Expyear { get; set; }
        public string Ccv { get; set; }
        public string Last4 { get; set; }
        public string isCard { get; set; }
        public string NameOnCard { get; set; }
        public string TokenID { get; set; }
    }
    [Serializable]
    public class srBank : srBase
    {
        public int DistributorID { get; set; }
        public string DistributoridEnc { get; set; }
        public short AccountType { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
    }

    //[Serializable]
    //public class srOrdersDetail
    //{

    //    public String ProductName { get; set; }
    //    public String Quantity { get; set; }
    //    public String Skuid { get; set; }
    //    public String Totalprice { get; set; }
    //    public String Unitprice { get; set; }
    //}


    [Serializable]
    public class srSiteExport
    {
        public string DistID { get; set; }
        public string BusinessSiteName { get; set; }
        public string Username { get; set; }
        public string Exception { get; set; }
    }

    public class srUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string LastLogin { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
        public string NameUserRol { get; set; }
        public string isAction { get; set; }

        #region Methods
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            srUser o = (srUser)obj;
            return (this.Id == o.Id);
        }
        #endregion
    }

    public class srInfoTrax
    {
        public string WebService { get; set; }
        public string Description { get; set; }
        public string Response { get; set; }
        public string CreatedDate { get; set; }
    }

    [Serializable]
    public class srResource 
    {
        public string Filename { get; set; }
        public string DocumentType { get; set; }
        public string IsProfilePhoto { get; set; }
        public string IsProductPicture { get; set; }
        public string Distributor { get; set; }
        public string Type { set; get; }
        public string FileExtension { get; set; }
        public string NameResource { get; set; }

    }

    [Serializable]
    public class srAppResource 
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string DocType { get; set; }
        public string UnitPrice { get; set; }
        public string Category { get; set; }
        public string FileDescription { get; set; }
        public string FileExtension { get; set; }
        public string FilePublicName { get; set; }
        public string NameResource { get; set; }
        public string AplicationId { get; set; }
        public string DistributorId { get; set; }
        public string CreatedDate { get; set; }
        public string Photoid { get; set; }
        public string Status { get; set; }
        public string Index { get; set; }
        public string isCheckbox { get; set; }

    }
    [Serializable]
    public class srBanner
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FilePublicName { get; set; }
        public string Number { get; set; }
        public string Url { get; set; }
        public string DistributorId { get; set; }
        public string NameResource { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdatedDate { get; set; }
        public string Status { get; set; }
        public string DocType { get; set; }
        public string AplicationId { get; set; }
        public string PhotoId { get; set; }
        public string Type { get; set; }
        public string Click { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srBannerImage
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Order { get; set; }
    }



    [Serializable]
    public class srCompensationPlan
    {
        public string ID { get; set; }
        public string IDRESOURCE { get; set; }
        public string Name { get; set; }
        public string TypeDoc { get; set; }
        public string Description { get; set; }
        public string NameResource { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
    }


    [Serializable]
    public class srFaqs:srBase
    {
        public string FaqQuestion { get; set; }
        public string FaqAnswer { get; set; }
        public string LanguageName { get; set; }
        public string CategoryName { get; set; }
        public string Order { get; set; }
    }

    [Serializable]
    public class srDistributorEvents : srBase
    {
        public string EventName { get; set; }
        public string EventDate { get; set; }
        public string StartRegistration { get; set; }
        public string EndRegistration { get; set; }
        public string TotalRegistered { get; set; }
    }

    [Serializable]
    public class srBlogs : srBase
    {
        public string BlogName { get; set; }
        public string BlogDescription { get; set; }
        public string LanguageName { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogDate { get; set; }
    }
    [Serializable]
    public class srNodeGen
    {

        public string level { get; set; }
        public string nro { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string sponsorid { get; set; }
        public string date { get; set; }
        public string[] qualification { get; set; }
        public string state { get; set; }
        public string daysleft { get; set; }
        public string rundate { get; set; }
        public string nbrofcancelled { get; set; }

    }

    //[Serializable]
    //public class srCommissions
    //{
    //    public String daysleft { get; set; }
    //    public String rundate { get; set; }
    //    public String distname { get; set; }
    //    public String rank { get; set; }
    //    public String Month_1 { get; set; }
    //}
    [Serializable]
    public class srNodeGen_v2
    {

        public string level { get; set; }
        public string nro { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string sponsorid { get; set; }
        public string date { get; set; }
        public string[] qualification { get; set; }
        public string state { get; set; }
        public string daysleft { get; set; }
        public string rundate { get; set; }
        public string nbrofcancelled { get; set; }
        public string nbractual { get; set; }
        public string nbrscheduled { get; set; }

    }
    [Serializable]
    public class srNodeGenDetail
    {
        public string Id { get; set; }
        public string Level { get; set; }
        public string Status { get; set; }
        public string Names { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AssociateID { get; set; }
        public string Country { get; set; }
        public string UplineName1 { get; set; }
        public string UplineName2 { get; set; }
        public string SponsorName { get; set; }
        public List<srActivity> Activity { get; set; }
        public List<srChain> Chain { get; set; }
        public List<srAutoshipTrends> AutoshipTrends { get; set; }
        public List<srAutoshipHistory> AutoshipHistory { get; set; }
    }
    [Serializable]
    public class srNodeGenDetail_Data2
    {
        public string Id { get; set; }
        public string Level { get; set; }
        public string Status { get; set; }
        public string Names { get; set; }
        public string Points_Actual { get; set; }
        public string Points_Scheduled { get; set; }
        public List<srDistributorData> Distributor { get; set; }
    }
    [Serializable]
    public class srDistributorData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string List { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
    }
    [Serializable]
    public class srAutoshipTrends
    {
        public string Month { get; set; }
        public string L1 { get; set; }
        public string L2 { get; set; }
        public string L3 { get; set; }
    }
    [Serializable]
    public class srAutoshipHistory
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        
    }
    [Serializable]
    public class srChain
    {
        public string Index { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        

    }
    [Serializable]
    public class srActivity
    {
        public string state { get; set; }
        public string cod { get; set; }
        

    }
    /*
       var obj = new Object();
                obj.Status = "Scheduled";
                obj.Names = "xirect ss";
                obj.Phone = "632-569-7458";
                obj.AssociateID = "85632123";
                obj.Country = "Country";

                obj.Name = 'xss'; //upline:

                obj.nro = 1; //Nro de item
                obj.id = idSearch; // id para buscar y mostrar en el lightbox
                
                
                
                
                
                
                
                
                //Autoship - Trends
                obj.Trends = { items: [] };
                obj.Trends.items.push(
                    { Month: "July", L1: "6 (+2)", L2: "10 (+4)", L3: "18" }
                    , { Month: "June", L1: "4 (+1)", L2: "8 (+2)", L3: "20(+4)" }
                    , { Month: "May", L1: "2 (+2)", L2: "5 (+3)", L3: "15(+5)" }
                );
                //Autoship - History
                obj.History = { items: [] };
                obj.History.items.push(
                        { col1: "L1", col2: "2", col3: "http://xirectss.com/" }
                        , { col1: "L2", col2: "8", col3: "http://xirectss.com/" }
                        , { col1: "L3", col2: "13", col3: "http://xirectss.com/" }
                );
                //Autoship - Activity
                obj.Activity = { items: [] };
                obj.Activity.items.push(
                          { state: "star", cod: "F" }
                        , { state: "star", cod: "M" }
                        , { state: "star", cod: "A" }
                        , { state: "star", cod: "M" }
                        , { state: "point", cod: "J" }
                        , { state: "circle", cod: "J" }
                );
     */

    [Serializable]
    public class srCashierClosing
    {
        public string User { get; set; }
        public string Date { get; set; }
        public string Warehouse { get; set; }
    }

        [Serializable]
    public class srDistributorEntry
    {
        public string id { get; set; }
        public string sponsorid { get; set; }
        public string accounttype { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string company { get; set; }
        public string website { get; set; }
        public string gender { get; set; }
        public string iswarehouse { get; set; }
        public string homephone { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string cellphone { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string birthday { get; set; }
        public string joindate { get; set; }
        public string currency { get; set; }
        public string language { get; set; }
        public string country { get; set; }
        public string market { get; set; }
        public string homeid { get; set; }
        public string shippingid { get; set; }
        public string billingid { get; set; }
        public List<srAddressEntry> addresses{ get; set; }
        public string bankid { get; set; }
        public List<srBankEntry> banks {get;set;}
        public string cardid { get; set; }
        public List<srCardsEntry> cards { get; set; }
        public string notifycccharged { get; set; }
        public string notifyccdeclined { get; set; }
        public string notifynewsignup { get; set; }
        public string notifydownpromoted { get; set; }
        public string notifydowndemoted { get; set; }
        public string notifycomissions { get; set; }
        public string notifytextmsg { get; set; }
        public string legacynumber { get; set; }
        public string ssn { get; set; }
        public string ein { get; set; }
        public string entity { get; set; }
        public string displayname { get; set; }
        public string renewaldate { get; set; }
        public string lifetimerank { get; set; }
        public string lifetimerankdate { get; set; }
        public string paidasrank { get; set; }
        public string paidasrankdate { get; set; }
        public string forcerank { get; set; }
        public string taxexempt { get; set; }
        public string taxLevelId { get; set; }
        public string companyemail { get; set; }
        public string uplineemail { get; set; }
        public string istaxexempt { get; set; }
        public int PhoneType { get; set; }
        public int AlternatePhoneType { get; set; }
        //Custom fields
        public string custom1 { get; set; }
        public string custom2 { get; set; }
        public string custom3 { get; set; }
        public string custom4 { get; set; }
        public string custom5 { get; set; }
        public string custom6 { get; set; }
        public string enrollerid { get; set; }
        public string placementid { get; set; }
        /*---*/
        public string firstnameKana { get; set; }
        public string lastnameKana { get; set; }
        public string firstnameRoman { get; set; }
        public string lastnameRoman { get; set; }
        public string SsnExpirationDate { get; set; }
        /*---*/
        public string firstnameCiryllic { get; set; }
        public string lastnameCiryllic { get; set; }

        public string binaryid { get; set; }
        public string WithholdingTax { get; set; }
        public string contactCategoryId { get; set; }
        public string salutation { get; set; }

        //CommissionPayment
        public String directName { get; set; }
        public String directRouting { get; set; }
        public String directAccount { get; set; }
        public Byte commissionPaymentType { get; set; }
    }
    [Serializable]
    public class srAddressEntry{
        public string id { get; set; }
        public string idserver { get; set; }
        public string addrType { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string pos { get; set; }
        public string selected { get; set; }
    }
    [Serializable]
    public class srBankEntry{
        public string id { get; set; }
        public string idserver { get; set; }
        public string bankname { get; set; }
        public string accounttype { get; set; }
        public string routingnumber { get; set; }
        public string accountnumber { get; set; }
        public string pos { get; set; }
        public string selected { get; set; }
    }
    [Serializable]
    public class srCardsEntry{
           public string id { get; set; }
           public string idserver { get; set; }
           public string cardtype { get; set; }
           public string cardname { get; set; }
           public string cn1 { get; set; }
           public string cn2 { get; set; }
           public string cn3 { get; set; }
           public string cn4 { get; set; }
           public string expyear { get; set; }
           public string expmonth { get; set; }
           public string seccode { get; set; }
           public string pos { get; set; }
           public string selected { get; set; }
    }

    [Serializable]
    public class srContacts {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Msn { get; set; }
        public string Icq { get; set; }
        public string Aol { get; set; }
        public string DateContacted { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string CreatedDate { get; set; }
    }
    [Serializable]
    public class srNotes
    {
        public string Id { get; set; }
        public string DistributorId { get; set; }
        public string CreatedUser { get; set; }
        public string CreatedBy { get; set; }
        public string NoteType { get; set; }
        public string NoteSubject { get; set; }
        public string NoteText { get; set; }
        public string Critical { get; set; }
        public string CriticalSeen { get; set; }
        public string CreatedDate { get; set; }
        public string TopicId { get; set; } 
        public srTopic Topic { get; set; }
        public string FilePublicName { get; set;  }
        public string ResourceID { get; set; }
        public string Path { get; set; }
    }

    [Serializable]
    public class srTopic
    {
        public string Id { get; set; }
        public string TopicName { get; set; }
    }

    [Serializable]
    public class srRankHistory
    {
        public string Id { get; set; }
        public string PreviousRank { get; set; }
        public string NewRank { get; set; }
        public string CommPeriod { get; set; }
        public string DateAchieved { get; set; }
        public string CreatedDate { get; set; }
        public string PeriodName { get; set; }
        //new
        public string DistName { get; set; }
        public string DistLegacy { get; set; }
    }

    [Serializable]
    public class srQualifiedStatus
    {
        public string Id { get; set; }
        public string DistName { get; set; }
        public string DistLegacy { get; set; }
        public string PreviousQualified { get; set; }
        public string NewQualified { get; set; }
        public string CommPeriod { get; set; }
        public string DateAchieved { get; set; }
        public string CreatedDate { get; set; }
        public string PeriodName { get; set; }
    }

    [Serializable]
    public class srCommissionCalculation
    {
        public string Id { get; set; }
        public string DistributorId { get; set; }
        public string DistributorName { get; set; }
        public string Rank { get; set; }
        public string Commission { get; set; }
        public string LegacyNumber { get; set; }
        /*public String Legs { get; set; }
        public String Sa { get; set; }
        public String Dsa { get; set; }
        public String Ssa { get; set; }
        public String Esa { get; set; }
        public String Fvp { get; set; }
        public String Sfvp { get; set; }
        public String Efvp { get; set; }*/
    }

    [Serializable]
    public class srCommissionDetail
    {
        public string Id { get; set; }
        public string Bonus { get; set; }
        public string Distributor { get; set; }
        public string OrderCV { get; set; }
        public string Percentage { get; set; }
        public string Level { get; set; }
        public string Commission { get; set; }
        public string OrderDate { get; set; }
        public string OrderLegacy { get; set; }
        public string CommType { get; set; }
        public string Enroller { get; set; }
        public string Placement { get; set; }
        public string Pool { get; set; }
        public string SharedValue { get; set; }
        public string SharedPoints { get; set; }
        public string Psv { get; set; }
        public string Gsv { get; set; }
        public string Ranks { get; set; }
    }

    [Serializable]
    public class srResultItems
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string text { get; set; }
        public string value { get; set; }
        public string desc { get; set; }
        public string Status { get; set; }
    }

    [Serializable]
    public class srCommissionTotalDetails
    {
        public string Cv { get; set; }
        public string Dollars { get; set; }
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public string Level4 { get; set; }
        public string Level5 { get; set; }
    }

    [Serializable]
    public class srTreeEnrroll
    {
        public string StarDayPlacement { get; set; }
        public string EndDayPlacement { get; set; }
        public string StartDayEnrroll { get; set; }
        public string EndDayEnrroll { get; set; }
        public string MaxMonth { get; set; }
    }

    [Serializable]
    public class srCommissions
    {
        public string QualificationWeeks { get; set; }
        public string PlacementChangeDaysAllowed { get; set; }
    }

    [Serializable]
    public class srFooters : srBase
    {
        public string xbackoffice { get; set; }
        public string xcorporate { get; set; }
    }

    [Serializable]
    public class srEnvironment
    {
        public string Environment { get; set; }
    }

    [Serializable]
    public class srLegEnrollment
    {
        public string LegEnrollment { get; set; }
    }

    [Serializable]
    public class srDistributorMail
    {
        public string Id { get; set; }
        public string FullNameFrom { get; set; }
        public string Subject { get; set; }
        public string CreatedDate { get; set; }
        public string View { get; set; }
        public string FullNameTo { get; set; }
    }

    [Serializable]
    public class srModuleSettings
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Enabled { get; set; }
        public string Show { get; set; }
    }

    

  


    [Serializable]
    public class srProductEntry
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SkuId { get; set; }
        public string SkuName { get; set; }
        public string MarketName { get; set; }
        public string VendorName { get; set; }
        public string CategoryName { get; set; }
        public string ShortDescription { get; set; }
        public string IsSet { get; set; }
        public string TotalMarkets { get; set; }
        public String Stock { get; set; }
    }




    public class srAutoshipPointsList
    {
        public string Completed { get; set; }
        public string Scheduled { get; set; }
        public string Unsuccessful { get; set; }
        public string Cancelled { get; set; }
        public string Empty { get; set; }
        public string Backup { get; set; }
    }

    [Serializable]
    public class srAutoshipPoints
    {
        public string ID { get; set; }
        //public String Name { get; set; }
        //public String Value { get; set; }
        public List<srResultAutoshipPointsList> AutoshipPoints { get; set; }
    }

    [Serializable]
    public class srResultAutoshipPointsList
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    [Serializable]
    public class srSearchCriteriaResults
    {
        public string Id { get; set; }
        public string LegacyNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string JoinDate { get; set; }
        public string Invoice { get; set; }
        public string OrderDate { get; set; }
        public string SubTotal { get; set; }
        public string OrderTotal { get; set; }
        public string Status { get; set; }
        public string col14 { get; set; }
        public string col12 { get; set; }
        public string col11 { get; set; }
        public string col13 { get; set; }

    }

    [Serializable]
    public class srDashBoardResults
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
    }

    [Serializable]
    public class srProductsRelationships
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string SkuId { get; set; }
        public string SkuName { get; set; }
        public string Quantity { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }

    [Serializable]
    public class srProductsChild
    {
        public string IdChild { get; set; }
        public string ProductId { get; set; }
        public string ProductIdChild { get; set; }
        public string ProductNameChild { get; set; }
        public string SkuIdChild { get; set; }
        public string SkuNameChild { get; set; }
        public string QuantityChild { get; set; }
        public string CustomSettings { get; set; }
        public string CreatedDateChild { get; set; }
        public string CreatedByChild { get; set; }
        public string UpdatedDateChild { get; set; }
        public string UpdatedByChild { get; set; }
        public string isCheckboxChild { get; set; }
        public string IndexChild { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }
        public int IsCustom { get; set; }
    }

    [Serializable]
    public class srLanguageTranslator
    {
        public string ID { get; set; }
        public string English { get; set; }
        public string Spanish { get; set; }
        public string Japanese { get; set; }
        public string EnglishCanada { get; set; }
        public string FrenchCanadien { get; set; }
        public string Canadien { get; set; }
        public string German { get; set; }
        public string Hungary { get; set; }
        public string France { get; set; }
        public string Ireland { get; set; }
        public string Netherlands { get; set; }
        public string Austria { get; set; }
        public string Italy { get; set; }
        public string GreatBritain { get; set; }
        public string Slovenia { get; set; }
        public string Norway { get; set; }
        public string Dutch { get; set; }
        public string FrenchBelgium { get; set; }
        public string DutchBelgium { get; set; }
        public string Swedish { get; set; }
        public string Croatian { get; set; }
        public string Denmark { get; set; }
        public string Finland { get; set; }
        public string SpanishMexico { get; set; }
        public string Romanian { get; set; }
        public string Taiwan { get; set; }
        public string Russia { get; set; }
        public string Australia { get; set; }
        public string NewZealand { get; set; }
        public string Singapore { get; set; }
        public string Poland { get; set; }
    }

    [Serializable]
    public class srGoalsManagement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string NewEnrollee { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srTaskManagement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DaysToComplete { get; set; }
        public string SortOrder { get; set; }
        public string Resource { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }
    [Serializable]
    public class srTaskxUser
    {
        public string TaskId { get; set; }
        public string Name { get; set; }
        public string TaskDescription { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Status { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srGlobalInfo
    {
        public string EnrollmentsToday { get; set; }
        public string TodayOrders { get; set; }
        public string TotalRevenue { get; set; }
    
    }

    [Serializable]
    public class srSalesInformation 
    {        
        public string TotalSles { get; set; }        
        public string QuantitySales { get; set; }
        public List<srDetailSalesInformation> Detail { get; set; }
    }

    [Serializable]
    public class srGlobalDashbordReports {
        public string TotalVolumeMonth { get; set; }
        public string TotalVolumeDay { get; set; }
        public string TotalOrderMonth { get; set; }
        public string TotalOrderDay { get; set; }
        public string TotalAutoshipMonth { get; set; }
        public string TotalAutoshipDay { get; set; }
        public string TotalSles { get; set; }
        public List<srDashboardOrdersDetail> Detail { get; set; }
    }

    public class srDashboardOrdersDetail 
    {
        public string Sales { get; set; }
        public string MonthNumber { get; set; }
        public string MonthName { get; set; }
        public string Total { get; set; }
    }

    public class srDetailSalesInformation
    {
        public string Sales { get; set; }
        public string MonthNumber { get; set; }
        public string MonthName { get; set; }
        
    }

    [Serializable]
    public class srGoalsTaskPerformancePreview
    {
        public string TaskID { get; set; }
        public string GoalName { get; set; }
        public string TaskName { get; set; }
        public string DateCompleted { get; set; }
        public string Status { get; set; }
        public string PercentageCompleted { get; set; }
        public string DateLastUpdate { get; set; }
        public string UpdatedBy { get; set; }
    }

    [Serializable]
    public class srPartyItem : srBase
    {
        public string Subject { get; set; }
        public string Mail { get; set; }
        public string Type { get; set; }
        public string Language { get; set; } 
    }

    [Serializable]
    public class srPartyShippingTable : srBase
    {
        public string Subject { get; set; }
        public string Mail { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
    }

    [Serializable]
    public class srAutoresponders
    {
        public string Id { get; set; }
        public string Group { get; set; }
        public string EmailSent { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }

    }
    #region "Notifications - User"
    [Serializable]
    public class srUserNotification
    {
        public string ID { get; set; }
        public string SenderID { get; set; }
        public string SenderName { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string CreatedDate { get; set; }
        public string Mail { get; set; }
        public string FROM { get; set; }
        public string TO { get; set; }
        public string CC { get; set; }
        public string CO { get; set; }
        public string Text { get; set; }
        public string Counter { get; set; }
        public string Status { get; set; }
    }

    #endregion
    [Serializable]
    public class srDistributorEmail
    {
         
        public string ID { get; set; }
        public string SenderID { get; set; }
        public string SenderName { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string Mail { get; set; }
        public string CreatedDate { get; set; }
    }

    [Serializable]
    public class srMillionDollarRates
    {
        public string Id { get; set; }
        public string DistributorId { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
    }

    [Serializable]
    public class srAlertSystem
    {
        public string Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string MarketID { get; set; }
        public string MarketName { get; set; }
        public string TimeAgo { get; set; }
        public string dayname { get; set; }
        public string monthname { get; set; }
        public string yearname { get; set; }
        public string isCheckbox { get; set; }
        public string Index { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Type { get; set; }
    }

    [Serializable]
    public class srEnrollmentsWorld
    {
        public string accounttype { get; set; }
        public string totalenrollments { get; set; }
        public string codeCountry { get; set; }
        public string Message { get; set; }
        public string codeState { get; set; }
        public string status { get; set; }
        public string country_codestate { get; set; }
        public string accounttypeAbbName { get; set; }
    }

    [Serializable]
    public class srResourceCategory
    {
        public string isCheckbox { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srPayoutsDistributor
    {
        public string PayoutId { get; set; }
        public string Amount { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Createddate { get; set; }
        public string DistributorID { get; set; }
        public string DistributorLegacyNo { get; set; }
        public string DistributorName { get; set; }
        public string DistributorHyperwallet { get; set; }
        public string TypeId { get; set; }
        public string strAction { get; set; }
        public string strAction2 { get; set; }
        public string IdProcessing { get; set; }
        public string Fee { get; set; }
        public string isCheckbox { get; set; }
        public string ReceiverId { get; set; }
        public string Period { get; set; }
        public string BillingAddress { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    [Serializable]
    public class srReportCategories
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string UpdateDate { get; set; }
        public string Status { get; set; }
        public string IsCheckbox { get; set; }
        public string Index { get; set; }
    }

    [Serializable]
    public class srReports
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SqlStatement { get; set; }
        public string Disabled { get; set; }
        public string IsCheckbox { get; set; }
        public string Index { get; set; }
        public string ReportType { get; set; }
    }

    public class srQueryFields
    {
        public string Id { get; set; }
        public string QueryId { get; set; }
        public string TableQueryId { get; set; }
        public string TableQueryColumnId { get; set; }
        public string Alias { get; set; }
        public string Status { get; set; }
    }

    [Serializable]
    public class srQueryFilters
    {
        public string Id { get; set; }
        public string QueryId { get; set; }
        public string TableQueryId { get; set; }
        public string TableQueryColumnId { get; set; }
        public string QueryComparisonId { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }
        public string Status { get; set; }
    }

    [Serializable]
    public class srCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string IsCheckbox { get; set; }
        public string Index { get; set; }
    }

    #region shippingcosts
    [Serializable]
    public class srShippingRates
    {
        public string Id { get; set; }
        public string OrderType { get; set; }
        public string OrderTypeDesc { get; set; }
        public string StartPrice { get; set; }
        public string EndPrice { get; set; }
        public string UnitPrice { get; set; }
        public string Shipcost { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
        public string HandlingFee { get; set; }
        public string CountryId { get; set; }
        public string CountryAbr { get; set; }
        public string Speed { get; set; }

        public string Country { get; set; }
        public string StartWeight { get; set; }
        public string EndWeight { get; set; }
        public string ShipFromState { get; set; }
        public string ShipToState { get; set; }
        public string Price { get; set; }

    }
    public class srShippingMarketRates
    {
        public string Id { get; set; }
        public string OrderType { get; set; }
        public string OrderTypeDesc { get; set; }
        public string StartPrice { get; set; }
        public string EndPrice { get; set; }
        public string UnitPrice { get; set; }
        public string Shipcost { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
        public string HandlingFee { get; set; }
        public string CountryId { get; set; }
        public string CountryAbr { get; set; }
        public string Speed { get; set; }

        public string Country { get; set; }
        public string StartWeight { get; set; }
        public string EndWeight { get; set; }
        public string ShipFromMarket { get; set; }
        public string ShipToMarket { get; set; }
        public string Price { get; set; }

    }
    #endregion

    [Serializable]
    public class srCommissionTax
    {
        public string Id { get; set; }
        public string Index { get; set; }
        public string MarketId { get; set; }
        public string MarketName { get; set; }
        public string LowerLimit { get; set; }
        public string TopLimit { get; set; }
        public string FixedFee { get; set; }
        public string PercentageLowerLimit { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
    }

    [Serializable]
    public class srLanguagesTemplate : srBase
    {
        public string EmailTemplateId { get; set; }
        public string LanguageId { get; set; }
    }

    [Serializable]
    public class srDiscount
    {
        public string Id { get; set; }
        public string MarketId { get; set; }
        public string MarketName { get; set; }
        public string LowerLimit { get; set; }
        public string TopLimit { get; set; }
        public string PercentageDiscount { get; set; }
        public string Status { get; set; }
        public string RowCount { get; set; }
    }

    [Serializable]
    public class srFolioDetails
    {
        public String Id { get; set; }
        public String FolioId { get; set; }
        public String ProductId { get; set; }
        public String ProductName { get; set; }
        public String SkuId { get; set; }
        public String FolioDetailQuantity { get; set; }
        public String FolioDetailQuantityReceived { get; set; }
        public String FolioDetailBatchId { get; set; }
        public String FolioDetailExpirationDate { get; set; }
    }

    [Serializable]
    public class srPayoutCredential : srBase
    {
        public string MarketId { get; set; }
        public string RegionId { get; set; }
        public string AccountNumber { get; set; }
        public string Ssn { get; set; }
        public string Email { get; set; }
        public string BankId { get; set; }
        public string BankAccountTypeId { get; set; }
        public string TransfertypeId { get; set; }
        public string DocumentExtensionId { get; set; }
        public string DocumentType { get; set; }
        public string PayoutMethodId { get; set; }
    }
    [Serializable]
    public class srBase
    {
        public String Id { get; set; }
        //public Int32 Legacy { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String CreatedDate { get; set; }
        public String Createdby { get; set; }
        public String Disabled { get; set; }
        public String Status { get; set; }
        public String MessageType { get; set; }
        public String Message { get; set; }
        public String isCheckbox { get; set; }
        public String KeyMessage { get; set; }
        public String Query { get; set; }
        public String Index { get; set; }
        public String Index2 { get; set; }
        public String Default { get; set; }
        public String trad { get; set; }

        //public String id { get; set; }
    }

}